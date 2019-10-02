using System;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;

namespace conversorDocpdf
{
    public partial class Form1 : Form
    {
        public string nome { get; set; } = "";
        public string Origem { get; set; } = "";
        public string Destino { get; set; } = "";
        public int TotalFicheiros { get; set; }
        public int FicheirosConvertidos1 { get; set; }
        public int FicheirosConvertidos { get; set; }
        public int FicheirosNomesFalhados { get; set; }
        public bool Cancelar { get; set; } = false;
        public Microsoft.Office.Interop.Word.Application appWord;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btn_destino_Click(object sender, EventArgs e)
        {
            fbd_1.ShowDialog();
            Destino = fbd_1.SelectedPath + "\\";
            lbl_destino.Text = Destino;
        }

        private void btn_origem_Click(object sender, EventArgs e)
        {
            fbd_1.ShowDialog();
            Origem = fbd_1.SelectedPath+"\\";
            lbl_origem.Text = Origem;
        }

        private void btn_converter_Click(object sender, EventArgs e)
        {
            nome = "";
            if (Origem.Length == 0)
            {
                MessageBox.Show("Tem de escolher uma pasta de origem com manuais para converter", "Escolha origem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Destino.Length == 0)
            {
                MessageBox.Show("Tem de escolher uma pasta de destino para as conversões dos manuais", "Escolha destino",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cancelar = false;
            FicheirosConvertidos = 0;
            FicheirosNomesFalhados = 0;
            TotalFicheiros = ContarFicheirosConverter(Origem);
            AtualizarProgressoForm();

            MostrarControlos(lbl_a_converter, progress, lbl_progresso, btn_cancelar);
            
            //lança a convesão dos pdfs em todas as subpastas numa thread separada em background
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                appWord = new Microsoft.Office.Interop.Word.Application();

                ConverterPastasPDF(Origem, Destino);
                appWord.Quit();
            }).Start();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Cancelar = true;
            EsconderControlos(lbl_a_converter, progress, lbl_progresso, btn_cancelar);
            nome = "";
        }

        private void MostrarControlos(params Control[] controlos)
        {
            AlterarVisibilidadeControlos(true, controlos);
        }

        private void EsconderControlos(params Control[] controlos)
        {
            AlterarVisibilidadeControlos(false, controlos);
        }

        /// <summary>
        /// Altera a visibilidade de todos os controlos passados como parametro para o valor escolhido
        /// O valor é indicado pelo primeiro parametro do método
        /// </summary>
        /// <param name="visibilidade">Visibilidade a aplicar a todos os controlos</param>
        /// <param name="controlos">Controlos a alterar a visibilidade</param>
        private void AlterarVisibilidadeControlos(bool visibilidade, params Control[] controlos)
        {
            foreach(Control controlo in controlos)
            {
                controlo.Visible = visibilidade;
            }
        }

        /// <summary>
        /// Atualiza o progresso da conversão no formulário através do metodo Invoke pois a conversão
        /// é feita numa Thread em background. Quando o progresso chega a 100 mostra a quantidade de 
        /// ficheiros convertidos no total
        /// </summary>
        private void AtualizarProgressoForm()
        {
            Invoke((MethodInvoker)delegate
            {
                progress.Value = (int)(((double)FicheirosConvertidos / TotalFicheiros) * 100);
                progress.Invalidate();
                lbl_progresso.Text = $"{FicheirosConvertidos} de {TotalFicheiros}";
                lbl_progresso.Invalidate();
                lbl_atual.Text = nome;
                if (progress.Value == 100)
                {
                    EsconderControlos(lbl_a_converter, progress, lbl_progresso, btn_cancelar);

                    if (FicheirosNomesFalhados == 0)
                    {
                        MessageBox.Show(TotalFicheiros + " ficheiros verificados e "+FicheirosConvertidos1 +" convertidos", "Conversão terminada",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else 
                    {
                        MessageBox.Show($"{TotalFicheiros} ficheiros verificados, {FicheirosConvertidos1}  ficheiros convertidos e {FicheirosNomesFalhados} convertidos sem troca de nome", 
                            "Conversão terminada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lbl_atual.Text = "";
                }
            });
        }
 
        /// <summary>
        /// Remove a numeração de um nome de um ficheiro.
        /// De "1 - Introdução.docx" deve ficar "Introdução.docx"
        /// </summary>
        /// <param name="nomeFicheiro">nome do ficheiro a remover a numeração</param>
        /// <returns>Nome do ficheiro sem numeração ou o nome original se não houver nenhum traço no nome</returns>
        public string RemoverNumeracao(string nomeFicheiro)
        {
            if (!nomeFicheiro.Contains("-")) //se não tem traço não da para remover numeracao
            {
                return nomeFicheiro;
            }

            //ESTE CÓDIGO ASSUME QUE SE HOUVER UM TRAÇO NO NOME DO FICHEIRO, A PRIMEIRA PARTE É O NUMERO DO MODULO
            string[] nomeSeparadoTracos = nomeFicheiro.Split('-');            
            nomeSeparadoTracos[1] = nomeSeparadoTracos[1].TrimStart(); //remover espaço que ligava com o numero
            return string.Join("-", nomeSeparadoTracos.Skip(1));            
        }
        
        /// <summary>
        /// Exporta o ficheiro de word indicado pelo caminho para PDF na pasta indicada por pastaDestino
        /// Cria a pasta de destino se ela ainda não existir. Caso a conversão falhe por recurso ocupado
        /// volta a tentar passado um pequeno delay dado com Thread.Sleep
        /// </summary>
        /// <param name="caminho">caminho do ficheiro word a converter</param>
        /// <param name="pastaDestino">pasta de destino a colocar o pdf</param>
        private void ExportarPDF(string caminho, string pastaDestino)
        {
            try
            {
                //Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
                FileInfo ficheiro = new FileInfo(caminho);

                string novoNome = ficheiro.Name;
                if (chk_remover_numeracao.Checked)
                {
                    novoNome = RemoverNumeracao(ficheiro.Name);
                    if (ficheiro.Name == novoNome) //remoção de numero falhou
                    {
                        FicheirosNomesFalhados++;
                    }
                }

                //troca extensão do ficheiro de destino para .pdf
                string caminhoPDF = pastaDestino + "\\" + novoNome.Replace(ficheiro.Extension, ".pdf");
                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }
                if (!File.Exists(caminhoPDF) || chk_replace.Checked == true)
                {
                    nome = ""+caminhoPDF;
                    Document docWord = appWord.Documents.Open(caminho);
                    docWord.ExportAsFixedFormat(caminhoPDF, WdExportFormat.wdExportFormatPDF);
                    docWord.Close(false); //Sair sem guardar (alguns modulos davam erros ao fechar)
                                          //appWord.Quit();
                    FicheirosConvertidos1++;
                }
                FicheirosConvertidos++;
                AtualizarProgressoForm();
            }
            catch (COMException) //falha por recurso ocupado
            {
                Thread.Sleep(1200); //esperar e voltar a tentar
                ExportarPDF(caminho, pastaDestino);
            }
        }

        /// <summary>
        /// Exporta todos os ficheiros word(doc, docx) de uma pasta para pdf, e volta a chamar a mesma função
        /// recursivamente para todas as subpastas. A exportação é feita para a pasta de destino
        /// mantendo a estrutura de subpastas que existe na pasta de origem
        /// </summary>
        /// <param name="pastaOrigem">pasta de origem</param>
        /// <param name="pastaDestino">pasta de destino</param>
        private void ConverterPastasPDF(string pastaOrigem, string pastaDestino)
        {
            DirectoryInfo pasta = new DirectoryInfo(pastaOrigem);
           
            FileInfo[] ficheiros = pasta.GetFiles();
            foreach (FileInfo ficheiro in ficheiros)
            {
               
                if (!ficheiro.Name.StartsWith("~$")&&( ficheiro.Extension == ".doc" || ficheiro.Extension == ".docx"))
                {
                    ExportarPDF(ficheiro.FullName, pastaDestino);
                   
                    //Ao criar-se apenas um objecto, deixa de ser necessário 
                    // Thread.Sleep(700); //espaçar cada conversão para evitar falhar por recurso ocupado


                    if (Cancelar)
                    {
                        return;
                    }
                }                
            }
                        
            DirectoryInfo[] subPastas = pasta.GetDirectories();
            foreach (DirectoryInfo subPasta in subPastas)
            {
                ConverterPastasPDF(subPasta.FullName, pastaDestino + "\\" + subPasta.Name);
            }
            
        }

        /// <summary>
        /// Conta todos os ficheiros de word(doc, docx) a converter numa determinada pasta e subpastas
        /// </summary>
        /// <param name="caminhoPasta">Pasta a partir de onde é feita a contagem</param>
        /// <returns>A quantidade total de ficheiros existente na estrutura de pastas</returns>
        private int ContarFicheirosConverter(string caminhoPasta)
        {
            int total = 0;
            DirectoryInfo pasta = new DirectoryInfo(caminhoPasta);

            FileInfo[] ficheiros = pasta.GetFiles();
            foreach (FileInfo ficheiro in ficheiros)
            {
                if (!ficheiro.Name.StartsWith("~$") && (ficheiro.Extension == ".doc" || ficheiro.Extension == ".docx"))
                {
                    total++;
                }
            }

            DirectoryInfo[] subPastas = pasta.GetDirectories();
            foreach (DirectoryInfo subPasta in subPastas)
            {
                total += ContarFicheirosConverter(subPasta.FullName);
            }
            return total;
        }
    }
}
