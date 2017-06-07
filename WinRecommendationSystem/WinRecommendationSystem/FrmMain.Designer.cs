namespace WinRecomendationSystem
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView = new System.Windows.Forms.ListView();
            this.EventTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventLocalization = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShow = new System.Windows.Forms.Button();
            this.bntShowRecomendation = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EventTitle,
            this.EventCategory,
            this.EventLocalization,
            this.EventDate});
            this.listView.Dock = System.Windows.Forms.DockStyle.Left;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(454, 470);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // EventTitle
            // 
            this.EventTitle.Text = "Title";
            // 
            // EventCategory
            // 
            this.EventCategory.Text = "Category";
            this.EventCategory.Width = 105;
            // 
            // EventLocalization
            // 
            this.EventLocalization.Text = "Localization";
            this.EventLocalization.Width = 124;
            // 
            // EventDate
            // 
            this.EventDate.Text = "Date";
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(460, 12);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(179, 39);
            this.btnShow.TabIndex = 1;
            this.btnShow.Text = "Show Ticket";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // bntShowRecomendation
            // 
            this.bntShowRecomendation.Location = new System.Drawing.Point(645, 12);
            this.bntShowRecomendation.Name = "bntShowRecomendation";
            this.bntShowRecomendation.Size = new System.Drawing.Size(197, 39);
            this.bntShowRecomendation.TabIndex = 2;
            this.bntShowRecomendation.Text = "Show Recomendation";
            this.bntShowRecomendation.UseVisualStyleBackColor = true;
            this.bntShowRecomendation.Click += new System.EventHandler(this.bntShowRecomendation_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(460, 57);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 413);
            this.textBox1.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 470);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bntShowRecomendation);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnShow);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader EventCategory;
        private System.Windows.Forms.ColumnHeader EventLocalization;
        private System.Windows.Forms.ColumnHeader EventTitle;
        private System.Windows.Forms.ColumnHeader EventDate;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button bntShowRecomendation;
        private System.Windows.Forms.TextBox textBox1;
    }
}

