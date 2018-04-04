namespace KidTrackingWindows
{
    partial class KidTracker
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.Signou = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(23, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(752, 467);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://localhost:2607", System.UriKind.Absolute);
            // 
            // Signou
            // 
            this.Signou.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signou.Location = new System.Drawing.Point(349, 502);
            this.Signou.Name = "Signou";
            this.Signou.Size = new System.Drawing.Size(121, 33);
            this.Signou.TabIndex = 1;
            this.Signou.Text = "Signout";
            this.Signou.UseVisualStyleBackColor = true;
            this.Signou.Click += new System.EventHandler(this.button1_Click);
            // 
            // KidTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 558);
            this.Controls.Add(this.Signou);
            this.Controls.Add(this.webBrowser1);
            this.Name = "KidTracker";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button Signou;
    }
}

