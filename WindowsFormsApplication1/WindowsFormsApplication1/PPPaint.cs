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

        //Coodenadas da ultima reta desenhada
        //que sera utilizado para rotacionar uma reta
        int? xInicialBuffer = null;
        int? xFinalBuffer = null;

        int? yInicialBuffer = null;
        int? yFinalBuffer = null;

        public tela()
        {
            InitializeComponent();            
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            corPreenche = Color.Black;                       
        }

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
        private void SalvarBuffer(int? x1, int? y1, int? x2, int? y2)
        {
            xInicialBuffer = x1;
            yInicialBuffer = y1;

            xFinalBuffer = x2;
            yFinalBuffer = y2;
        }

        #region Transformacoes Geométricas

        //Aplica a translação desejada na ultima reta desenhada
        public void Translacao(int x1, int y1, int x2, int y2, int xT, int yT)
        {
            if (!(xT == 0 & yT == 0))
            {
                // Apaga a reta atual 
                ApagaReta(x1, y1, x2, y2);

                //Insere a reta alterada
                DDA(x1 + xT, y1 - yT, x2 + xT, y2 - yT, corPreenche);

                //Atualiza os valores do buffer
                SalvarBuffer(x1 + xT, y1 - yT, x2 + xT, y2 - yT);
            }
        }

        public void Escala(int x1, int y1, int x2, int y2, double eX, double eY)
        {
            double tempX, tempY;

            // Apaga a reta atual para a inserção de sua nova versão
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
            SalvarBuffer(x1, y1, x2, y2);
        }


        //Aplica a rotação pelo ângulo desejado na ultima reta desenhada
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
            SalvarBuffer(x1, y1, x2, y2);
        }

        #endregion

        #region Retas

        //Utiliza o algoritmo DDA para desenhar uma reta a partir de seus pontos inicial e final
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

        //Apaga a reta selecionada
        public void ApagaReta(int x1, int y1, int x2, int y2)
        {
            //Traça uma reta da cor do fundo para "excluir" a reta
            DDA(x1, y1, x2, y2, Color.White);
        }

        #endregion

        #region Eventos

        private void BtCor_Click(object sender, EventArgs e)
        {
            DialogResult result = cdlg.ShowDialog();
            if (result == DialogResult.OK)
            {                
                corPreenche = cdlg.Color;
            }
        }

        private void BtApagar_Click(object sender, EventArgs e)
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;

            //Limpa o buffer de reta
            SalvarBuffer(null, null, null, null);
        }

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

        private void Btn_dda_Click(object sender, EventArgs e)
        {
            if (xInicial != null && xFinal != null && yInicial != null && yFinal != null) {
                //Roda o algoritmo
                DDA(xInicial.Value, yInicial.Value, xFinal.Value, yFinal.Value, corPreenche);

                //Salva as coordendas como a ultima reta desenhada
                SalvarBuffer(xInicial, yInicial, xFinal, yFinal);

                //Limpa as coordenadas do painel
                LimparIndices();
            }
            else
            {
                MessageBox.Show("Favor preencher as coordenadas inicial e final com valores inteiros válidos", "Erro");
            }
        }

        #endregion
    }
}
