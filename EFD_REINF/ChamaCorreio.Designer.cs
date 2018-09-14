namespace EFD_REINF
{
    partial class ChamaCorreio
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
            this.btn_chamar = new System.Windows.Forms.Button();
            this.txt_texto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_chamar
            // 
            this.btn_chamar.Location = new System.Drawing.Point(137, 118);
            this.btn_chamar.Name = "btn_chamar";
            this.btn_chamar.Size = new System.Drawing.Size(135, 24);
            this.btn_chamar.TabIndex = 4;
            this.btn_chamar.Text = "Chama WebService";
            this.btn_chamar.UseVisualStyleBackColor = true;
            this.btn_chamar.Click += new System.EventHandler(this.btn_chamar_Click);
            // 
            // txt_texto
            // 
            this.txt_texto.Location = new System.Drawing.Point(13, 122);
            this.txt_texto.Name = "txt_texto";
            this.txt_texto.Size = new System.Drawing.Size(100, 20);
            this.txt_texto.TabIndex = 3;
            // 
            // ChamaCorreio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 242);
            this.Controls.Add(this.btn_chamar);
            this.Controls.Add(this.txt_texto);
            this.Name = "ChamaCorreio";
            this.Text = "Correios";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_chamar;
        private System.Windows.Forms.TextBox txt_texto;

    }
}