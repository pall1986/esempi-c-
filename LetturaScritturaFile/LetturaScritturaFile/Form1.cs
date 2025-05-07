using System;
using System.IO;
using System.Windows.Forms;

namespace LetturaScritturaFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textArea.ReadOnly = true;
        }

        // Apri File
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string NomeFile = textPathFile.Text;

            if (File.Exists(NomeFile))
            {
                try
                {
                    StreamReader FileTesto = new StreamReader(NomeFile);
                    string Riga;
                    textArea.Clear();

                    while ((Riga = FileTesto.ReadLine()) != null)
                    {
                        textArea.AppendText(Riga + Environment.NewLine);
                    }

                    FileTesto.Close();
                    textArea.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore nella lettura del file: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Il file specificato non esiste.");
            }
        }

        // Modifica File
        private void button2_Click(object sender, EventArgs e)
        {
            textArea.ReadOnly = false;
            textArea.Focus();
        }

        // Salva File
        private void button3_Click(object sender, EventArgs e)
        {
            string NomeFile = textPathFile.Text;

            try
            {
                StreamWriter FileTesto = new StreamWriter(NomeFile); // Sovrascrive
                string[] righe = textArea.Lines;

                foreach (string riga in righe)
                {
                    FileTesto.WriteLine(riga);
                }

                FileTesto.Close();
                MessageBox.Show("File salvato con successo.");
                textArea.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel salvataggio del file: " + ex.Message);
            }
        }
    }
}
