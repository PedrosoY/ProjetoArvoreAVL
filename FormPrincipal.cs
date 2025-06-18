using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoArvoreAVL
{
    public partial class FormularioPrincipal : Form
    {
        private ArvoreAVL<int> arvore = new ArvoreAVL<int>();
        private List<NoAVL<int>?> historicoEstados = new List<NoAVL<int>?>();
        private int indiceAtual = -1;
        private float zoom = 1.0f;
        private Point panOffset = Point.Empty;
        private Point lastMousePos;
        private bool isPanning = false;

        public FormularioPrincipal()
        {
            InitializeComponent();
            ConfigurarEstiloDataGridView();
        }

        private void ConfigurarEstiloDataGridView()
        {
            dataGridViewLog.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewLog.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void btnAdicionar_Click(object? sender, EventArgs? e)
        {
            if (int.TryParse(txtValorNo.Text, out int valor))
                ExecutarOperacao("I " + valor);
            else
                MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRemover_Click(object? sender, EventArgs? e)
        {
            if (int.TryParse(txtValorNo.Text, out int valor))
                ExecutarOperacao("R " + valor);
            else
                MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBuscar_Click(object? sender, EventArgs? e)
        {
            if (int.TryParse(txtValorNo.Text, out int valor))
                ExecutarOperacao("B " + valor);
            else
                MessageBox.Show("Valor inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPreOrdem_Click(object? sender, EventArgs? e) => ExecutarOperacao("P");
        private void btnBalanceamento_Click(object? sender, EventArgs? e) => ExecutarOperacao("F");
        private void btnAltura_Click(object? sender, EventArgs? e) => ExecutarOperacao("H");

        private void ExecutarOperacao(string comando, bool silencioso = false)
        {
            if (string.IsNullOrWhiteSpace(comando))
                return;

            var partes = comando.Split(' ');
            var acao = partes[0];
            int valor = 0;
            if (acao is "I" or "R" or "B")
            {
                if (partes.Length < 2 || !int.TryParse(partes[1], out valor))
                {
                    MostrarLog(acao, "Parâmetro inválido: " + comando);
                    return;
                }
            }

            switch (acao)
            {
                case "I":
                    if (arvore.Buscar(valor))
                    {
                        if (!silencioso)
                            MessageBox.Show($"O valor {valor} já existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        arvore.Inserir(valor);
                        MostrarLog("I", $"Inserido {valor}");
                        RegistrarEstado();
                        if (!silencioso)
                            AtualizarTextBoxComandos(comando);
                    }
                    break;

                case "R":
                    if (!arvore.Buscar(valor))
                    {
                        if (!silencioso)
                            MessageBox.Show($"O valor {valor} não foi encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        arvore.Remover(valor);
                        MostrarLog("R", $"Removido {valor}");
                        RegistrarEstado();
                        if (!silencioso)
                            AtualizarTextBoxComandos(comando);
                    }
                    break;

                case "B":
                    bool encontrado = arvore.Buscar(valor);
                    MostrarLog("B", encontrado ? "Encontrado" : "Não encontrado");
                    if (!silencioso)
                        AtualizarTextBoxComandos(comando);
                    break;

                case "P":
                    var lista = arvore.PreOrdem();
                    MostrarLog("P", lista.Count > 0 ? string.Join(", ", lista) : "Árvore vazia");
                    if (!silencioso)
                        AtualizarTextBoxComandos(comando);
                    break;

                case "F":
                    var fatores = arvore.ObterFatoresBalanceamento();
                    if (fatores.Count == 0)
                        MostrarLog("F", "Árvore vazia");
                    else
                        foreach (var kv in fatores)
                            MostrarLog("F", $"Nó {kv.Key}: {kv.Value}");
                    if (!silencioso)
                        AtualizarTextBoxComandos(comando);
                    break;

                case "H":
                    MostrarLog("H", $"Altura: {arvore.Altura()}");
                    if (!silencioso)
                        AtualizarTextBoxComandos(comando);
                    break;

                default:
                    MostrarLog("?", "Comando inválido: " + comando);
                    break;
            }
        }

        private void RegistrarEstado()
        {
            historicoEstados.Add(arvore.CloneRaiz());
            indiceAtual = historicoEstados.Count - 1;
            AtualizarIndicador();
            panelHistorico.Invalidate();
        }

        private void MostrarLog(string acao, string resultado)
        {
            dataGridViewLog.Rows.Add(acao, resultado);
            dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;
        }

        private void AtualizarIndicador() => lblIndicador.Text = $"{indiceAtual + 1}/{historicoEstados.Count}";

        private void AtualizarTextBoxComandos(string comando)
        {
            txtHistoricoComandos.TextChanged -= txtHistoricoComandos_TextChanged;
            txtHistoricoComandos.AppendText(comando + Environment.NewLine);
            txtHistoricoComandos.TextChanged += txtHistoricoComandos_TextChanged;
        }

        private void btnCarregarArquivo_Click(object? sender, EventArgs? e)
        {
            using var ofd = new OpenFileDialog { Filter = "*.txt|*.txt" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            var linhas = File.ReadAllLines(ofd.FileName);
            if (MessageBox.Show("Limpar antes?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridViewLog.Rows.Clear();
                txtHistoricoComandos.Clear();
                arvore = new ArvoreAVL<int>();
                historicoEstados.Clear();
                indiceAtual = -1;
                AtualizarIndicador();
                panelHistorico.Invalidate();
            }

            foreach (var linha in linhas)
                ExecutarOperacao(linha);
        }

        private void panelHistorico_Paint(object? sender, PaintEventArgs? e)
        {
            if (indiceAtual < 0 || indiceAtual >= historicoEstados.Count || historicoEstados[indiceAtual] is null)
                return;

            var g = e!.Graphics;

            g.TranslateTransform(panOffset.X, panOffset.Y);
            g.ScaleTransform(zoom, zoom);

            DesenharNo(g, historicoEstados[indiceAtual]!, panelHistorico.ClientRectangle, 0);
        }
        private void PanelHistorico_MouseWheel(object? sender, MouseEventArgs e)
        {
            float oldZoom = zoom;
            if (e.Delta > 0)
                zoom *= 1.1f;
            else
                zoom /= 1.1f;

            // Ajustar o pan para manter o ponto do mouse estável
            var mousePos = e.Location;
            panOffset.X = (int)(mousePos.X - (mousePos.X - panOffset.X) * (zoom / oldZoom));
            panOffset.Y = (int)(mousePos.Y - (mousePos.Y - panOffset.Y) * (zoom / oldZoom));

            panelHistorico.Invalidate();
        }

        private void PanelHistorico_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = true;
                lastMousePos = e.Location;
                panelHistorico.Cursor = Cursors.Hand;
            }
        }

        private void PanelHistorico_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isPanning)
            {
                panOffset.X += e.X - lastMousePos.X;
                panOffset.Y += e.Y - lastMousePos.Y;
                lastMousePos = e.Location;
                panelHistorico.Invalidate();
            }
        }

        private void PanelHistorico_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isPanning = false;
                panelHistorico.Cursor = Cursors.Default;
            }
        }


        private void btnPrevStep_Click(object? sender, EventArgs? e)
        {
            if (indiceAtual > 0) indiceAtual--;
            AtualizarIndicador();
            panelHistorico.Invalidate();
        }

        private void btnNextStep_Click(object? sender, EventArgs? e)
        {
            if (indiceAtual < historicoEstados.Count - 1) indiceAtual++;
            AtualizarIndicador();
            panelHistorico.Invalidate();
        }

        private void DesenharNo(Graphics g, NoAVL<int> no, Rectangle area, int profundidade)
        {
            int alturaMax = Math.Max(1, arvore.Altura());
            int y = (profundidade + 1) * area.Height / (alturaMax + 1);
            int total = ContarNos(no);
            int esquerda = ContarNos(no.Esquerda);
            int x = area.X + (area.Width * (esquerda + 1)) / (total + 1);

            if (no.Esquerda is not null)
            {
                var areaEsquerda = new Rectangle(area.X, area.Y, area.Width * esquerda / total, area.Height);
                int x2 = areaEsquerda.X + areaEsquerda.Width * (ContarNos(no.Esquerda.Esquerda) + 1) / (ContarNos(no.Esquerda) + 1);
                int y2 = (profundidade + 2) * area.Height / (alturaMax + 1);
                g.DrawLine(Pens.White, x, y, x2, y2);
                DesenharNo(g, no.Esquerda, areaEsquerda, profundidade + 1);
            }

            if (no.Direita is not null)
            {
                var areaDireita = new Rectangle(
                    area.X + area.Width * (esquerda + 1) / (total + 1),
                    area.Y,
                    area.Width * ContarNos(no.Direita) / (total + 1),
                    area.Height);
                int x2 = areaDireita.X + areaDireita.Width * (ContarNos(no.Direita.Esquerda) + 1) / (ContarNos(no.Direita) + 1);
                int y2 = (profundidade + 2) * area.Height / (alturaMax + 1);
                g.DrawLine(Pens.White, x, y, x2, y2);
                DesenharNo(g, no.Direita, areaDireita, profundidade + 1);
            }

            const int raio = 20;
            var rect = new Rectangle(x - raio, y - raio, raio * 2, raio * 2);
            g.FillEllipse(Brushes.DarkGray, rect);
            g.DrawEllipse(Pens.White, rect);
            var txt = no.Valor.ToString();
            var tam = g.MeasureString(txt, Font);
            g.DrawString(txt, Font, Brushes.White, x - tam.Width / 2, y - tam.Height / 2);
        }

        private int ContarNos(NoAVL<int>? no)
            => no is null ? 0 : 1 + ContarNos(no.Esquerda) + ContarNos(no.Direita);

        private void txtHistoricoComandos_TextChanged(object? sender, EventArgs? e)
        {
            txtHistoricoComandos.TextChanged -= txtHistoricoComandos_TextChanged;

            arvore = new ArvoreAVL<int>();
            dataGridViewLog.Rows.Clear();
            historicoEstados.Clear();
            indiceAtual = -1;
            AtualizarIndicador();
            panelHistorico.Invalidate();

            var linhas = txtHistoricoComandos.Text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var linha in linhas)
            {
                ExecutarOperacao(linha, silencioso: true);
            }

            txtHistoricoComandos.TextChanged += txtHistoricoComandos_TextChanged;
        }

        private void panelHistorico_MouseEnter(object sender, EventArgs e)
        {
            panelHistorico.Focus();
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            if (indiceAtual < 0 || indiceAtual >= historicoEstados.Count || historicoEstados[indiceAtual] is null)
                return;

            zoom = 1.0f;

            var no = historicoEstados[indiceAtual]!;
            int total = ContarNos(no);
            int esquerda = ContarNos(no.Esquerda);
            int areaWidth = panelHistorico.Width;
            int xRaiz = (areaWidth * (esquerda + 1)) / (total + 1);

            int centroPainel = panelHistorico.Width / 2;
            panOffset = new Point(centroPainel - xRaiz, 20);

            panelHistorico.Invalidate();
        }

        private int MedirLarguraVisual(NoAVL<int>? no)
        {
            if (no == null)
                return 0;
            if (no.Esquerda == null && no.Direita == null)
                return 1;

            return MedirLarguraVisual(no.Esquerda) + MedirLarguraVisual(no.Direita);
        }

        public class NoAVL<T> where T : IComparable<T>
        {
            public T Valor { get; set; }
            public NoAVL<T>? Esquerda { get; set; }
            public NoAVL<T>? Direita { get; set; }
            public int Altura { get; set; }

            public NoAVL(T valor)
            {
                Valor = valor;
                Altura = 1;
            }
        }

        public class ArvoreAVL<T> where T : IComparable<T>
        {
            public NoAVL<T>? Root { get; private set; }

            public void Inserir(T valor) => Root = Inserir(Root, valor);
            public void Remover(T valor) => Root = Remover(Root, valor);
            public bool Buscar(T valor) => Buscar(Root, valor);
            public NoAVL<T>? CloneRaiz() => ClonarNo(Root);

            private NoAVL<T>? ClonarNo(NoAVL<T>? no)
            {
                if (no is null) return null;
                var copia = new NoAVL<T>(no.Valor) { Altura = no.Altura };
                copia.Esquerda = ClonarNo(no.Esquerda);
                copia.Direita = ClonarNo(no.Direita);
                return copia;
            }

            public List<T> PreOrdem()
            {
                var lista = new List<T>();
                Pre(Root, lista);
                return lista;
            }

            private void Pre(NoAVL<T>? no, List<T> lista)
            {
                if (no is null)
                    return;

                lista.Add(no.Valor);
                Pre(no.Esquerda, lista);
                Pre(no.Direita, lista);
            }

            public Dictionary<T, int> ObterFatoresBalanceamento()
            {
                var dict = new Dictionary<T, int>();
                Percorrer(Root, dict);
                return dict;
            }

            private void Percorrer(NoAVL<T>? no, Dictionary<T, int> dict)
            {
                if (no is null) return;
                int alturaEsq = no.Esquerda?.Altura ?? 0;
                int alturaDir = no.Direita?.Altura ?? 0;
                dict[no.Valor] = alturaEsq - alturaDir;
                Percorrer(no.Esquerda, dict);
                Percorrer(no.Direita, dict);
            }

            public int Altura() => Root?.Altura ?? 0;

            private NoAVL<T>? Inserir(NoAVL<T>? no, T valor)
            {
                if (no is null) return new NoAVL<T>(valor);
                int cmp = valor.CompareTo(no.Valor);
                if (cmp < 0)
                    no.Esquerda = Inserir(no.Esquerda, valor);
                else if (cmp > 0)
                    no.Direita = Inserir(no.Direita, valor);
                else
                    return no;

                AtualizarAltura(no);
                return Balancear(no);
            }

            private NoAVL<T>? Remover(NoAVL<T>? no, T valor)
            {
                if (no is null) return null;
                int cmp = valor.CompareTo(no.Valor);
                if (cmp < 0)
                    no.Esquerda = Remover(no.Esquerda, valor);
                else if (cmp > 0)
                    no.Direita = Remover(no.Direita, valor);
                else
                {
                    if (no.Esquerda is null) return no.Direita;
                    if (no.Direita is null) return no.Esquerda;
                    var sucessor = EncontrarMin(no.Direita)!;
                    no.Valor = sucessor.Valor;
                    no.Direita = Remover(no.Direita, sucessor.Valor);
                }

                AtualizarAltura(no);
                return Balancear(no);
            }

            private NoAVL<T>? EncontrarMin(NoAVL<T>? no)
            {
                while (no?.Esquerda is not null)
                    no = no.Esquerda;
                return no;
            }

            private bool Buscar(NoAVL<T>? no, T valor)
                => no is null ? false
                   : valor.CompareTo(no.Valor) < 0 ? Buscar(no.Esquerda, valor)
                   : valor.CompareTo(no.Valor) > 0 ? Buscar(no.Direita, valor)
                   : true;

            private void AtualizarAltura(NoAVL<T> no)
                => no.Altura = 1 + Math.Max(no.Esquerda?.Altura ?? 0, no.Direita?.Altura ?? 0);

            private NoAVL<T> Balancear(NoAVL<T> no)
            {
                int fator = (no.Esquerda?.Altura ?? 0) - (no.Direita?.Altura ?? 0);
                if (fator > 1 && ((no.Esquerda?.Esquerda?.Altura ?? 0) >= (no.Esquerda?.Direita?.Altura ?? 0)))
                    return RotacionarDireita(no);
                if (fator > 1)
                    return RotacionarDireitaComRotacaoEsquerda(no);
                if (fator < -1 && ((no.Direita?.Direita?.Altura ?? 0) >= (no.Direita?.Esquerda?.Altura ?? 0)))
                    return RotacionarEsquerda(no);
                if (fator < -1)
                    return RotacionarEsquerdaComRotacaoDireita(no);
                return no;
            }

            private NoAVL<T> RotacionarDireita(NoAVL<T> y)
            {
                var x = y.Esquerda!;
                y.Esquerda = x.Direita;
                x.Direita = y;
                AtualizarAltura(y);
                AtualizarAltura(x);
                return x;
            }

            private NoAVL<T> RotacionarEsquerda(NoAVL<T> x)
            {
                var y = x.Direita!;
                x.Direita = y.Esquerda;
                y.Esquerda = x;
                AtualizarAltura(x);
                AtualizarAltura(y);
                return y;
            }

            private NoAVL<T> RotacionarDireitaComRotacaoEsquerda(NoAVL<T> no)
            {
                no.Esquerda = RotacionarEsquerda(no.Esquerda!);
                return RotacionarDireita(no);
            }

            private NoAVL<T> RotacionarEsquerdaComRotacaoDireita(NoAVL<T> no)
            {
                no.Direita = RotacionarDireita(no.Direita!);
                return RotacionarEsquerda(no);
            }
        }
    }
}
