
namespace Sandbox.WinForms
{
    partial class Form2
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
            this.leafletView1 = new LeafletDotNet.WinForms.LeafletView();
            this.SuspendLayout();
            // 
            // leafletView1
            // 
            this.leafletView1.Location = new System.Drawing.Point(12, 12);
            this.leafletView1.Name = "leafletView1";
            this.leafletView1.Size = new System.Drawing.Size(776, 426);
            this.leafletView1.TabIndex = 0;
            this.leafletView1.Text = "leafletView1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leafletView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private LeafletDotNet.WinForms.LeafletView leafletView1;
    }
}