using System.Drawing;

namespace WindowsFormApp1
{
    partial class LocalEventsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblRecommendations;
        private System.Windows.Forms.ListBox lstRecommendations;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbSortBy;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblQueueCount;
        private System.Windows.Forms.Button btnProcessSubmissions;
        private System.Windows.Forms.TextBox txtNewTitle;
        private System.Windows.Forms.TextBox txtNewCategory;
        private System.Windows.Forms.DateTimePicker dtNewDate;
        private System.Windows.Forms.TextBox txtNewDesc;
        private System.Windows.Forms.Button btnSubmitEvent;
        private System.Windows.Forms.ListBox lstLastViewed;
        private System.Windows.Forms.Label lblLastViewed;
        private System.Windows.Forms.Label lblSearchHint;
        private System.Windows.Forms.Label lblNewTitleHint;
        private System.Windows.Forms.Label lblNewCatHint;
        private System.Windows.Forms.Label lblNewDescHint;
        private System.Windows.Forms.CheckBox chkUseDate;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.chkUseDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblRecommendations = new System.Windows.Forms.Label();
            this.lstRecommendations = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbSortBy = new System.Windows.Forms.ComboBox();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblQueueCount = new System.Windows.Forms.Label();
            this.btnProcessSubmissions = new System.Windows.Forms.Button();
            this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.txtNewCategory = new System.Windows.Forms.TextBox();
            this.dtNewDate = new System.Windows.Forms.DateTimePicker();
            this.txtNewDesc = new System.Windows.Forms.TextBox();
            this.btnSubmitEvent = new System.Windows.Forms.Button();
            this.lstLastViewed = new System.Windows.Forms.ListBox();
            this.lblLastViewed = new System.Windows.Forms.Label();

            this.lblSearchHint = new System.Windows.Forms.Label();
            this.lblNewTitleHint = new System.Windows.Forms.Label();
            this.lblNewCatHint = new System.Windows.Forms.Label();
            this.lblNewDescHint = new System.Windows.Forms.Label();

