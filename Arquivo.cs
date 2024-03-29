﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    internal class Arquivo
    {
        string nome, prefixo, caminho;
        StreamWriter sw;

        public Arquivo(string nome, string prefixo)
        {
            this.nome = nome;
            this.prefixo = prefixo;
            caminho = "C:\\Arquivos\\" + nome + prefixo + ".txt";

            CreateFolder();
        }

        public void CreateFolder()
        {
            string path = "C:\\Arquivos\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateFile()
        {
            sw = new StreamWriter(caminho, true, Encoding.UTF8); //Criar novo arquivo
        }

        public void SaveList<T>(List<T> lista) where T : IGetInfo //O T vai implementar a interface IGetInfo
        {
            try
            {
                foreach (var i in lista)
                {
                    sw.WriteLine($"{i.GetType().Name};{i.GetInfo()};"); //o elemento I assume que os elementos vão ter essa interface/função implementada
                }
            }
            catch (Exception ex) { Console.WriteLine("ERROR! " + ex); }
        }

        public void LoadCharacterList(List<Personagem> listaPersonagens)
        {
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);

                foreach (var linha in linhas)
                {
                    string[] aux = linha.Split(';');
                    
                    string tipoClasse = aux[0]; //Tipo da classe// GetType().Names
                    string nome = aux[1];
                    int forca = Convert.ToInt32(aux[2]);
                    int estamina = Convert.ToInt32(aux[3]);
                    int agilidade = Convert.ToInt32(aux[4]);
                    int inteligencia = Convert.ToInt32(aux[5]);
                    int carisma = Convert.ToInt32(aux[6]);
                    double x = Convert.ToDouble(aux[7]);
                    double y = Convert.ToDouble(aux[8]);
                    double z = Convert.ToDouble(aux[9]);

                    Personagem novoPersonagem;

                    if (tipoClasse == nameof(PersonagemJogavel))
                    {
                        novoPersonagem = new PersonagemJogavel { Nome = nome, Forca = forca, Estamina = estamina, Agilidade = agilidade, 
                            Inteligencia = inteligencia, Carisma = carisma};
                        novoPersonagem.SetPos(x, y, z);
                    }
                    else if (tipoClasse == nameof(NPC))
                    {
                        novoPersonagem = new NPC { Nome = nome, Forca = forca, Estamina = estamina, Agilidade = agilidade, 
                            Inteligencia = inteligencia, Carisma = carisma};
                        novoPersonagem.SetPos(x, y, z);
                    }
                    else //Só para garantir que não vai crashar
                    {
                        Console.WriteLine("Tipo de classe desconhecido!");
                        continue;
                    }
                    listaPersonagens.Add(novoPersonagem);
                }
            }
            else Console.WriteLine("Arquivo inexistente!");
        }

        public void LoadItemList(List<Item> listaItem)
        {
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);

                foreach (var linha in linhas)
                {
                    string[] aux = linha.Split(';');
                    string owner = aux[1];
                    string nome = aux[2];
                    string tipo = aux[3];
                    double preco = Convert.ToDouble(aux[4]);

                    Item newItem = new Item(owner, nome, tipo, preco);
                    listaItem.Add(newItem);
                }
            }
            else Console.WriteLine("Lista vazia!");
        }
        public void Close()
        {
            sw.Close();
        }
    }
}