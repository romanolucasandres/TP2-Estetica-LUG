namespace Presentacion
{
    partial class Login
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
            this.emailPass1 = new Presentacion.EmailPass();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // emailPass1
            // 
            this.emailPass1.Location = new System.Drawing.Point(10, 48);
            this.emailPass1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailPass1.Name = "emailPass1";
            this.emailPass1.Size = new System.Drawing.Size(318, 147);
            this.emailPass1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email: adm@adm.com\r\nContraseña: 123456";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 206);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailPass1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EmailPass emailPass1;
        private System.Windows.Forms.Label label1;
    }
}