            this.SuspendLayout();
            // 
            // Form layout
            // 
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Text = "Local Events and Announcements";
            this.Load += new System.EventHandler(this.LocalEventsForm_Load);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Local Events and Announcements";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(40, 60, 110);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.AutoSize = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(20, 60);
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.TextChanged += (s, e) => { lblSearchHint.Visible = string.IsNullOrWhiteSpace(txtSearch.Text); };
            this.txtSearch.GotFocus += (s, e) => lblSearchHint.Visible = false;
            this.txtSearch.LostFocus += (s, e) => { lblSearchHint.Visible = string.IsNullOrWhiteSpace(txtSearch.Text); };
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblSearchHint
            // 
            this.lblSearchHint.Text = "Enter keyword...";
            this.lblSearchHint.ForeColor = System.Drawing.Color.Gray;
            this.lblSearchHint.Location = new System.Drawing.Point(28, 64);
            this.lblSearchHint.AutoSize = true;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(230, 60);
            this.cmbCategory.Size = new System.Drawing.Size(160, 25);
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(400, 60);
            this.dtDate.Size = new System.Drawing.Size(140, 25);
            // 
            // cmbSortBy
            // 
            this.cmbSortBy.Location = new System.Drawing.Point(550, 60);
            this.cmbSortBy.Size = new System.Drawing.Size(120, 25);
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.Location = new System.Drawing.Point(680, 60);
            this.cmbSortOrder.Size = new System.Drawing.Size(110, 25);
            // 
            // chkUseDate
            // 
            this.chkUseDate.Text = "Use Date Filter";
            this.chkUseDate.Location = new System.Drawing.Point(550, 90); // adjust if needed
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Checked = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(800, 60);
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.Text = "Search";
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(70, 130, 230);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstEvents
            // 
            this.lstEvents.Location = new System.Drawing.Point(20, 100);
            this.lstEvents.Size = new System.Drawing.Size(640, 200);
            this.lstEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            // 
            // lblRecommendations
            // 
            this.lblRecommendations.Text = "Recommended Events:";
            this.lblRecommendations.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecommendations.Location = new System.Drawing.Point(20, 310);
            this.lblRecommendations.AutoSize = true;
            // 
            // lstRecommendations
            // 
            this.lstRecommendations.Location = new System.Drawing.Point(20, 330);
            this.lstRecommendations.Size = new System.Drawing.Size(640, 100);
            this.lstRecommendations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblLastViewed
            // 
            this.lblLastViewed.Text = "Last Viewed:";
            this.lblLastViewed.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLastViewed.Location = new System.Drawing.Point(680, 100);
            this.lblLastViewed.AutoSize = true;
            // 
            // lstLastViewed
            // 
            this.lstLastViewed.Location = new System.Drawing.Point(680, 120);
            this.lstLastViewed.Size = new System.Drawing.Size(320, 90);
            this.lstLastViewed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // Submission area heading
            // 
            var lblAddEvent = new System.Windows.Forms.Label();
            lblAddEvent.Text = "Submit New Event";
            lblAddEvent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblAddEvent.Location = new System.Drawing.Point(680, 220);
            lblAddEvent.AutoSize = true;
            this.Controls.Add(lblAddEvent);
            // 
            // txtNewTitle
            // 
            this.txtNewTitle.Location = new System.Drawing.Point(680, 250);
            this.txtNewTitle.Size = new System.Drawing.Size(320, 25);
            this.txtNewTitle.TextChanged += (s, e) => { lblNewTitleHint.Visible = string.IsNullOrWhiteSpace(txtNewTitle.Text); };
            this.txtNewTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblNewTitleHint
            // 
            this.lblNewTitleHint.Text = "Event title...";
            this.lblNewTitleHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewTitleHint.Location = new System.Drawing.Point(688, 254);
            this.lblNewTitleHint.AutoSize = true;
            // 
            // txtNewCategory
            // 
            this.txtNewCategory.Location = new System.Drawing.Point(680, 280);
            this.txtNewCategory.Size = new System.Drawing.Size(160, 25);
            this.txtNewCategory.TextChanged += (s, e) => { lblNewCatHint.Visible = string.IsNullOrWhiteSpace(txtNewCategory.Text); };
            this.txtNewCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblNewCatHint
            // 
            this.lblNewCatHint.Text = "Category...";
            this.lblNewCatHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewCatHint.Location = new System.Drawing.Point(688, 284);
            this.lblNewCatHint.AutoSize = true;
            // 
            // dtNewDate
            // 
            this.dtNewDate.Location = new System.Drawing.Point(850, 280);
            this.dtNewDate.Size = new System.Drawing.Size(150, 25);
            // 
            // txtNewDesc
            // 
            this.txtNewDesc.Location = new System.Drawing.Point(680, 310);
            this.txtNewDesc.Size = new System.Drawing.Size(320, 60);
            this.txtNewDesc.Multiline = true;
            this.txtNewDesc.TextChanged += (s, e) => { lblNewDescHint.Visible = string.IsNullOrWhiteSpace(txtNewDesc.Text); };
            this.txtNewDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // lblNewDescHint
            // 
            this.lblNewDescHint.Text = "Description...";
            this.lblNewDescHint.ForeColor = System.Drawing.Color.Gray;
            this.lblNewDescHint.Location = new System.Drawing.Point(688, 314);
            this.lblNewDescHint.AutoSize = true;
            // 
            // btnSubmitEvent
            // 
            this.btnSubmitEvent.Location = new System.Drawing.Point(680, 380);
            this.btnSubmitEvent.Size = new System.Drawing.Size(150, 30);
            this.btnSubmitEvent.Text = "Submit (Queue)";
            this.btnSubmitEvent.BackColor = System.Drawing.Color.FromArgb(92, 184, 92);
            this.btnSubmitEvent.ForeColor = System.Drawing.Color.White;
            this.btnSubmitEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitEvent.Click += new System.EventHandler(this.btnSubmitEvent_Click);
            // 
            // btnProcessSubmissions
            // 
            this.btnProcessSubmissions.Location = new System.Drawing.Point(840, 380);
            this.btnProcessSubmissions.Size = new System.Drawing.Size(160, 30);
            this.btnProcessSubmissions.Text = "Process Submissions";
            this.btnProcessSubmissions.BackColor = System.Drawing.Color.FromArgb(91, 155, 213);
            this.btnProcessSubmissions.ForeColor = System.Drawing.Color.White;
            this.btnProcessSubmissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessSubmissions.Click += new System.EventHandler(this.btnProcessSubmissions_Click);
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.Location = new System.Drawing.Point(680, 420);
            this.lblQueueCount.Size = new System.Drawing.Size(320, 20);
            this.lblQueueCount.Text = "Pending submissions: 0";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(20, 460);
            this.btnBack.Size = new System.Drawing.Size(100, 30);
            this.btnBack.Text = "Back";
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.BackColor = Color.FromArgb(204, 0, 0);
            this.btnBack.ForeColor = Color.White;
            // 
            // Add controls
            // 
            this.Controls.Add(this.chkUseDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearchHint);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.cmbSortBy);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.lblLastViewed);
            this.Controls.Add(this.lstLastViewed);
            this.Controls.Add(this.txtNewTitle);
            this.Controls.Add(this.lblNewTitleHint);
            this.Controls.Add(this.txtNewCategory);
            this.Controls.Add(this.lblNewCatHint);
            this.Controls.Add(this.dtNewDate);
            this.Controls.Add(this.txtNewDesc);
            this.Controls.Add(this.lblNewDescHint);
            this.Controls.Add(this.btnSubmitEvent);
            this.Controls.Add(this.btnProcessSubmissions);
            this.Controls.Add(this.lblQueueCount);
            this.Controls.Add(this.btnBack);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
