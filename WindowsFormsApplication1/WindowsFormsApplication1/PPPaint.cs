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

        List<int> pontosX = new List<int>();
        List<int> pontosY = new List<int>();
        int totalPontos;
        bool escolhendoPontos, quadratica, cubica;

        public tela()
        {
            InitializeComponent();            
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            //Escolhe uma cor para a curva antes de iniciar a aplicação
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

            ResetaVariaveis();
        }

        /*
         * Evento para tratar o clique dentro do canvas,
         * onde serão salvas as coordenadas dos pontos incial e final
         * necessários para desenhar as formas
         */ 
        private void Imagem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && escolhendoPontos)
            {
                //Adiciona ponto na lista de pontos atuais, e desenha esse ponto no canvas
                pontosX.Add(e.X);
                pontosY.Add(e.Y);

                totalPontos++;

                areaDesenho.SetPixel(pontosX[totalPontos - 1], pontosY[totalPontos - 1], Color.Black);

                imagem.Image = areaDesenho;

                //Se o usuario escolheu quadratica e os 3 pontos,
                //gera as retas delimitadoras e executa o algoritmo
                if(totalPontos == 3 && quadratica)
                {
                    //Desenha as retas delimitadoras
                    BresenhamReta(pontosX[totalPontos - 3], pontosY[totalPontos - 3], pontosX[totalPontos - 2], pontosY[totalPontos - 2], Color.Red);
                    BresenhamReta(pontosX[totalPontos - 2], pontosY[totalPontos - 2], pontosX[totalPontos - 1], pontosY[totalPontos - 1], Color.Red);

                    //Desenha a curva de Bezier
                    BezierQuadratica(pontosX[totalPontos - 3], pontosY[totalPontos - 3], pontosX[totalPontos - 2], pontosY[totalPontos - 2], pontosX[totalPontos - 1], pontosY[totalPontos - 1], corPreenche);

                    ResetaVariaveis();
                }
                //Se o usuario escolheu cubica e os 4 pontos,
                //gera as retas delimitadoras e executa o algoritmo
                else if (totalPontos == 4 & cubica)
                {
                    //Desenha as retas delimitadoras
                    BresenhamReta(pontosX[totalPontos - 4], pontosY[totalPontos - 4], pontosX[totalPontos - 3], pontosY[totalPontos - 3], Color.Red);
                    BresenhamReta(pontosX[totalPontos - 3], pontosY[totalPontos - 3], pontosX[totalPontos - 2], pontosY[totalPontos - 2], Color.Red);
                    BresenhamReta(pontosX[totalPontos - 2], pontosY[totalPontos - 2], pontosX[totalPontos - 1], pontosY[totalPontos - 1], Color.Red);

                    //Desenha a curva de Bezier
                    BezierCubica(pontosX[totalPontos - 4], pontosY[totalPontos - 4], pontosX[totalPontos - 3], pontosY[totalPontos - 3], pontosX[totalPontos - 2], pontosY[totalPontos - 2], pontosX[totalPontos - 1], pontosY[totalPontos - 1], corPreenche);

                    ResetaVariaveis();
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

            //Reinicia as listas de pontos
            pontosX = new List<int>();
            pontosY = new List<int>();
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
            cubica = true;
            // Reseta as listas de pontos
            pontosX = new List<int>();
            pontosY = new List<int>();
        }
        #endregion

        #region Curvas Parametricas

        public void BezierQuadratica(int xC1, int yC1, int xC2, int yC2, int xC3, int yC3, Color cor)
        {
            int xOld = xC1;
            int yOld = yC1;
            int xNew, yNew;

            for (double t = 0; t <= 1; t += 0.001)
            {
               xNew = Convert.ToInt32(Math.Pow((1 - t), 2) * xC1 + 2 * t * (1 - t) * xC2 + Math.Pow(t, 2) * xC3);
               yNew = Convert.ToInt32(Math.Pow((1 - t), 2) * yC1 + 2 * t * (1 - t) * yC2 + Math.Pow(t, 2) * yC3);

                BresenhamReta(Math.Abs(xOld), Math.Abs(yOld), Math.Abs(xNew), Math.Abs(yNew), cor);

                xOld = xNew;
                yOld = yNew;
            }
        }

        public void BezierCubica(int xC1, int yC1, int xC2, int yC2, int xC3, int yC3, int xC4, int yC4, Color cor)
        {
            int xOld = xC1;
            int yOld = yC1;
            int xNew, yNew;

            for (double t = 0; t <= 1; t += 0.001)
            {
                xNew = Convert.ToInt32(Math.Pow((1 - t), 3) * xC1 + 3 * t * Math.Pow((1 - t), 2) * xC2 + 3 * (1 - t) * Math.Pow(t, 2) * xC3 + Math.Pow(t, 3) * xC4);
                yNew = Convert.ToInt32(Math.Pow((1 - t), 3) * yC1 + 3 * t * Math.Pow((1 - t), 2) * yC2 + 3 * (1 - t) * Math.Pow(t, 2) * yC3 + Math.Pow(t, 3) * yC4);

                BresenhamReta(Math.Abs(xOld), Math.Abs(yOld), Math.Abs(xNew), Math.Abs(yNew), cor);

                xOld = xNew;
                yOld = yNew;
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
                        p += const1;
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
         * Reseta as variaveis apos a execucao de um algoritmo de curva,
         * ara prepara-las para outra execucao
         */
        public void ResetaVariaveis()
        {
            // Reseta as listas de pontos
            pontosX = new List<int>();
            pontosY = new List<int>();

            totalPontos = 0;

            escolhendoPontos = false;
            quadratica = false;
            cubica = false;
        }
        #endregion
    }
}
