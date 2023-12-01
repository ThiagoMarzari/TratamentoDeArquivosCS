using System;
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
        }

        public void CreateFile()
        {
            sw = new StreamWriter("C:\\Arquivos\\" + nome + prefixo + ".txt", true, Encoding.UTF8);
        }

        public void SaveList<T>(List<T> lista) where T : IGetInfo //O T vai implementar a interface IGetInfo
        {
            foreach (var i in lista)
            {
                sw.WriteLine($"{i.GetType().Name};{i.GetInfo()};"); //o elemento I assume que os elementos vão ter essa interface/função implementada
            }
        }

        public void LoadCharacterList(List<Personagem> listaPersonagens)
        {
            if (File.Exists(caminho))
            {
                string[] linhas = File.ReadAllLines(caminho);

                foreach (var linha in linhas)
                {
                    string[] aux = linha.Split(';');
                    if (aux.Length >= 3) //Verificar essa parte
                    {
                        string tipoPersonagem = aux[0]; //Verificar essa parte do código
                        string nome = aux[1];
                        int forca = Convert.ToInt32(aux[2]);
                        int estamina = Convert.ToInt32(aux[3]);
                        int agilidade = Convert.ToInt32(aux[4]);
                        int inteligencia = Convert.ToInt32(aux[5]);
                        int carisma = Convert.ToInt32(aux[6]);
                        string pos = aux[7];

                        Personagem novoPersonagem;

                        if (tipoPersonagem == nameof(PersonagemJogavel))
                        {
                            novoPersonagem = new PersonagemJogavel { Nome = nome, Forca = forca, Estamina = estamina, Agilidade = agilidade, 
                                Inteligencia = inteligencia, Carisma = carisma};
                        }
                        else if (tipoPersonagem == nameof(NPC))
                        {
                            novoPersonagem = new NPC { Nome = nome, Forca = forca, Estamina = estamina, Agilidade = agilidade, 
                                Inteligencia = inteligencia, Carisma = carisma};
                        }
                        else
                        {
                            Console.WriteLine("Tipo da classe desconhecido!");
                            continue;
                        }
                        listaPersonagens.Add(novoPersonagem);
                    }
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
                    if (aux.Length >= 3)
                    {
                        string tipoPersonagem = aux[0];
                        string nome = aux[1];
                        string tipo = aux[2];
                        double preco = Convert.ToDouble(aux[3]);

                        Item newItem = new Item { Nome = nome, Tipo = tipo, Preco = preco };

                        listaItem.Add(newItem);
                    }
                }
            }
            else Console.WriteLine("Arquivo inexistente!");
        }
        public void Close()
        {
            sw.Close();
        }
    }
}
