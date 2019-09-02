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

        int? xInicial = null;
        int? xFinal = null;

        int? yInicial = null;
        int? yFinal = null;

        /*
         * Coodenadas da ultima reta desenhada. Serao utilizadas nas transformacoes geometricas
         */
        int? xInicialBuffer = null;
        int? xFinalBuffer = null;

        int? yInicialBuffer = null;
        int? yFinalBuffer = null;

        /*
         * Salva o algoritmo utilizado para desenhar a ultima reta, será utilizado
         * para rodar o mesmo algoritmo caso a reta tenha que ser apagada
         */
        AlgoritmosReta? algoritmoBuffer = null;

        public tela()
        {
            InitializeComponent();            
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            corPreenche = Color.Black;                       
        }

        #region Transformacoes Geométricas

        /*
         * Aplica a translação desejada na ultima reta desenhada
         */
        public void Translacao(int x1, int y1, int x2, int y2, int xT, int yT)
        {
            //Apaga a reta atual 
            ApagaReta(x1, y1, x2, y2);

            //Insere a reta alterada
            DDA(x1 + xT, y1 - yT, x2 + xT, y2 - yT, corPreenche);

            //Atualiza os valores do buffer
            SalvarBuffer(x1 + xT, y1 - yT, x2 + xT, y2 - yT, AlgoritmosReta.DDA);
        }

        /*
         * Aplica a escala desejada na ultima reta desenhada
         */
        public void Escala(int x1, int y1, int x2, int y2, double eX, double eY)
        {
            double tempX, tempY;

            //Apaga a reta atual para a inserção de sua nova versão
            ApagaReta(x1, y1, x2, y2);

            tempX = x2 - x1;
            tempY = y2 - y1;

            tempX *= eX;
            tempY *= eY;

            x2 = Convert.ToInt32(tempX) + x1;
            y2 = Convert.ToInt32(tempY) + y1;

            //Traça a nova reta alterada
            DDA(x1, y1, x2, y2, corPreenche);

            //Atualiza os valores do buffer
            SalvarBuffer(x1, y1, x2, y2, AlgoritmosReta.DDA);
        }

        /*
         * Aplica a rotação pelo ângulo desejado na ultima reta desenhada
         */
        public void Rotacao(int x1, int y1, int x2, int y2, double angulo)
        {
            double xfinal, yFinal;

            //Apaga a reta atual para depois desenhar ela rotacionada
            ApagaReta(x1, y1, x2, y2);

            //Translada o ponto final para que a reta comece na origem 
            x2 = x2 - x1;
            y2 = y2 - y1;

            //Calcula o deslocamento do ponto final pós-rotação
            xfinal = x2 * Math.Cos(angulo) - y2 * Math.Sin(angulo);
            yFinal = x2 * Math.Sin(angulo) + y2 * Math.Cos(angulo);

            //Desfaz a translação do ponto final
            x2 = Convert.ToInt32(xfinal) + x1;
            y2 = Convert.ToInt32(yFinal) + y1;

            //Traça a nova reta alterada
            DDA(x1, y1, x2, y2, corPreenche);

            //Atualiza os valores do buffer
            SalvarBuffer(x1, y1, x2, y2, AlgoritmosReta.DDA);
        }

        #endregion

        /*
         * Região contendo os algoritmos relacionados a desenhos de reta
         */
        #region Retas

        /*
         * Algoritmo DDA para desenhar uma reta a partir de seus pontos inicial e final
         */
        private void DDA(int xInicial, int yInicial, int xFinal, int yFinal, Color cor)
        {
            double dx = xFinal - xInicial;
            double dy = yFinal - yInicial;

            int nPassos;

            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                nPassos = Convert.ToInt32(Math.Abs(dx));
            }
            else
            {
                nPassos = Convert.ToInt32(Math.Abs(dy));
            }

            double xAdd = dx / nPassos;
            double yAdd = dy / nPassos;

            double x = xInicial;
            double y = yInicial;

            for (int i = 0; i < nPassos; i++)
            {
                x += xAdd;
                y += yAdd;

                if (x > 0 && x < areaDesenho.Size.Width && y > 0 && y < areaDesenho.Size.Height)
                {
                    areaDesenho.SetPixel((int)x, (int)y, cor);
                }
            }
            imagem.Image = areaDesenho;
        }

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

        public void BresenhamCirculo(int x1, int y1, int x2, int y2, Color cor)
        {

            // Calcula o módulo do vetor equivalente ao raio
            double potX = Math.Pow(x2 - x1, 2);
            double potY = Math.Pow(y2 - y1, 2);

            int r = Convert.ToInt32(Math.Round(Math.Sqrt(potX + potY)));

            int x = 0;
            int y = r;
            int p = 3 - 2 * r;

            PlotaSimetricos(x, y, x1, y1, cor);

            while (x < y)
            {
                if (p < 0)
                    p += 4 * x + 6;
                else
                {
                    p += 4 * (x - y) + 10;
                    y -= 1;
                }

                x += 1;

                PlotaSimetricos(x, y, x1, y1, cor);
            }
        }

        // Algoritmo para plotar os pontos simétricos de uma circunferência, dado o seu ponto central
        public void PlotaSimetricos(int x, int y, int xC, int yC, Color cor)
        {

            //Verifica se os pontos a serem inseridos estão dentro da região da imagem
            if (xC + x < areaDesenho.Size.Width & xC + x > 0)
            {
                if (yC + y < areaDesenho.Size.Height & yC + y > 0)
                {
                    areaDesenho.SetPixel(xC + x, yC + y, cor);
                }
                if (yC - y < areaDesenho.Size.Height & yC - y > 0)
                {
                    areaDesenho.SetPixel(xC + x, yC - y, cor);
                }
            }

            if (xC - x < areaDesenho.Size.Width & xC - x > 0)
            {
                if (yC + y < areaDesenho.Size.Height & yC + y > 0)
                {
                    areaDesenho.SetPixel(xC - x, yC + y, cor);
                }
                if (yC - y < areaDesenho.Size.Height & yC - y > 0)
                {
                    areaDesenho.SetPixel(xC - x, yC - y, cor);
                }
            }

            if (xC + y < areaDesenho.Size.Width & xC + y > 0)
            {
                if (yC + x < areaDesenho.Size.Height & yC + x > 0)
                {
                    areaDesenho.SetPixel(xC + y, yC + x, cor);
                }
                if (yC - x < areaDesenho.Size.Height & yC - x > 0)
                {
                    areaDesenho.SetPixel(xC + y, yC - x, cor);
                }
            }

            if (xC - y < areaDesenho.Size.Width & xC - y > 0)
            {
                if (yC + x < areaDesenho.Size.Height & yC + x > 0)
                {
                    areaDesenho.SetPixel(xC - y, yC + x, cor);
                }
                if (yC - x < areaDesenho.Size.Height & yC - x > 0)
                {
                    areaDesenho.SetPixel(xC - y, yC - x, cor);
                }
            }
            imagem.Image = areaDesenho;
        }


        /*
         * Desenha uma reta da cor do fundo do canvas para "excluir" uma reta.
         * O algoritmo usado para apagar a reta deve ser o mesmo que foi utilizado
         * para desenha-la.
         */
        public void ApagaReta(int x1, int y1, int x2, int y2)
        {
            if (algoritmoBuffer.HasValue && algoritmoBuffer.Value == AlgoritmosReta.DDA)
            {
                DDA(x1, y1, x2, y2, Color.White);
            }
            else if (algoritmoBuffer.HasValue && algoritmoBuffer.Value == AlgoritmosReta.Bresenham)
            {
                BresenhamReta(x1, y1, x2, y2, Color.White);
            } 
        }

        #endregion

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

            //Limpa o buffer de reta
            SalvarBuffer(null, null, null, null, null);
        }

        /*
         * Evento para tratar o clique dentro do canvas,
         * onde serão salvas as coordenadas dos pontos incial e final
         * necessários para desenhar as formas
         */ 
        private void Imagem_Click(object sender, MouseEventArgs e)
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

                    xInit.Text = xInicial.ToString();
                    yInit.Text = yInicial.ToString();
                }
                //se eles já estão setados, o usuário está selecionando os pontos finais
                else
                {
                    xFinal = x;
                    yFinal = y;

                    xFim.Text = xFinal.ToString();
                    yFim.Text = yFinal.ToString();
                }
            }
        }

        /*
         * Evento para tratar o clique no botão da translação,
         * onde será verificado se o existe uma reta, e se o usuário
         * entrou com as coordenadas do translado. Estando tudo OK,
         * executa a translação
         */
        private void Btn_Translado_Click(object sender, EventArgs e)
        {
            if (xInicialBuffer.HasValue && yInicialBuffer.HasValue && xFinalBuffer.HasValue && yFinalBuffer.HasValue)
            {
                int x;
                int y;
                if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y))
                {
                    Translacao(xInicialBuffer.Value, yInicialBuffer.Value, xFinalBuffer.Value, yFinalBuffer.Value, x, y);
                }
                else
                {
                    MessageBox.Show("Favor preencher as coordenadas X e Y com valores inteiros válidos", "Erro");
                }
            }
            else
            {
                MessageBox.Show("Não existe reta na imagem, favor inserir uma reta primeiro", "Erro");
            }
        }

        /*
        * Evento para tratar o clique no botão da escala,
        * onde será verificado se o existe uma reta, e se o usuário
        * entrou com as coordenadas da escala. Estando tudo OK,
        * executa a escala
        */
        private void Btn_Escala_Click(object sender, EventArgs e)
        {
            if (xInicialBuffer.HasValue && yInicialBuffer.HasValue && xFinalBuffer.HasValue && yFinalBuffer.HasValue)
            {
                int x;
                int y;
                if (int.TryParse(txtX.Text, out x) && int.TryParse(txtY.Text, out y))
                {
                    Escala(xInicialBuffer.Value, yInicialBuffer.Value, xFinalBuffer.Value, yFinalBuffer.Value, x, y);
                }
                else
                {
                    MessageBox.Show("Favor preencher as coordenadas X e Y com valores inteiros válidos", "Erro");
                }
            }
            else
            {
                MessageBox.Show("Não existe reta na imagem, favor inserir uma reta primeiro", "Erro");
            }
        }

        /*
        * Evento para tratar o clique no botão da rotacao,
        * onde será verificado se o existe uma reta, e se o usuário
        * entrou com as coordenadas da rotacao. Estando tudo OK,
        * executa a rotacao
        */
        private void Btn_Rotacionar_Click(object sender, EventArgs e)
        {
            if (xInicialBuffer.HasValue && yInicialBuffer.HasValue && xFinalBuffer.HasValue && yFinalBuffer.HasValue)
            {
                double graus;
                if (double.TryParse(txt_Graus.Text, out graus))
                {
                    //Passa o valor para radiano
                    graus = graus * Math.PI / 180;
                    Rotacao(xInicialBuffer.Value, yInicialBuffer.Value, xFinalBuffer.Value, yFinalBuffer.Value, graus);
                }
                else
                {
                    MessageBox.Show("Favor inserir o angulo de rotação com um valor válido", "Erro");
                }
            }
            else
            {
                MessageBox.Show("Não existe reta na imagem, favor inserir uma reta primeiro", "Erro");
            }
        }

        /*
        * Evento para tratar o clique no botão de DDA,
        * onde será verificado  se o usuário entrou com os pontos final e inicial.
        * Estando tudo OK, executa o algoritmo e desenha a reta
        */
        private void Btn_dda_Click(object sender, EventArgs e)
        {
            if (xInicial != null && xFinal != null && yInicial != null && yFinal != null) {
                //Roda o algoritmo
                DDA(xInicial.Value, yInicial.Value, xFinal.Value, yFinal.Value, corPreenche);

                //Salva as coordendas como a ultima reta desenhada
                SalvarBuffer(xInicial, yInicial, xFinal, yFinal, AlgoritmosReta.DDA);

                //Limpa as coordenadas do painel
                LimparIndices();
            }
            else
            {
                MessageBox.Show("Favor preencher as coordenadas inicial e final com valores inteiros válidos", "Erro");
            }
        }

        /*
        * Evento para tratar o clique no botão de Bresenham para retas,
        * onde será verificado se o usuário entrou com os pontos final e inicial.
        * Estando tudo OK, executa o algoritmo e desenha a reta
        */
        private void Btn_Bresenham_Click(object sender, EventArgs e)
        {
            if (xInicial != null && xFinal != null && yInicial != null && yFinal != null)
            {
                //Roda o algoritmo
                BresenhamReta(xInicial.Value, yInicial.Value, xFinal.Value, yFinal.Value, corPreenche);

                //Salva as coordendas como a ultima reta desenhada
                SalvarBuffer(xInicial, yInicial, xFinal, yFinal, AlgoritmosReta.Bresenham);

                //Limpa as coordenadas do painel
                LimparIndices();
            }
            else
            {
                MessageBox.Show("Favor preencher as coordenadas inicial e final com valores inteiros válidos", "Erro");
            }
        }

        /*
        * Evento para tratar o clique no botão de Bresenham para circunferências,
        * onde será verificado se o já existe uma reta para servir de raio.
        * Estando tudo OK, executa o algoritmo e desenha a circunferência
        */
        private void Btn_BresCirc_Click(object sender, EventArgs e)
        {
            if (xInicialBuffer != null && xFinalBuffer != null && yInicialBuffer != null && yFinalBuffer != null)
            {
                //Roda o algoritmo
                BresenhamCirculo(xInicialBuffer.Value, yInicialBuffer.Value, xFinalBuffer.Value, yFinalBuffer.Value, corPreenche);
            }
            else
            {
                MessageBox.Show("Não existe reta na imagem, favor inserir uma reta primeiro", "Erro");
            }
        }

        #endregion

        /*
        * Região contendo metodos utilitarios 
        */
        #region Uteis

        //Seta para nulo as coordenadas finais e iniciais depois de rodar algum algorítmo
        private void LimparIndices()
        {
            xInicial = null;
            xInit.Text = null;

            yInicial = null;
            yInit.Text = null;

            xFinal = null;
            xFim.Text = null;

            yFinal = null;
            yFim.Text = null;
        }

        //Salva as coordenadas atuais no buffer
        private void SalvarBuffer(int? x1, int? y1, int? x2, int? y2, AlgoritmosReta? algoritmo)
        {
            xInicialBuffer = x1;
            yInicialBuffer = y1;

            xFinalBuffer = x2;
            yFinalBuffer = y2;

            algoritmoBuffer = algoritmo;
        }

        #endregion
    }
}
