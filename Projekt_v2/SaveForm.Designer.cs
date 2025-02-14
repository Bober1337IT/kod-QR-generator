namespace Projekt_v2
{
    partial class SaveData
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
            this.btnSaveTxt = new System.Windows.Forms.Button();
            this.btnSavePng = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveTxt
            // 
            this.btnSaveTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveTxt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSaveTxt.Location = new System.Drawing.Point(10, 11);
            this.btnSaveTxt.Name = "btnSaveTxt";
            this.btnSaveTxt.Size = new System.Drawing.Size(111, 50);
            this.btnSaveTxt.TabIndex = 5;
            this.btnSaveTxt.Text = "Zapisz link";
            this.btnSaveTxt.UseVisualStyleBackColor = true;
            this.btnSaveTxt.Click += new System.EventHandler(this.btnSaveTxt_Click);
            // 
            // btnSavePng
            // 
            this.btnSavePng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePng.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSavePng.Location = new System.Drawing.Point(127, 10);
            this.btnSavePng.Name = "btnSavePng";
            this.btnSavePng.Size = new System.Drawing.Size(111, 51);
            this.btnSavePng.TabIndex = 6;
            this.btnSavePng.Text = "Zapisz kod QR";
            this.btnSavePng.UseVisualStyleBackColor = true;
            this.btnSavePng.Click += new System.EventHandler(this.btnSavePng_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.Location = new System.Drawing.Point(72, 67);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 37);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Zamknij";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // SaveData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 119);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSavePng);
            this.Controls.Add(this.btnSaveTxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SaveData";
            this.Text = "Zapisywanie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveTxt;
        private System.Windows.Forms.Button btnSavePng;
        private System.Windows.Forms.Button btnClose;
    }
}