namespace WindowsFormApp1
{
    partial class Form1
    {
        // Designer fields
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel navPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel footerPanel;

        private System.Windows.Forms.Button navReportBtn;
        private System.Windows.Forms.Button navEventsBtn;
        private System.Windows.Forms.Button navStatusBtn;
        private System.Windows.Forms.Label headerTitle;
        private System.Windows.Forms.Label footerLabel;

        // Dispose resources properly
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        // Initialize all UI controls and layout
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerTitle = new System.Windows.Forms.Label();
            this.navPanel = new System.Windows.Forms.Panel();
            this.navReportBtn = new System.Windows.Forms.Button();
            this.navEventsBtn = new System.Windows.Forms.Button();
            this.navStatusBtn = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.footerPanel = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // headerPanel: top banner
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 70;
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(25, 42, 86);
            this.headerPanel.Controls.Add(this.headerTitle);

            // headerTitle: title label
            this.headerTitle.AutoSize = false;
            this.headerTitle.Text = "Municipality Help System";
            this.headerTitle.ForeColor = System.Drawing.Color.White;
            this.headerTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.headerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.headerTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);

            // navPanel: left navigation
            this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.navPanel.Width = 220;
            this.navPanel.BackColor = System.Drawing.Color.FromArgb(240, 243, 250);
            this.navPanel.Padding = new System.Windows.Forms.Padding(10);

            // nav buttons: report, events, status
            this.navReportBtn.Name = "navReportBtn";
            this.navReportBtn.Text = "Report an Issue";
            this.navReportBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.navReportBtn.Height = 55;
            this.navReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navReportBtn.FlatAppearance.BorderSize = 0;
            this.navReportBtn.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.navReportBtn.Click += new System.EventHandler(this.navReportBtn_Click);

            this.navEventsBtn.Name = "navEventsBtn";
            this.navEventsBtn.Text = "Events and Announcements";
            this.navEventsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.navEventsBtn.Height = 55;
            this.navEventsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navEventsBtn.FlatAppearance.BorderSize = 0;
            this.navEventsBtn.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.navEventsBtn.Click += new System.EventHandler(this.navEventsBtn_Click);

            this.navStatusBtn.Name = "navStatusBtn";
            this.navStatusBtn.Text = "Service Request Status";
            this.navStatusBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.navStatusBtn.Height = 55;
            this.navStatusBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.navStatusBtn.FlatAppearance.BorderSize = 0;
            this.navStatusBtn.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.navStatusBtn.Click += new System.EventHandler(this.navStatusBtn_Click);

            // Add nav buttons to navPanel
            this.navPanel.Controls.Add(this.navStatusBtn);
            this.navPanel.Controls.Add(this.navEventsBtn);
            this.navPanel.Controls.Add(this.navReportBtn);

            // contentPanel: main content area
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(225, 245, 255);

            // footerPanel
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.Height = 30;
            this.footerPanel.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.footerPanel.Controls.Add(this.footerLabel);

            // footerLabel
            this.footerLabel.Text = "© 2025 Municipality Help System";
            this.footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Form1: main form settings
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.navPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.footerPanel);
            this.Name = "Form1";
            this.Text = "Municipality Help System";
            this.Load += new System.EventHandler(this.Form1_Load);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
