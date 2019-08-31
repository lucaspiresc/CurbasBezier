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
            this.btn_dda = new System.Windows.Forms.Button();
            this.xFim = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yFim = new System.Windows.Forms.TextBox();
            this.xInit = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Graus = new System.Windows.Forms.TextBox();
            this.btn_Rotacionar = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.btn_Translado = new System.Windows.Forms.Button();
            this.lbX = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btApagar = new System.Windows.Forms.Button();
            this.yInit = new System.Windows.Forms.TextBox();
            this.btCor = new System.Windows.Forms.Button();
            this.cdlg = new System.Windows.Forms.ColorDialog();
            this.btn_Escala = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.painel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagem
            // 
            this.imagem.BackColor = System.Drawing.Color.White;
            this.imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagem.Location = new System.Drawing.Point(0, 0);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(946, 562);
            this.imagem.TabIndex = 0;
            this.imagem.TabStop = false;
            this.imagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Imagem_Click);
            // 
            // painel
            // 
            this.painel.Controls.Add(this.btn_dda);
            this.painel.Controls.Add(this.xFim);
            this.painel.Controls.Add(this.label3);
            this.painel.Controls.Add(this.label4);
            this.painel.Controls.Add(this.yFim);
            this.painel.Controls.Add(this.xInit);
            this.painel.Controls.Add(this.groupBox1);
            this.painel.Controls.Add(this.label1);
            this.painel.Controls.Add(this.label2);
            this.painel.Controls.Add(this.btApagar);
            this.painel.Controls.Add(this.yInit);
            this.painel.Controls.Add(this.btCor);
            this.painel.Dock = System.Windows.Forms.DockStyle.Right;
            this.painel.Location = new System.Drawing.Point(702, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(244, 562);
            this.painel.TabIndex = 1;
            // 
            // btn_dda
            // 
            this.btn_dda.Location = new System.Drawing.Point(29, 330);
            this.btn_dda.Name = "btn_dda";
            this.btn_dda.Size = new System.Drawing.Size(75, 23);
            this.btn_dda.TabIndex = 8;
            this.btn_dda.Text = "DDA";
            this.btn_dda.UseVisualStyleBackColor = true;
            this.btn_dda.Click += new System.EventHandler(this.Btn_dda_Click);
            // 
            // xFim
            // 
            this.xFim.Enabled = false;
            this.xFim.Location = new System.Drawing.Point(123, 245);
            this.xFim.Name = "xFim";
            this.xFim.Size = new System.Drawing.Size(68, 20);
            this.xFim.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "X Final";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Y Final";
            // 
            // yFim
            // 
            this.yFim.Enabled = false;
            this.yFim.Location = new System.Drawing.Point(123, 284);
            this.yFim.Name = "yFim";
            this.yFim.Size = new System.Drawing.Size(68, 20);
            this.yFim.TabIndex = 15;
            // 
            // xInit
            // 
            this.xInit.Enabled = false;
            this.xInit.Location = new System.Drawing.Point(29, 245);
            this.xInit.Name = "xInit";
            this.xInit.Size = new System.Drawing.Size(68, 20);
            this.xInit.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Escala);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_Graus);
            this.groupBox1.Controls.Add(this.btn_Rotacionar);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.btn_Translado);
            this.groupBox1.Controls.Add(this.lbX);
            this.groupBox1.Controls.Add(this.lbY);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transformações Geométricas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Graus";
            // 
            // txt_Graus
            // 
            this.txt_Graus.Location = new System.Drawing.Point(7, 145);
            this.txt_Graus.Name = "txt_Graus";
            this.txt_Graus.Size = new System.Drawing.Size(68, 20);
            this.txt_Graus.TabIndex = 10;
            // 
            // btn_Rotacionar
            // 
            this.btn_Rotacionar.Location = new System.Drawing.Point(101, 142);
            this.btn_Rotacionar.Name = "btn_Rotacionar";
            this.btn_Rotacionar.Size = new System.Drawing.Size(75, 23);
            this.btn_Rotacionar.TabIndex = 8;
            this.btn_Rotacionar.Text = "Rotacionar";
            this.btn_Rotacionar.UseVisualStyleBackColor = true;
            this.btn_Rotacionar.Click += new System.EventHandler(this.Btn_Rotacionar_Click);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(7, 32);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(68, 20);
            this.txtX.TabIndex = 3;
            // 
            // btn_Translado
            // 
            this.btn_Translado.Location = new System.Drawing.Point(101, 29);
            this.btn_Translado.Name = "btn_Translado";
            this.btn_Translado.Size = new System.Drawing.Size(75, 23);
            this.btn_Translado.TabIndex = 7;
            this.btn_Translado.Text = "Transladar";
            this.btn_Translado.UseVisualStyleBackColor = true;
            this.btn_Translado.Click += new System.EventHandler(this.Btn_Translado_Click);
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(4, 15);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(14, 13);
            this.lbX.TabIndex = 1;
            this.lbX.Text = "X";
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(4, 55);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(14, 13);
            this.lbY.TabIndex = 2;
            this.lbY.Text = "Y";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(7, 71);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(68, 20);
            this.txtY.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y Inicial";
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(22, 527);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(75, 23);
            this.btApagar.TabIndex = 6;
            this.btApagar.Text = "Apagar";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.BtApagar_Click);
            // 
            // yInit
            // 
            this.yInit.Enabled = false;
            this.yInit.Location = new System.Drawing.Point(29, 284);
            this.yInit.Name = "yInit";
            this.yInit.Size = new System.Drawing.Size(68, 20);
            this.yInit.TabIndex = 11;
            // 
            // btCor
            // 
            this.btCor.Location = new System.Drawing.Point(123, 527);
            this.btCor.Name = "btCor";
            this.btCor.Size = new System.Drawing.Size(75, 23);
            this.btCor.TabIndex = 5;
            this.btCor.Text = "Cor";
            this.btCor.UseVisualStyleBackColor = true;
            this.btCor.Click += new System.EventHandler(this.BtCor_Click);
            // 
            // btn_Escala
            // 
            this.btn_Escala.Location = new System.Drawing.Point(101, 71);
            this.btn_Escala.Name = "btn_Escala";
            this.btn_Escala.Size = new System.Drawing.Size(75, 23);
            this.btn_Escala.TabIndex = 11;
            this.btn_Escala.Text = "Escala";
            this.btn_Escala.UseVisualStyleBackColor = true;
            this.btn_Escala.Click += new System.EventHandler(this.Btn_Escala_Click);
            // 
            // tela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 562);
            this.Controls.Add(this.painel);
            this.Controls.Add(this.imagem);
            this.Name = "tela";
            this.Text = "Manipulação Imagem";
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Button btApagar;
        private System.Windows.Forms.Button btCor;
        private System.Windows.Forms.ColorDialog cdlg;
        private System.Windows.Forms.Button btn_Translado;
        private System.Windows.Forms.TextBox xFim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yFim;
        private System.Windows.Forms.TextBox xInit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox yInit;
        private System.Windows.Forms.Button btn_dda;
        private System.Windows.Forms.Button btn_Rotacionar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Graus;
        private System.Windows.Forms.Button btn_Escala;
    }
}

