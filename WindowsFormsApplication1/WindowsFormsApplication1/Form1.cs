using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class tela : Form
    {
        Bitmap areaDesenho;
        Color corPreenche;

        int? xInicial = null;
        int? xFinal = null;

        int? yInicial = null;
        int? yFinal = null;

        public tela()
        {
            InitializeComponent();            
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            corPreenche = Color.Blue;                       
        }

        private void desenhar_Click(object sender, EventArgs e)
        {
            int x = (int) Convert.ToInt64(txtX.Text);
            int y = (int) Convert.ToInt64(txtY.Text);

            areaDesenho.SetPixel(x, y, corPreenche);
            imagem.Image = areaDesenho;
        }

        private void btCor_Click(object sender, EventArgs e)
        {
            DialogResult result = cdlg.ShowDialog();
            if (result == DialogResult.OK)
            {                
                corPreenche = cdlg.Color;
            }
        }

        private void btApagar_Click(object sender, EventArgs e)
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;

            txtX.Text = "";
            txtY.Text = "";
        }

        private void imagem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;

                //se x e y inicial não estão setados, é porque o usuário está escolhendo os pts inciais
                if (xInicial == null && yInicial == null)
                {
                    xInicial = x;
                    yInicial = y;
                }
                //se eles já estão setados, o usuário está selecionando os pontos finais
                else
                {
                    xFinal = x;
                    yFinal = y;

                    areaDesenho.SetPixel(x, y, corPreenche);
                    imagem.Image = areaDesenho;
                }

                txtX.Text = x.ToString();
                txtY.Text = y.ToString();
            }
        }

        //private void imagem_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        int x = e.X;
        //        int y = e.Y;

        //        if (xInicial == null && yInicial == null)
        //        {
        //            xInicial = x;
        //            yInicial = y;
        //        }
        //        else
        //        {
        //            xFinal = x;
        //            yFinal = y;
        //        }

        //        txtX.Text = x.ToString();
        //        txtY.Text = y.ToString();

        //        areaDesenho.SetPixel(x, y, corPreenche);
        //        imagem.Image = areaDesenho;
        //    }
        //}
    }
}
