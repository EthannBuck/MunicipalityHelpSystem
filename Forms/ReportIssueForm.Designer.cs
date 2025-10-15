using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormApp1
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader;
        private Label lblLocation;
        private TextBox txtLocation;
        private Label lblCategory;
        private ComboBox comboBoxCategory;
        private Label lblDescription;
        private RichTextBox richTextBoxDescription;
        private Button btnAttachMedia;
        private Label lblAttachment;
        private Button btnSubmit;
        private ProgressBar progressBarEngagement;
        private Button btnBack;
        private Panel panelInputs;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeader = new Label();
            this.panelInputs = new Panel();
            this.lblLocation = new Label();
            this.txtLocation = new TextBox();
            this.lblCategory = new Label();
            this.comboBoxCategory = new ComboBox();
            this.lblDescription = new Label();
            this.richTextBoxDescription = new RichTextBox();
            this.btnAttachMedia = new Button();
            this.lblAttachment = new Label();
            this.btnSubmit = new Button();
            this.progressBarEngagement = new ProgressBar();
            this.btnBack = new Button();

            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 255);

            // lblHeader
            this.lblHeader.Text = "Report an Issue";
            this.lblHeader.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.lblHeader.ForeColor = Color.FromArgb(0, 51, 102); // Dark blue like Events page
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new Point(20, 20);

            // panelInputs
            this.panelInputs.Location = new Point(20, 60);
            this.panelInputs.Size = new Size(600, 350);
            this.panelInputs.BackColor = Color.White;

            // lblLocation
            this.lblLocation.Text = "Location:";
            this.lblLocation.Location = new Point(10, 10);
            this.lblLocation.AutoSize = true;

            // txtLocation
            this.txtLocation.Location = new Point(120, 7);
            this.txtLocation.Size = new Size(400, 25);

            // lblCategory
            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new Point(10, 50);
            this.lblCategory.AutoSize = true;

            // comboBoxCategory
            this.comboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxCategory.Location = new Point(120, 47);
            this.comboBoxCategory.Size = new Size(200, 25);

            // lblDescription
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new Point(10, 90);
            this.lblDescription.AutoSize = true;

            // richTextBoxDescription
            this.richTextBoxDescription.Location = new Point(120, 87);
            this.richTextBoxDescription.Size = new Size(400, 100);

            // btnAttachMedia
            this.btnAttachMedia.Text = "Attach Media";
            this.btnAttachMedia.Location = new Point(120, 200);
            this.btnAttachMedia.Size = new Size(120, 30);
            this.btnAttachMedia.BackColor = Color.FromArgb(0, 102, 204); // Blue
            this.btnAttachMedia.ForeColor = Color.White;
            this.btnAttachMedia.FlatStyle = FlatStyle.Flat;
            this.btnAttachMedia.Click += new EventHandler(this.btnAttachMedia_Click);

            // lblAttachment
            this.lblAttachment.Text = "No file attached";
            this.lblAttachment.Location = new Point(260, 208);
            this.lblAttachment.AutoSize = true;

            // btnSubmit
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.Location = new Point(120, 250);
            this.btnSubmit.Size = new Size(120, 35);
            this.btnSubmit.BackColor = Color.FromArgb(0, 153, 0); 
            this.btnSubmit.ForeColor = Color.White;
            this.btnSubmit.FlatStyle = FlatStyle.Flat;
            this.btnSubmit.Click += new EventHandler(this.btnSubmit_Click);

            // btnBack
            this.btnBack.Text = "Back";
            this.btnBack.Location = new Point(260, 250);
            this.btnBack.Size = new Size(120, 35);
            this.btnBack.BackColor = Color.FromArgb(204, 0, 0);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // progressBarEngagement
            this.progressBarEngagement.Location = new Point(120, 300);
            this.progressBarEngagement.Size = new Size(400, 25);

            // Add controls to panel
            this.panelInputs.Controls.Add(this.lblLocation);
            this.panelInputs.Controls.Add(this.txtLocation);
            this.panelInputs.Controls.Add(this.lblCategory);
            this.panelInputs.Controls.Add(this.comboBoxCategory);
            this.panelInputs.Controls.Add(this.lblDescription);
            this.panelInputs.Controls.Add(this.richTextBoxDescription);
            this.panelInputs.Controls.Add(this.btnAttachMedia);
            this.panelInputs.Controls.Add(this.lblAttachment);
            this.panelInputs.Controls.Add(this.btnSubmit);
            this.panelInputs.Controls.Add(this.btnBack);
            this.panelInputs.Controls.Add(this.progressBarEngagement);

            // Form
            this.ClientSize = new Size(650, 450);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.panelInputs);
            this.Text = "Report an Issue";
            this.Load += new EventHandler(this.ReportIssueForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}