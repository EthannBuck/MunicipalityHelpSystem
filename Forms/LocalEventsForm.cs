using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class LocalEventsForm : Form
    {
        private Form1 parentForm;

        public LocalEventsForm(Form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
        }

        private void LocalEventsForm_Load(object sender, EventArgs e)
        {
            DisplayAllEvents();

            cmbCategory.Items.Add("All Categories");
            cmbCategory.Items.AddRange(EventRepository.Categories.ToArray());
            cmbCategory.SelectedIndex = 0;

            cmbSortBy.Items.AddRange(new string[] { "Date", "Category", "Title" });
            cmbSortBy.SelectedIndex = 0;
            cmbSortOrder.Items.AddRange(new string[] { "Ascending", "Descending" });
            cmbSortOrder.SelectedIndex = 0;

            chkUseDate.Checked = false;

            InitializeTextBoxPlaceholder(txtSearch, "Search event name...");
            InitializeTextBoxPlaceholder(txtNewTitle, "Enter event title");
            InitializeTextBoxPlaceholder(txtNewCategory, "Enter event category");
            InitializeTextBoxPlaceholder(txtNewDesc, "Enter event description");
        }

        private void InitializeTextBoxPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholder;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();
            var allSorted = EventRepository.GetAllEventsSorted("Date", true);
            foreach (var ev in allSorted)
                lstEvents.Items.Add(ev.ToString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (keyword == "Search event name...") keyword = ""; // FIX: ignore placeholder

            string selectedCategory = cmbCategory.SelectedItem?.ToString() ?? "All Categories";
            bool useDate = chkUseDate.Checked;
            DateTime? selectedDate = useDate ? dtDate.Value.Date : (DateTime?)null;

            var results = EventRepository.SearchEvents(keyword, selectedCategory, selectedDate);

            string sortBy = cmbSortBy.SelectedItem?.ToString() ?? "Date";
            bool ascending = (cmbSortOrder.SelectedItem?.ToString() ?? "Ascending") == "Ascending";
            results = SortResults(results, sortBy, ascending);

            lstEvents.Items.Clear();
            if (results.Any())
            {
                foreach (var ev in results)
                    lstEvents.Items.Add(ev.ToString());
            }
            else
            {
                lstEvents.Items.Add("No matching events found.");
            }

            DisplayRecommendations();
            DisplayLastViewed();
        }

        private List<Event> SortResults(List<Event> results, string sortBy, bool ascending)
        {
            List<Event> sorted;

            switch (sortBy.ToLowerInvariant())
            {
                case "date":
                    sorted = ascending ? results.OrderBy(r => r.Date).ToList() : results.OrderByDescending(r => r.Date).ToList();
                    break;
                case "title":
                    sorted = ascending ? results.OrderBy(r => r.Title).ToList() : results.OrderByDescending(r => r.Title).ToList();
                    break;
                case "category":
                    sorted = ascending ? results.OrderBy(r => r.Category).ToList() : results.OrderByDescending(r => r.Category).ToList();
                    break;
                default:
                    sorted = results;
                    break;
            }

            return sorted;
        }


        private void DisplayRecommendations()
        {
            var recs = EventRepository.GetSmartRecommendations(5);
            lstRecommendations.Items.Clear();
            if (recs.Any())
            {
                lblRecommendations.Text = "Recommended for you:";
                foreach (var ev in recs)
                    lstRecommendations.Items.Add(ev.ToString());
            }
            else lblRecommendations.Text = "No recommendations yet.";
        }

        private void DisplayLastViewed()
        {
            lstLastViewed.Items.Clear();
            var last = EventRepository.GetLastViewed(5);
            if (last.Any())
            {
                lblLastViewed.Text = "Last viewed:";
                foreach (var ev in last)
                    lstLastViewed.Items.Add(ev.ToString());
            }
            else lblLastViewed.Text = "Last viewed: (none)";
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1) return;

            var selectedText = lstEvents.SelectedItem.ToString();
            var all = EventRepository.EventsByCategory.Values.SelectMany(q => q).ToList();
            var ev = all.FirstOrDefault(x => x.ToString() == selectedText);
            if (ev != null)
            {
                EventRepository.LastViewed.Push(ev);
                DisplayLastViewed();

                MessageBox.Show($"{ev.Title}\n\nCategory: {ev.Category}\nDate: {ev.Date:d}\n\n{ev.Description}",
                    "Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSubmitEvent_Click(object sender, EventArgs e)
        {
            var title = txtNewTitle.Text.Trim();
            var cat = txtNewCategory.Text.Trim();
            var date = dtNewDate.Value.Date;
            var desc = txtNewDesc.Text.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(cat))
            {
                MessageBox.Show("Please enter at least a Title and Category.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newEvent = new Event { Title = title, Category = cat, Date = date, Description = desc };
            EventRepository.SubmitNewEvent(newEvent);
            UpdateSubmissionQueueCount();

            MessageBox.Show("Event submitted to queue. Click 'Process Submissions' to add it.", "Submitted",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtNewTitle.Clear();
            txtNewCategory.Clear();
            txtNewDesc.Clear();
        }

        private void btnProcessSubmissions_Click(object sender, EventArgs e)
        {
            if (EventRepository.SubmissionQueue.Count == 0)
            {
                MessageBox.Show("No pending submissions.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EventRepository.ProcessSubmissions();

            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            cmbCategory.Items.AddRange(EventRepository.Categories.ToArray());
            cmbCategory.SelectedIndex = 0;

            DisplayAllEvents();
            DisplayRecommendations();
            UpdateSubmissionQueueCount();

            MessageBox.Show("Processed pending submissions.", "Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateSubmissionQueueCount()
        {
            lblQueueCount.Text = $"Pending submissions: {EventRepository.SubmissionQueue.Count}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentForm.ShowWelcomeScreen();
        }

        private void cmbSortBy_SelectedIndexChanged(object sender, EventArgs e) => btnSearch_Click(null, null);
        private void cmbSortOrder_SelectedIndexChanged(object sender, EventArgs e) => btnSearch_Click(null, null);
    }
}
