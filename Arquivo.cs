﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    internal class Arquivo
    {
        string nome, mensagem;
        StreamWriter sw;
        StreamReader sr;

        public Arquivo(string nome)
        {
            this.nome = nome;
        }

        public void CriaArquivo()
        {
            sw = new StreamWriter("C:\\Arquivos\\" + nome + ".txt", true, Encoding.UTF8);
        }

        public void lerArquivo()
        {
            string linha;
            sr = new StreamReader("C:\\Arquivos\\" + nome + ".txt");
            linha = sr.ReadLine();
            while (linha != null)
            {
                Console.WriteLine(linha);
                linha = sr.ReadLine();
            }
            sr.Close();
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
            string[] array = File.ReadAllLines("C:\\Arquivos\\" + nome + ".txt");
            return array;
        }
    }
}
