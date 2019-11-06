namespace WindowsFormsApplication1
{
    partial class tela
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
            this.imagem = new System.Windows.Forms.PictureBox();
            this.painel = new System.Windows.Forms.Panel();
            this.btn_Bz_Cub = new System.Windows.Forms.Button();
            this.btn_Bz_Quad = new System.Windows.Forms.Button();
            this.btApagar = new System.Windows.Forms.Button();
            this.btCor = new System.Windows.Forms.Button();
            this.cdlg = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.painel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagem
            // 
            this.imagem.BackColor = System.Drawing.Color.White;
            this.imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagem.Location = new System.Drawing.Point(0, 0);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(1014, 562);
            this.imagem.TabIndex = 0;
            this.imagem.TabStop = false;
            this.imagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Imagem_Click);
            // 
            // painel
            // 
            this.painel.Controls.Add(this.btn_Bz_Cub);
            this.painel.Controls.Add(this.btn_Bz_Quad);
            this.painel.Controls.Add(this.btApagar);
            this.painel.Controls.Add(this.btCor);
            this.painel.Dock = System.Windows.Forms.DockStyle.Right;
            this.painel.Location = new System.Drawing.Point(798, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(216, 562);
            this.painel.TabIndex = 1;
            // 
            // btn_Bz_Cub
            // 
            this.btn_Bz_Cub.Location = new System.Drawing.Point(3, 41);
            this.btn_Bz_Cub.Name = "btn_Bz_Cub";
            this.btn_Bz_Cub.Size = new System.Drawing.Size(210, 23);
            this.btn_Bz_Cub.TabIndex = 8;
            this.btn_Bz_Cub.Text = "Bezier Cubica";
            this.btn_Bz_Cub.UseVisualStyleBackColor = true;
            this.btn_Bz_Cub.Click += new System.EventHandler(this.btn_Bz_Cub_Click);
            // 
            // btn_Bz_Quad
            // 
            this.btn_Bz_Quad.Location = new System.Drawing.Point(3, 12);
            this.btn_Bz_Quad.Name = "btn_Bz_Quad";
            this.btn_Bz_Quad.Size = new System.Drawing.Size(210, 23);
            this.btn_Bz_Quad.TabIndex = 7;
            this.btn_Bz_Quad.Text = "Bezier Quadratica";
            this.btn_Bz_Quad.UseVisualStyleBackColor = true;
            this.btn_Bz_Quad.Click += new System.EventHandler(this.btn_Bz_Quad_Click);
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(112, 70);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(75, 23);
            this.btApagar.TabIndex = 6;
            this.btApagar.Text = "Apagar";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.BtApagar_Click);
            // 
            // btCor
            // 
            this.btCor.Location = new System.Drawing.Point(31, 70);
            this.btCor.Name = "btCor";
            this.btCor.Size = new System.Drawing.Size(75, 23);
            this.btCor.TabIndex = 5;
            this.btCor.Text = "Cor";
            this.btCor.UseVisualStyleBackColor = true;
            this.btCor.Click += new System.EventHandler(this.BtCor_Click);
            // 
            // tela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 562);
            this.Controls.Add(this.painel);
            this.Controls.Add(this.imagem);
            this.Name = "tela";
            this.Text = "Manipulação Imagem";
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.painel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.Button btApagar;
        private System.Windows.Forms.Button btCor;
        private System.Windows.Forms.ColorDialog cdlg;
        private System.Windows.Forms.Button btn_Bz_Quad;
        private System.Windows.Forms.Button btn_Bz_Cub;
    }
}

