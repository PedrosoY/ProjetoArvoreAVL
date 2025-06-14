using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProjetoArvoreAVL
{
    public partial class FormPrincipal : Form
    {
        private AVLTree<int> avl = new AVLTree<int>();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void AtualizarVisualizacao()
        {
            panelDesenho.Invalidate();
        }
        private void btnInserir_Click(object sender, EventArgs e)
            => ProcessarComando($"I {txtValor.Text}");

        private void btnRemover_Click(object sender, EventArgs e)
            => ProcessarComando($"R {txtValor.Text}");

        private void btnBuscar_Click(object sender, EventArgs e)
            => ProcessarComando($"B {txtValor.Text}");

        private void btnPreOrdem_Click(object sender, EventArgs e)
            => ProcessarComando("P");

        private void btnFatores_Click(object sender, EventArgs e)
            => ProcessarComando("F");

        private void btnAltura_Click(object sender, EventArgs e)
            => ProcessarComando("H");

        private void Log(string comando, string resultado)
        {
            dataGridViewLog.Rows.Add(comando, resultado);

            // Rolar automaticamente para a última linha
            if (dataGridViewLog.RowCount > 0)
                dataGridViewLog.FirstDisplayedScrollingRowIndex = dataGridViewLog.RowCount - 1;
        }

        private void ProcessarComando(string linha)
        {
            if (string.IsNullOrWhiteSpace(linha)) return;
            var parts = linha.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var cmd = parts[0].ToUpper();
            int val;

            switch (cmd)
            {
                case "I":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        avl.Insert(val);
                        Log("I", $"Inserido {val}");
                    }
                    else
                        Log("I", $"Parâmetro inválido em: {linha}");
                    break;

                case "R":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        avl.Remove(val);
                        Log("R", $"Removido {val}");
                    }
                    else
                        Log("R", $"Parâmetro inválido em: {linha}");
                    break;

                case "B":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        bool found = avl.Search(val);
                        Log("B", found ? "Valor encontrado" : "Valor não encontrado");
                    }
                    else
                        Log("B", $"Parâmetro inválido em: {linha}");
                    break;


                case "P":
                    var ordem = avl.PreOrder();
                    if (ordem.Count > 0)
                        Log("P", $"Árvore em pré-ordem: {string.Join(" ", ordem)}");
                    else
                        Log("P", "Árvore vazia");
                    break;

                case "F":
                    {
                        var fatores = avl.BalanceFactors();
                        if (fatores.Count > 0)
                        {
                            Log("F", "Fatores de balanceamento:");
                            foreach (var kv in fatores)
                                Log("F", $"Nó {kv.Key}: Fator de balanceamento {kv.Value}");
                        }
                        else
                        {
                            Log("F", "Árvore vazia ou sem fatores para exibir");
                        }
                        break;
                    }

                case "H":
                    Log("H", $"Altura da árvore: {avl.Height()}");
                    break;


                default:
                    Log("?", $"Comando inválido: {linha}");
                    break;
            }

            txtBoxLinhasCodigoAtual.TextChanged -= txtBoxLinhasCodigoAtual_TextChanged;
            txtBoxLinhasCodigoAtual.AppendText(linha + Environment.NewLine);
            txtBoxLinhasCodigoAtual.TextChanged += txtBoxLinhasCodigoAtual_TextChanged;

            AtualizarVisualizacao();
        }

        private void btnLerArquivoTxT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text files (*.txt)|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var linhas = File.ReadAllLines(ofd.FileName);

                    // Perguntar ao usuário se ele quer resetar a árvore
                    var resposta = MessageBox.Show(
                        "Deseja limpar a árvore e o log antes de carregar o arquivo?",
                        "Confirmar Reset",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (resposta == DialogResult.Yes)
                    {
                        dataGridViewLog.Rows.Clear();
                        avl = new AVLTree<int>();
                        txtBoxLinhasCodigoAtual.Clear();
                    }

                    foreach (var linha in linhas)
                        ProcessarComando(linha);
                }
            }
        }


        private void panelDesenho_Paint(object sender, PaintEventArgs e)
        {
            if (avl.Root != null)
            {
                var area = panelDesenho.ClientRectangle;
                DesenharNo(e.Graphics, avl.Root, area, 0);
            }
        }

        private void DesenharNo(Graphics g, AVLNode<int> node, Rectangle area, int depth)
        {
            int nivelMax = Math.Max(1, avl.Height());
            // calcula posição Y do nó
            int y = (depth + 1) * area.Height / (nivelMax + 1);

            // subdivide horizontalmente a área proporcional ao tamanho da subárvore
            int total = CountNodes(node);
            int leftCount = CountNodes(node.Left);
            int x = area.X + (area.Width * (leftCount + 1)) / (total + 1);

            // desenha linha para filho esquerdo
            if (node.Left != null)
            {
                var leftArea = new Rectangle(area.X, area.Y, area.Width * leftCount / total, area.Height);
                int x2 = leftArea.X + leftArea.Width * (CountNodes(node.Left.Left) + 1) / (CountNodes(node.Left) + 1);
                int y2 = (depth + 2) * area.Height / (nivelMax + 1);
                g.DrawLine(Pens.White, x, y, x2, y2);
                DesenharNo(g, node.Left, leftArea, depth + 1);
            }

            // desenha linha para filho direito
            if (node.Right != null)
            {
                var rightArea = new Rectangle(
                    area.X + area.Width * (leftCount + 1) / (total + 1),
                    area.Y,
                    area.Width * (CountNodes(node.Right)) / (total + 1),
                    area.Height);
                int x2 = rightArea.X + rightArea.Width * (CountNodes(node.Right.Left) + 1) / (CountNodes(node.Right) + 1);
                int y2 = (depth + 2) * area.Height / (nivelMax + 1);
                g.DrawLine(Pens.White, x, y, x2, y2);
                DesenharNo(g, node.Right, rightArea, depth + 1);
            }

            // desenha o próprio nó
            var raio = 20;
            var rect = new Rectangle(x - raio, y - raio, raio * 2, raio * 2);
            g.FillEllipse(Brushes.DarkGray, rect);
            g.DrawEllipse(Pens.White, rect);
            var txt = node.Value.ToString();
            var sz = g.MeasureString(txt, this.Font);
            g.DrawString(txt, this.Font, Brushes.White, x - sz.Width / 2, y - sz.Height / 2);
        }

        private int CountNodes(AVLNode<int> node)
        {
            if (node == null) return 0;
            return 1 + CountNodes(node.Left) + CountNodes(node.Right);
        }

        private void txtBoxLinhasCodigoAtual_TextChanged(object sender, EventArgs e)
        {
            // Evita loop infinito ao editar o próprio txtBox programaticamente
            txtBoxLinhasCodigoAtual.TextChanged -= txtBoxLinhasCodigoAtual_TextChanged;

            // Resetar árvore e log
            avl = new AVLTree<int>();
            dataGridViewLog.Rows.Clear();

            // Processar cada linha
            var linhas = txtBoxLinhasCodigoAtual.Text.Split(
                new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var linha in linhas)
                ProcessarComandoSemReescreverCaixaTexto(linha);

            AtualizarVisualizacao();

            // Reassocia o evento
            txtBoxLinhasCodigoAtual.TextChanged += txtBoxLinhasCodigoAtual_TextChanged;
        }



        private void ProcessarComandoSemReescreverCaixaTexto(string linha)
        {
            if (string.IsNullOrWhiteSpace(linha)) return;

            var parts = linha.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var cmd = parts[0].ToUpper();
            int val;

            switch (cmd)
            {
                case "I":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        avl.Insert(val);
                        Log("I", $"Inserido {val}");
                    }
                    else
                        Log("I", $"Parâmetro inválido em: {linha}");
                    break;

                case "R":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        avl.Remove(val);
                        Log("R", $"Removido {val}");
                    }
                    else
                        Log("R", $"Parâmetro inválido em: {linha}");
                    break;


                case "B":
                    if (parts.Length > 1 && int.TryParse(parts[1], out val))
                    {
                        bool found = avl.Search(val);
                        Log("B", found ? "Valor encontrado" : "Valor não encontrado");
                    }
                    else
                        Log("B", $"Parâmetro inválido em: {linha}");
                    break;


                case "P":
                    var ordem = avl.PreOrder();
                    if (ordem.Count > 0)
                        Log("P", $"Árvore em pré-ordem: {string.Join(" ", ordem)}");
                    else
                        Log("P", "Árvore vazia");
                    break;


                case "F":
                    var fatores = avl.BalanceFactors();
                    if (fatores.Count > 0)
                        Log("F", "Fatores de balanceamento:");
                    foreach (var kv in fatores)
                        Log("F", $"Nó {kv.Key}: Fator de balanceamento {kv.Value}");
                    break;


                case "H":
                    Log("H", $"Altura da árvore: {avl.Height()}");
                    break;

                default:
                    Log("?", $"Comando inválido: {linha}");
                    break;
            }
        }


        // --- Classe de nó AVL ---
        public class AVLNode<T> where T : IComparable<T>
        {
            public T Value;
            public AVLNode<T> Left;
            public AVLNode<T> Right;
            public int Height;

            public AVLNode(T value)
            {
                Value = value;
                Height = 1;
            }
        }

        // --- Implementação de Árvore AVL ---
        public class AVLTree<T> where T : IComparable<T>
        {
            public AVLNode<T> Root;

            public void Insert(T key) => Root = Insert(Root, key);
            public void Remove(T key) => Root = Remove(Root, key);
            public bool Search(T key) => Search(Root, key);
            public List<T> PreOrder()
            {
                var list = new List<T>();
                PreOrder(Root, list);
                return list;
            }
            public Dictionary<T, int> BalanceFactors()
            {
                var dict = new Dictionary<T, int>();
                Traverse(Root, dict);
                return dict;
            }
            public int Height() => Root?.Height ?? 0;

            private AVLNode<T> Insert(AVLNode<T> node, T key)
            {
                if (node == null) return new AVLNode<T>(key);
                int cmp = key.CompareTo(node.Value);
                if (cmp < 0)
                    node.Left = Insert(node.Left, key);
                else if (cmp > 0)
                    node.Right = Insert(node.Right, key);
                else
                    return node;

                UpdateHeight(node);
                return Balance(node);
            }

            private AVLNode<T> Remove(AVLNode<T> node, T key)
            {
                if (node == null) return null;
                int cmp = key.CompareTo(node.Value);
                if (cmp < 0)
                    node.Left = Remove(node.Left, key);
                else if (cmp > 0)
                    node.Right = Remove(node.Right, key);
                else
                {
                    if (node.Left == null) return node.Right;
                    if (node.Right == null) return node.Left;

                    var min = MinValueNode(node.Right);
                    node.Value = min.Value;
                    node.Right = Remove(node.Right, min.Value);
                }

                UpdateHeight(node);
                return Balance(node);
            }

            private bool Search(AVLNode<T> node, T key)
            {
                if (node == null) return false;
                int cmp = key.CompareTo(node.Value);
                if (cmp < 0) return Search(node.Left, key);
                if (cmp > 0) return Search(node.Right, key);
                return true;
            }

            private void PreOrder(AVLNode<T> node, List<T> list)
            {
                if (node == null) return;
                list.Add(node.Value);
                PreOrder(node.Left, list);
                PreOrder(node.Right, list);
            }

            private void Traverse(AVLNode<T> node, Dictionary<T, int> dict)
            {
                if (node == null) return;
                int lh = node.Left?.Height ?? 0;
                int rh = node.Right?.Height ?? 0;
                dict[node.Value] = lh - rh;
                Traverse(node.Left, dict);
                Traverse(node.Right, dict);
            }

            private AVLNode<T> MinValueNode(AVLNode<T> node)
            {
                while (node.Left != null) node = node.Left;
                return node;
            }
            private AVLNode<T> MaxValueNode(AVLNode<T> node)
            {
                while (node.Right != null) node = node.Right;
                return node;
            }

            private void UpdateHeight(AVLNode<T> node)
            {
                int lh = node.Left?.Height ?? 0;
                int rh = node.Right?.Height ?? 0;
                node.Height = 1 + Math.Max(lh, rh);
            }

            private AVLNode<T> Balance(AVLNode<T> node)
            {
                int balance = (node.Left?.Height ?? 0) - (node.Right?.Height ?? 0);

                // LL
                if (balance > 1 && (node.Left.Left?.Height ?? 0) >= (node.Left.Right?.Height ?? 0))
                    return RotateRight(node);

                // LR
                if (balance > 1 && (node.Left.Left?.Height ?? 0) < (node.Left.Right?.Height ?? 0))
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }

                // RR
                if (balance < -1 && (node.Right.Right?.Height ?? 0) >= (node.Right.Left?.Height ?? 0))
                    return RotateLeft(node);

                // RL
                if (balance < -1 && (node.Right.Right?.Height ?? 0) < (node.Right.Left?.Height ?? 0))
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }

            private AVLNode<T> RotateRight(AVLNode<T> y)
            {
                var x = y.Left;
                y.Left = x.Right;
                x.Right = y;
                UpdateHeight(y);
                UpdateHeight(x);
                return x;
            }

            private AVLNode<T> RotateLeft(AVLNode<T> x)
            {
                var y = x.Right;
                x.Right = y.Left;
                y.Left = x;
                UpdateHeight(x);
                UpdateHeight(y);
                return y;
            }
        }
    }
}