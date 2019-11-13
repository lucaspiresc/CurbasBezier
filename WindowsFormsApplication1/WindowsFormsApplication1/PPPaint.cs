using PPPaint.Util;
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

        int? x1cubica = null;
        int? x2cubica = null;
        int? x3cubica = null;
        int? x4cubica = null;

        int? y1cubica = null;
        int? y2cubica = null;
        int? y3cubica = null;
        int? y4cubica = null;

        int? x1quadratica = null;
        int? x2quadratica = null;
        int? x3quadratica = null;

        int? y1quadratica = null;
        int? y2quadratica = null;
        int? y3quadratica = null;

        bool escolhendoPontos, quadratica, cubica;

        public tela()
        {
            InitializeComponent();
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            corPreenche = Color.Black;
        }

        /*
         * Regiao que faz o tratamento dos eventos ativados pelo usuario
         * (Geralmente cliques no canvas ou cliques em botões)
         */
        #region Eventos

        /*
         * Evento para tratar o clique no botão do painel de cores,
         * onde o usuário vai escolher a cor para as formas que ele irá desenhar
         */
        private void BtCor_Click(object sender, EventArgs e)
        {
            DialogResult result = cdlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                corPreenche = cdlg.Color;
            }
        }

        /*
         * Evento para tratar o clique no botão de apagar,
         * onde o usuário vai limpar o canvas completamente
         */
        private void BtApagar_Click(object sender, EventArgs e)
        {
            //limpa o canvas
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;
        }

        /*
         * Evento para tratar o clique dentro do canvas,
         * onde serão salvas as coordenadas dos pontos incial e final
         * necessários para desenhar as formas
         */
        private void Imagem_Click(object sender, MouseEventArgs e)
        {
            //Só computa cliques no canvas caso o usuario escolha um tipo de curva
            if (e.Button == MouseButtons.Left && escolhendoPontos)
            {
                if (quadratica)
                {
                    AdicionaPontosQuadratica(e.X, e.Y);
                }
                else if (cubica)
                {
                    AdicionaPontosCubica(e.X, e.Y);
                }
            }
        }

        /*
         * Evento para tratar o clique no botao do bezier quadratico, onde
         * sera necessario que o usuario escolha os pontos de controle antes
         * de executar o algoritmo
         */
        private void btn_Bz_Quad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clique em 3 pontos na tela", "Ação necessária", MessageBoxButtons.OK, MessageBoxIcon.Information);

            escolhendoPontos = true;
            quadratica = true;
            cubica = false;
        }

        /*
         * Evento para tratar o clique no botao do bezier cubico, onde
         * sera necessario que o usuario escolha os pontos de controle antes
         * de executar o algoritmo
         */
        private void btn_Bz_Cub_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clique em 4 pontos na tela", "Ação necessária", MessageBoxButtons.OK, MessageBoxIcon.Information);

            escolhendoPontos = true;
            quadratica = false;
            cubica = true;
        }

        #region Quadratica

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_x1_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_x1.Text, out a))
            {
                x1quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_x1.Text = x1quadratica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_y1_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_y1.Text, out a))
            {
                y1quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_y1.Text = y1quadratica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_x2_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_x2.Text, out a))
            {
                x2quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_x2.Text = x2quadratica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_y2_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_y2.Text, out a))
            {
                y2quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_y2.Text = y2quadratica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_x3_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_x3.Text, out a))
            {
                x3quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_x3.Text = x3quadratica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void quad_y3_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(quad_y3.Text, out a))
            {
                y3quadratica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quad_y3.Text = y3quadratica.ToString();
            }
        }

        /*
         * Executa o algoritmo bezier quadratico se o usuario tiver os 3 pontos escolhidos
         */
        private void button1_Click(object sender, EventArgs e)
        {
            if (x1quadratica.HasValue && x2quadratica.HasValue && x3quadratica.HasValue
                && y1quadratica.HasValue && y2quadratica.HasValue && y3quadratica.HasValue)
            {
                //limpa o canvas
                areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
                imagem.Image = areaDesenho;

                //Desenha as retas delimitadoras
                BresenhamReta(x1quadratica.Value, y1quadratica.Value, x2quadratica.Value, y2quadratica.Value, Color.Red);
                BresenhamReta(x2quadratica.Value, y2quadratica.Value, x3quadratica.Value, y3quadratica.Value, Color.Red);

                //Desenha a curva de Bezier
                BezierQuadratica(x1quadratica.Value, y1quadratica.Value, x2quadratica.Value, y2quadratica.Value, x3quadratica.Value, y3quadratica.Value, corPreenche);
            }
            else
            {
                MessageBox.Show("Por favor escolha todos os pontos necessarios!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Cubica

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_x1_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_x1.Text, out a))
            {
                x1cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_x1.Text = x1cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_y1_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_y1.Text, out a))
            {
                y1cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_y1.Text = y1cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_x2_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_x2.Text, out a))
            {
                x2cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_x2.Text = x2cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_y2_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_y2.Text, out a))
            {
                y2cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_y2.Text = y2cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_x3_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_x3.Text, out a))
            {
                x3cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_x3.Text = x3cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_y3_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_y3.Text, out a))
            {
                y3cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_y3.Text = y3cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_x4_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_x4.Text, out a))
            {
                x4cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_x4.Text = x4cubica.ToString();
            }
        }

        /*
         * Atualiza o valor do ponto quando o usuario altera na tela
         */
        private void cub_y4_TextChanged(object sender, EventArgs e)
        {
            int a;
            if (Int32.TryParse(cub_y4.Text, out a))
            {
                y4cubica = a;
            }
            else
            {
                MessageBox.Show("Por favor digite um numero inteiro valido!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cub_y4.Text = y4cubica.ToString();
            }
        }

        /*
         * Executa o algoritmo bezier cubico se o usuario tiver os 4 pontos escolhidos
         */
        private void button2_Click(object sender, EventArgs e)
        {
            if (x1cubica.HasValue && x2cubica.HasValue && x3cubica.HasValue && x4cubica.HasValue
                && y1cubica.HasValue && y2cubica.HasValue && y3cubica.HasValue && y4cubica.HasValue)
            {
                //limpa o canvas
                areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
                imagem.Image = areaDesenho;
                //Desenha as retas delimitadoras
                BresenhamReta(x1cubica.Value, y1cubica.Value, x2cubica.Value, y2cubica.Value, Color.Red);
                BresenhamReta(x2cubica.Value, y2cubica.Value, x3cubica.Value, y3cubica.Value, Color.Red);
                BresenhamReta(x3cubica.Value, y3cubica.Value, x4cubica.Value, y4cubica.Value, Color.Red);

                //Desenha a curva de Bezier
                BezierCubica(x1cubica.Value, y1cubica.Value, x2cubica.Value, y2cubica.Value, x3cubica.Value, y3cubica.Value, x4cubica.Value, y4cubica.Value, corPreenche);
            }
            else
            {
                MessageBox.Show("Por favor escolha todos os pontos necessarios!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        #region Curvas Parametricas

        /*
         * Desenha a curva de Bezier de grau 2,
         * aplicando o algoritmo de Casteljau
         */
        public void BezierQuadratica(int x1, int y1, int x2, int y2, int x3, int y3, Color cor)
        {
            int xInit = x1;
            int yInit = y1;

            int xFim, yFim;

            for (double t = 0; t <= 1; t += 0.001)
            {
                xFim = Convert.ToInt32(Math.Pow((1 - t), 2) * x1 + 2 * t * (1 - t) * x2 + Math.Pow(t, 2) * x3);
                yFim = Convert.ToInt32(Math.Pow((1 - t), 2) * y1 + 2 * t * (1 - t) * y2 + Math.Pow(t, 2) * y3);

                BresenhamReta(Math.Abs(xInit), Math.Abs(yInit), Math.Abs(xFim), Math.Abs(yFim), cor);

                xInit = xFim;
                yInit = yFim;
            }
        }

        /*
         * Desenha a curva de Bezier de grau 3,
         * aplicando o algoritmo de Casteljau
         */
        public void BezierCubica(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, Color cor)
        {
            int xInit = x1;
            int yInit = y1;

            int xFim, yFim;

            for (double t = 0; t <= 1; t += 0.001)
            {
                xFim = Convert.ToInt32(Math.Pow((1 - t), 3) * x1 + 3 * t * Math.Pow((1 - t), 2) * x2 + 3 * (1 - t) * Math.Pow(t, 2) * x3 + Math.Pow(t, 3) * x4);
                yFim = Convert.ToInt32(Math.Pow((1 - t), 3) * y1 + 3 * t * Math.Pow((1 - t), 2) * y2 + 3 * (1 - t) * Math.Pow(t, 2) * y3 + Math.Pow(t, 3) * y4);

                BresenhamReta(Math.Abs(xInit), Math.Abs(yInit), Math.Abs(xFim), Math.Abs(yFim), cor);

                xInit = xFim;
                yInit = yFim;
            }
        }

        #endregion

        /*
        * Região contendo metodos utilitarios 
        */
        #region Uteis

        /*
         * Algoritmo de Bresenham para traçar retas utilizando apenas calculos com números inteiros
         */
        public void BresenhamReta(int xInicial, int yInicial, int xFinal, int yFinal, Color cor)
        {
            double x = xInicial;
            double y = yInicial;

            int dx = xFinal - xInicial;
            int dy = yFinal - yInicial;

            int p, xIncr, yIncr, const1, const2;

            if (dx > 0)
            {
                xIncr = 1;
            }
            else
            {
                dx = -dx;
                xIncr = -1;
            }

            if (dy > 0)
            {
                yIncr = 1;
            }
            else
            {
                dy = -dy;
                yIncr = -1;
            }

            if (x > 0 && x < areaDesenho.Size.Width && y > 0 && y < areaDesenho.Size.Height)
            {
                areaDesenho.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), cor);
            }

            if (dx > dy)
            {
                p = 2 * dy - dx;

                const1 = 2 * dy;
                const2 = 2 * (dy - dx);

                for (var i = 0; i < dx; i++)
                {
                    x += xIncr;
                    if (p < 0)
                    {
                        p += const1;
                    }
                    else
                    {
                        y += yIncr;
                        p += const2;
                    }

                    if (x < areaDesenho.Size.Width & y < areaDesenho.Size.Height & x > 0 & y > 0)
                    {
                        if (x > 0 && x < areaDesenho.Size.Width && y > 0 && y < areaDesenho.Size.Height)
                        {
                            areaDesenho.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), cor);
                        }
                    }
                }
            }
            else
            {
                p = 2 * dx - dy;
                const1 = 2 * dx;
                const2 = 2 * (dx - dy);

                for (var i = 0; i < dy; i++)
                {
                    y += yIncr;
                    if (p < 0)
                    {
                        p += const1;
                    }
                    else
                    {
                        p += const2;
                        x += xIncr;
                    }
                    if (x < areaDesenho.Size.Width & y < areaDesenho.Size.Height & x > 0 & y > 0)
                    {
                        if (x > 0 && x < areaDesenho.Size.Width && y > 0 && y < areaDesenho.Size.Height)
                        {
                            areaDesenho.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), cor);
                        }
                    }
                }
            }
            imagem.Image = areaDesenho;
        }

        /*
         * Adiciona um ponto escolhido pelo usuario na ultima posicao disponivel
         */
        public void AdicionaPontosQuadratica(int x, int y)
        {
            if (x1quadratica == null && y1quadratica == null)
            {
                x1quadratica = x;
                quad_x1.Text = x.ToString();

                y1quadratica = y;
                quad_y1.Text = y.ToString();
            }
            else if (x2quadratica == null && y2quadratica == null)
            {
                x2quadratica = x;
                quad_x2.Text = x.ToString();

                y2quadratica = y;
                quad_y2.Text = y.ToString();
            }
            else
            {
                x3quadratica = x;
                quad_x3.Text = x.ToString();

                y3quadratica = y;
                quad_y3.Text = y.ToString();
            }
        }

        /*
         * Adiciona um ponto escolhido pelo usuario na ultima posicao disponivel
         */
        public void AdicionaPontosCubica(int x, int y)
        {
            if (x1cubica == null && y1cubica == null)
            {
                x1cubica = x;
                cub_x1.Text = x.ToString();

                y1cubica = y;
                cub_y1.Text = y.ToString();
            }
            else if (x2cubica == null && y2cubica == null)
            {
                x2cubica = x;
                cub_x2.Text = x.ToString();

                y2cubica = y;
                cub_y2.Text = y.ToString();
            }
            else if (x3cubica == null && y3cubica == null)
            {
                x3cubica = x;
                cub_x3.Text = x.ToString();

                y3cubica = y;
                cub_y3.Text = y.ToString();
            }
            else
            {
                x4cubica = x;
                cub_x4.Text = x.ToString();

                y4cubica = y;
                cub_y4.Text = y.ToString();
            }
        }
        #endregion
    }
}
