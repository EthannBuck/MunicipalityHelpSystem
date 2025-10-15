using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Form styling
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ClientSize = new Size(1280, 720);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Style nav buttons consistently
            StyleNavButton(navReportBtn);
            StyleNavButton(navEventsBtn);
            StyleNavButton(navStatusBtn);

            // Disable buttons not implemented yet
            // navEventsBtn.Enabled = false;
            navStatusBtn.Enabled = false;

            // Show welcome screen initially
            ShowWelcomeScreen();
        }

        // Apply consistent styling and hover effects to nav buttons
        private void StyleNavButton(Button btn)
        {
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(30, 30, 30);
            btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(230, 236, 250); };
            btn.MouseLeave += (s, e) => { btn.BackColor = Color.Transparent; };
        }

        // Navigation button click handlers
        private void navReportBtn_Click(object sender, EventArgs e) => LoadReportFormInContent();
        private void navEventsBtn_Click(object sender, EventArgs e) => LoadEventsInContent();
        private void navStatusBtn_Click(object sender, EventArgs e) => LoadStatusInContent();

        // Show welcome screen in content panel
        public void ShowWelcomeScreen()
        {
            contentPanel.Controls.Clear();

            var panel = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White, AutoScroll = true };

            var title = new Label()
            {
                Text = "Welcome to the Municipality Help System",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(20, 20, 20, 0),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var subtitle = new Label()
            {
                Text = "Here you can report issues, view upcoming events, or check the status of service requests.\n\n"
                     + "Stay informed with important notices and announcements below.",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(20, 0, 20, 0)
            };

            // Example announcements
            string[] announcements = new string[]
            {
        "📢 Water supply maintenance will take place on 15 Sept from 10:00–14:00. Some areas may experience interruptions.",
        "📢 Road repairs on Main Street starting 18 Sept. Expect temporary diversions.",
        "📢 Electricity maintenance in the northern suburbs on 20 Sept from 09:00–12:00.",
        "📢 Community meeting on 22 Sept at the town hall, 18:00–20:00.",
        "📢 Waste collection schedule changes in certain areas for 25 Sept."
            };

            // Add each announcement as an infoBox-style Label
            foreach (var ann in announcements)
            {
                var infoBox = new Label()
                {
                    Text = ann,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    Dock = DockStyle.Top,
                    Height = 80,
                    Padding = new Padding(20, 10, 20, 10),
                    BackColor = Color.FromArgb(240, 248, 255),
                    AutoSize = false
                };
                panel.Controls.Add(infoBox);
            }

            // Add subtitle and title at the top
            panel.Controls.Add(subtitle);
            panel.Controls.Add(title);

            contentPanel.Controls.Add(panel);
        }


        // Load ReportIssueForm into content panel
        private void LoadReportFormInContent()
        {
            var r = new ReportIssueForm(this);  // pass parent reference
            ShowFormInContent(r);
        }

        private void LoadEventsInContent()
        {
            var eventsForm = new LocalEventsForm(this);
            ShowFormInContent(eventsForm);
        }


        // Placeholder for service status content
        private void LoadStatusInContent()
        {
            var p = new Panel() { Dock = DockStyle.Fill, BackColor = Color.White };
            var lbl = new Label()
            {
                Text = "Service Request Status\n(placeholder content)",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            p.Controls.Add(lbl);
            ShowControlInContent(p);
        }

        // Helper to embed a Form into contentPanel
        private void ShowFormInContent(Form f)
        {
            contentPanel.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(f);
            f.Show();
        }

        // Helper to embed any Control into contentPanel
        private void ShowControlInContent(Control c)
        {
            contentPanel.Controls.Clear();
            c.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(c);
        }
    }
}
