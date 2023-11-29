using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    internal class Arquivo
    {
        string nome, prefixo;
        StreamWriter sw;

        public Arquivo(string nome, string prefixo)
        {
            this.nome = nome;
            this.prefixo = prefixo;
        }

        public void CriaArquivo()
        {
            sw = new StreamWriter("C:\\Arquivos\\" + nome + prefixo + ".txt", true, Encoding.UTF8);
        }

        public void GravaMensagem(string mensagem)
        {
            sw.WriteLine(mensagem);
        }

        public void FecharArquivo()
        {
            sw.Close();
        }

        public string[] LerTodasLinhas()
        {
            string[] array = File.ReadAllLines("C:\\Arquivos\\" + nome + prefixo + ".txt");
            return array;
        }
    }
}
