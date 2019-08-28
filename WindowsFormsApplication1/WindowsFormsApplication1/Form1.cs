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
            corPreenche = Color.Black;                       
        }

        private void desenhar_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y))
            {
                areaDesenho.SetPixel(x, y, corPreenche);
                imagem.Image = areaDesenho;
            }
            else
            {
                MessageBox.Show("Favor preencher as coordenadas X e Y com valores inteiros válidos", "Erro");
            }
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

                    DDA();
                    
                    //Depois de desenhar a figura, reinicia os pontos final e inicial
                    xInicial = null;
                    yInicial = null;

                    xFinal = null;
                    yFinal = null;
                }
            }
        }

        private void Translacao(int xT, int yT)
        {
            Bitmap novaArea = new Bitmap(areaDesenho.Size.Width, areaDesenho.Size.Height);

            for (int i = 0; i < areaDesenho.Size.Width; i++)
            {
                for(int j = 0; j < areaDesenho.Size.Height; j++)
                {
                    if (i + xT > 0 && i + xT < areaDesenho.Size.Width && j +yT > 0 && j + yT < areaDesenho.Size.Height)
                    {
                        novaArea.SetPixel(i + xT, j + yT, areaDesenho.GetPixel(i, j));
                    }
                }
            }

            areaDesenho = novaArea;
            imagem.Image = areaDesenho;
        }

        private void DDA()
        {
            double dx = xFinal.Value - xInicial.Value;
            double dy = yFinal.Value - yInicial.Value;

            int nPassos;

            if(Math.Abs(dx) >= Math.Abs(dy))
            {
                nPassos = Convert.ToInt32(Math.Abs(dx));
            }
            else
            {
                nPassos = Convert.ToInt32(Math.Abs(dy));
            }

            double xAdd = dx / nPassos;
            double yAdd = dy / nPassos;

            double x = xInicial.Value;
            double y = yInicial.Value;

            for (int i = 0; i < nPassos; i++)
            {
                x += xAdd;
                y += yAdd;

                areaDesenho.SetPixel((int)x, (int)y, corPreenche);
                imagem.Image = areaDesenho;
            }
        }

        private void Btn_Translado_Click(object sender, EventArgs e)
        {
            int x;
            int y;
            if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y))
            {
                Translacao(x, y);
            }
            else
            {
                MessageBox.Show("Favor preencher as coordenadas X e Y com valores inteiros válidos", "Erro");
            }
        }
    }
}
