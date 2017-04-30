namespace WinRecomendationSystem
{
    partial class FrmShowTicket
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxLocalization = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLike = new System.Windows.Forms.Button();
            this.btnDontLike = new System.Windows.Forms.Button();
            this.bntNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.Location = new System.Drawing.Point(12, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxTitle.TabIndex = 0;
            // 
            // textBoxLocalization
            // 
            this.textBoxLocalization.Location = new System.Drawing.Point(12, 38);
            this.textBoxLocalization.Name = "textBoxLocalization";
            this.textBoxLocalization.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocalization.TabIndex = 1;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Location = new System.Drawing.Point(12, 64);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(100, 20);
            this.textBoxDate.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(415, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnLike
            // 
            this.btnLike.Location = new System.Drawing.Point(12, 334);
            this.btnLike.Name = "btnLike";
            this.btnLike.Size = new System.Drawing.Size(75, 23);
            this.btnLike.TabIndex = 4;
            this.btnLike.Text = "Like";
            this.btnLike.UseVisualStyleBackColor = true;
            this.btnLike.Click += new System.EventHandler(this.btnLike_Click);
            // 
            // btnDontLike
            // 
            this.btnDontLike.Location = new System.Drawing.Point(93, 334);
            this.btnDontLike.Name = "btnDontLike";
            this.btnDontLike.Size = new System.Drawing.Size(75, 23);
            this.btnDontLike.TabIndex = 5;
            this.btnDontLike.Text = "Dont Like";
            this.btnDontLike.UseVisualStyleBackColor = true;
            this.btnDontLike.Click += new System.EventHandler(this.btnDontLike_Click);
            // 
            // bntNormal
            // 
            this.bntNormal.Location = new System.Drawing.Point(174, 334);
            this.bntNormal.Name = "bntNormal";
            this.bntNormal.Size = new System.Drawing.Size(75, 23);
            this.bntNormal.TabIndex = 6;
            this.bntNormal.Text = "Normal";
            this.bntNormal.UseVisualStyleBackColor = true;
            this.bntNormal.Click += new System.EventHandler(this.bntNormal_Click);
            // 
            // FrmShowTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 369);
            this.Controls.Add(this.bntNormal);
            this.Controls.Add(this.btnDontLike);
            this.Controls.Add(this.btnLike);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxLocalization);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "FrmShowTicket";
            this.Text = "FrmShowTicket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxLocalization;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLike;
        private System.Windows.Forms.Button btnDontLike;
        private System.Windows.Forms.Button bntNormal;
    }
}