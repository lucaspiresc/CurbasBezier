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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cub_y4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Bz_Cub = new System.Windows.Forms.Button();
            this.cub_x4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cub_y3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cub_y2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cub_y1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cub_x3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cub_x2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cub_x1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.quad_y3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.quad_y2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.quad_y1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.quad_x3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.quad_x2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.quad_x1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Bz_Quad = new System.Windows.Forms.Button();
            this.btApagar = new System.Windows.Forms.Button();
            this.btCor = new System.Windows.Forms.Button();
            this.cdlg = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.painel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.painel.Controls.Add(this.groupBox2);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Controls.Add(this.btApagar);
            this.painel.Controls.Add(this.btCor);
            this.painel.Dock = System.Windows.Forms.DockStyle.Right;
            this.painel.Location = new System.Drawing.Point(798, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(216, 562);
            this.painel.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.cub_y4);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btn_Bz_Cub);
            this.groupBox2.Controls.Add(this.cub_x4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cub_y3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cub_y2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cub_y1);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cub_x3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cub_x2);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cub_x1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(4, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 231);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Curva Bezier Cub.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Desenhar Curva";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cub_y4
            // 
            this.cub_y4.Location = new System.Drawing.Point(130, 131);
            this.cub_y4.Name = "cub_y4";
            this.cub_y4.Size = new System.Drawing.Size(53, 20);
            this.cub_y4.TabIndex = 23;
            this.cub_y4.TextChanged += new System.EventHandler(this.cub_y4_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(106, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "y4";
            // 
            // btn_Bz_Cub
            // 
            this.btn_Bz_Cub.Location = new System.Drawing.Point(5, 167);
            this.btn_Bz_Cub.Name = "btn_Bz_Cub";
            this.btn_Bz_Cub.Size = new System.Drawing.Size(198, 23);
            this.btn_Bz_Cub.TabIndex = 8;
            this.btn_Bz_Cub.Text = "Bezier Cubica";
            this.btn_Bz_Cub.UseVisualStyleBackColor = true;
            this.btn_Bz_Cub.Click += new System.EventHandler(this.btn_Bz_Cub_Click);
            // 
            // cub_x4
            // 
            this.cub_x4.Location = new System.Drawing.Point(32, 131);
            this.cub_x4.Name = "cub_x4";
            this.cub_x4.Size = new System.Drawing.Size(53, 20);
            this.cub_x4.TabIndex = 21;
            this.cub_x4.TextChanged += new System.EventHandler(this.cub_x4_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 134);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(18, 13);
            this.label14.TabIndex = 20;
            this.label14.Text = "x4";
            // 
            // cub_y3
            // 
            this.cub_y3.Location = new System.Drawing.Point(130, 94);
            this.cub_y3.Name = "cub_y3";
            this.cub_y3.Size = new System.Drawing.Size(53, 20);
            this.cub_y3.TabIndex = 19;
            this.cub_y3.TextChanged += new System.EventHandler(this.cub_y3_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "y3";
            // 
            // cub_y2
            // 
            this.cub_y2.Location = new System.Drawing.Point(130, 59);
            this.cub_y2.Name = "cub_y2";
            this.cub_y2.Size = new System.Drawing.Size(53, 20);
            this.cub_y2.TabIndex = 17;
            this.cub_y2.TextChanged += new System.EventHandler(this.cub_y2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(106, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "y2";
            // 
            // cub_y1
            // 
            this.cub_y1.Location = new System.Drawing.Point(130, 24);
            this.cub_y1.Name = "cub_y1";
            this.cub_y1.Size = new System.Drawing.Size(53, 20);
            this.cub_y1.TabIndex = 15;
            this.cub_y1.TextChanged += new System.EventHandler(this.cub_y1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(106, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "y1";
            // 
            // cub_x3
            // 
            this.cub_x3.Location = new System.Drawing.Point(32, 94);
            this.cub_x3.Name = "cub_x3";
            this.cub_x3.Size = new System.Drawing.Size(53, 20);
            this.cub_x3.TabIndex = 13;
            this.cub_x3.TextChanged += new System.EventHandler(this.cub_x3_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "x3";
            // 
            // cub_x2
            // 
            this.cub_x2.Location = new System.Drawing.Point(32, 59);
            this.cub_x2.Name = "cub_x2";
            this.cub_x2.Size = new System.Drawing.Size(53, 20);
            this.cub_x2.TabIndex = 11;
            this.cub_x2.TextChanged += new System.EventHandler(this.cub_x2_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "x2";
            // 
            // cub_x1
            // 
            this.cub_x1.Location = new System.Drawing.Point(32, 24);
            this.cub_x1.Name = "cub_x1";
            this.cub_x1.Size = new System.Drawing.Size(53, 20);
            this.cub_x1.TabIndex = 9;
            this.cub_x1.TextChanged += new System.EventHandler(this.cub_x1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "x1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.quad_y3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.quad_y2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.quad_y1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.quad_x3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.quad_x2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.quad_x1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_Bz_Quad);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 185);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Curva Bezier Quad.";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Desenhar Curva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // quad_y3
            // 
            this.quad_y3.Location = new System.Drawing.Point(130, 94);
            this.quad_y3.Name = "quad_y3";
            this.quad_y3.Size = new System.Drawing.Size(53, 20);
            this.quad_y3.TabIndex = 19;
            this.quad_y3.TextChanged += new System.EventHandler(this.quad_y3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "y3";
            // 
            // quad_y2
            // 
            this.quad_y2.Location = new System.Drawing.Point(130, 59);
            this.quad_y2.Name = "quad_y2";
            this.quad_y2.Size = new System.Drawing.Size(53, 20);
            this.quad_y2.TabIndex = 17;
            this.quad_y2.TextChanged += new System.EventHandler(this.quad_y2_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "y2";
            // 
            // quad_y1
            // 
            this.quad_y1.Location = new System.Drawing.Point(130, 24);
            this.quad_y1.Name = "quad_y1";
            this.quad_y1.Size = new System.Drawing.Size(53, 20);
            this.quad_y1.TabIndex = 15;
            this.quad_y1.TextChanged += new System.EventHandler(this.quad_y1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(106, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "y1";
            // 
            // quad_x3
            // 
            this.quad_x3.Location = new System.Drawing.Point(32, 94);
            this.quad_x3.Name = "quad_x3";
            this.quad_x3.Size = new System.Drawing.Size(53, 20);
            this.quad_x3.TabIndex = 13;
            this.quad_x3.TextChanged += new System.EventHandler(this.quad_x3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "x3";
            // 
            // quad_x2
            // 
            this.quad_x2.Location = new System.Drawing.Point(32, 59);
            this.quad_x2.Name = "quad_x2";
            this.quad_x2.Size = new System.Drawing.Size(53, 20);
            this.quad_x2.TabIndex = 11;
            this.quad_x2.TextChanged += new System.EventHandler(this.quad_x2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "x2";
            // 
            // quad_x1
            // 
            this.quad_x1.Location = new System.Drawing.Point(32, 24);
            this.quad_x1.Name = "quad_x1";
            this.quad_x1.Size = new System.Drawing.Size(53, 20);
            this.quad_x1.TabIndex = 9;
            this.quad_x1.TextChanged += new System.EventHandler(this.quad_x1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "x1";
            // 
            // btn_Bz_Quad
            // 
            this.btn_Bz_Quad.Location = new System.Drawing.Point(6, 120);
            this.btn_Bz_Quad.Name = "btn_Bz_Quad";
            this.btn_Bz_Quad.Size = new System.Drawing.Size(198, 23);
            this.btn_Bz_Quad.TabIndex = 7;
            this.btn_Bz_Quad.Text = "Escolher Pontos";
            this.btn_Bz_Quad.UseVisualStyleBackColor = true;
            this.btn_Bz_Quad.Click += new System.EventHandler(this.btn_Bz_Quad_Click);
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(141, 440);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(75, 23);
            this.btApagar.TabIndex = 6;
            this.btApagar.Text = "Apagar";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.BtApagar_Click);
            // 
            // btCor
            // 
            this.btCor.Location = new System.Drawing.Point(60, 440);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox quad_x1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox quad_y3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox quad_y2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox quad_y1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox quad_x3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox quad_x2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox cub_y4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cub_x4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox cub_y3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cub_y2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox cub_y1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cub_x3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox cub_x2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox cub_x1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

