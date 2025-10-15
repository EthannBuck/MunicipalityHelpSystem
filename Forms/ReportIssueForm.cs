using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class ReportIssueForm : Form
    {
        private string _attachedFilePath;
        private Form1 _parentForm;

        public ReportIssueForm(Form1 parent)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(248, 250, 255);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ForeColor = Color.Black;

            _parentForm = parent;
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(248, 250, 255);
            // Populate category dropdown
            comboBoxCategory.Items.Clear();
            foreach (var cat in IssueRepository.ByCategory.CategoriesInOrder())
                comboBoxCategory.Items.Add(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cat));

            if (comboBoxCategory.Items.Count == 0)
                comboBoxCategory.Items.AddRange(new object[] { "Roads", "Water", "Electricity", "Sanitation", "Other" });

            comboBoxCategory.SelectedIndex = 0;

            // Add placeholders
            SetPlaceholders();

            // Initialize dynamic progress bar
            txtLocation.TextChanged += (s, ev) => UpdateProgressBarDynamic();
            richTextBoxDescription.TextChanged += (s, ev) => UpdateProgressBarDynamic();
            comboBoxCategory.SelectedIndexChanged += (s, ev) => UpdateProgressBarDynamic();
            btnAttachMedia.Click += (s, ev) => UpdateProgressBarDynamic();

            UpdateProgressBarDynamic();
        }

        private void SetPlaceholders()
        {
            // Location placeholder
            txtLocation.ForeColor = Color.Gray;
            txtLocation.Text = "Enter location of the issue...";
            txtLocation.Enter += (s, e) => {
                if (txtLocation.Text == "Enter location of the issue...")
                {
                    txtLocation.Text = "";
                    txtLocation.ForeColor = Color.Black;
                }
            };
            txtLocation.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(txtLocation.Text))
                {
                    txtLocation.Text = "Enter location of the issue...";
                    txtLocation.ForeColor = Color.Gray;
                }
            };

            // Description placeholder
            richTextBoxDescription.ForeColor = Color.Gray;
            richTextBoxDescription.Text = "Describe the issue in detail...";
            richTextBoxDescription.Enter += (s, e) => {
                if (richTextBoxDescription.Text == "Describe the issue in detail...")
                {
                    richTextBoxDescription.Text = "";
                    richTextBoxDescription.ForeColor = Color.Black;
                }
            };
            richTextBoxDescription.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(richTextBoxDescription.Text))
                {
                    richTextBoxDescription.Text = "Describe the issue in detail...";
                    richTextBoxDescription.ForeColor = Color.Gray;
                }
            };
        }

        private void btnAttachMedia_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images and Video|*.jpg;*.jpeg;*.png;*.bmp;*.mp4;*.mov|All files|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _attachedFilePath = dlg.FileName;
                    lblAttachment.Text = Path.GetFileName(_attachedFilePath);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var location = txtLocation.Text?.Trim();
            var category = (comboBoxCategory.SelectedItem ?? "").ToString().Trim();
            var description = richTextBoxDescription.Text?.Trim();

            if (string.IsNullOrEmpty(location) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please complete Location, Category and Description before submitting.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var issue = new IssueReport()
            {
                Location = location,
                Category = category,
                Description = description,
                MediaPath = _attachedFilePath,
                SubmittedAt = DateTime.Now
            };

            IssueRepository.Add(issue);

            MessageBox.Show("Your issue has been submitted. Thank you.", "Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtLocation.Text = "";
            richTextBoxDescription.Text = "";
            _attachedFilePath = null;
            lblAttachment.Text = "No file attached";

            progressBarEngagement.Value = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _parentForm.ShowWelcomeScreen();
        }

        private void UpdateProgressBarDynamic()
        {
            int progress = 0;

            // Location field filled (ignore placeholder)
            if (!string.IsNullOrWhiteSpace(txtLocation.Text) && txtLocation.ForeColor != Color.Gray)
                progress++;

            // Description field filled (ignore placeholder)
            if (!string.IsNullOrWhiteSpace(richTextBoxDescription.Text) && richTextBoxDescription.ForeColor != Color.Gray)
                progress++;

            // Category selected by user (ignore placeholder)
            // Assume placeholder is at index 0
            if (comboBoxCategory.SelectedIndex > 0)
                progress++;

            // Media attached
            if (!string.IsNullOrEmpty(_attachedFilePath))
                progress++;

            // ProgressBar max = 4
            progressBarEngagement.Maximum = 4;
            progressBarEngagement.Value = progress;
        }


    }
}