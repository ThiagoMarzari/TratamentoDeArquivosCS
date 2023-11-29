using System.Runtime.ConstrainedExecution;

namespace TrabalhoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomeArquivo;

            Console.WriteLine("Digite o nome do arquivo: ");
            nomeArquivo = Console.ReadLine();
            Arquivo arquivoP = new Arquivo("P", nomeArquivo);

            Arquivo arquivoI = new Arquivo("I", nomeArquivo);

            List<Item> listaItens = new List<Item>();
            List<Personagem> listaPersonagens = new List<Personagem>();

            int op;

            Console.Clear();
            while (true)
            {
                Helper.HeaderText("MENU");
                Console.WriteLine("1 - Adicionar para ler personagens jogáveis: ");
                Console.WriteLine("2 - Para adicionar itens na lista:  ");
                Console.WriteLine("3 - Para mostrar os personagens da lista: ");
                Console.WriteLine("4 - Adicionar itens para um personagem: ");
                Console.WriteLine("5 - Para fechar o programa: ");
                op = int.Parse(Console.ReadLine());

                if (op == 1) //Adiconar personagens na lista
                {
                    string mensagem;
                    PersonagemJogavel p = new PersonagemJogavel();

                    arquivoP.CriaArquivo();
                    p.Init();
                    mensagem = p.GetInfos();
                    arquivoP.GravaMensagem(mensagem);
                    arquivoP.FecharArquivo();
                    listaPersonagens.Add(p);
                    Console.WriteLine("Personagem adicionado!");
                    Helper.ContinueMessage();
                    Console.Clear();
                }
                else if (op == 2) //Adicionar itens na lista
                {
                    string mensagem;
                    Item auxItem = new Item();

                    arquivoI.CriaArquivo();
                    auxItem.Init();
                    mensagem = auxItem.GetInfos();
                    arquivoI.GravaMensagem(mensagem);
                    arquivoI.FecharArquivo();
                    listaItens.Add(auxItem);
                    Console.WriteLine("Item adicionado!");
                    Helper.ContinueMessage();
                    Console.Clear();
                }
                else if (op == 3) //Mostrar personagens da lista
                {
                    Console.Clear();
                    Helper.HeaderText("LISTA DE PERSONAGENS");
                    try //Tentando rodar código abaixo, caso der algo errado ele vai para o catch
                    {
                        string[] vetorPerso = arquivoP.LerTodasLinhas();
                        Console.WriteLine(vetorPerso.Length);

                        for (int i = 0; i < vetorPerso.Length; i++)
                        {
                            string[] aux = vetorPerso[i].Split(';');

                            Console.Write("Nome: " + aux[0] + "|"); 
                            Console.Write("Força: " + aux[1] + "|");
                            Console.Write("Estamina:" + aux[2] + "|");
                            Console.Write("Agilidade:" + aux[3] + "|");
                            Console.Write("Inteligência:" + aux[4] + "|");
                            Console.Write("Carisma:" + aux[5] + "|");

                            Console.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ocorreu um erro: Lista Vazia!");
                    }
                    Console.WriteLine("--------------------------");
                    Helper.ContinueMessage();
                }
                else if (op == 4) //Adicionar itens para o personagem
                {

                    if (listaPersonagens.Count == 0)
                    {
                        Console.WriteLine("Lista vazia!");
                        Helper.ContinueMessage();
                        continue; //Volta para o inicio do loop
                    }

                    Console.WriteLine("Escolha qual dos personagens: ");
                    foreach(Personagem per in listaPersonagens)
                    {
                        Console.WriteLine("NOME: " + per.Nome);
                    }

                    String op2 = Console.ReadLine();
                    PersonagemJogavel p = new PersonagemJogavel(); //Variavel local para armazenar o personagem escolhido;
                    foreach (PersonagemJogavel per in listaPersonagens)
                    {
                        if (op2.Equals(per.Nome))
                        {
                            p = per;
                            break;
                        }
                        else p = null;

                    }
                    if (p == null)
                    {
                        Console.WriteLine("Nome não encontrado!");
                        Helper.ContinueMessage();
                        continue;
                    }

                    Console.WriteLine("Adicone items a este personagem");
                    while(true)
                    {
                        //TODO ADICIONAR ITENS
                        Console.WriteLine("Escolha qual dos itens: ");
                        foreach (Item item in listaItens)
                        {
                            Console.WriteLine("NOME: " + item.Nome);
                        }

                        String itemOp = Console.ReadLine();
                        Item i = new Item(); //Variavel local para armazenar o personagem escolhido;
                        foreach (Item item in listaItens)
                        {
                            if (itemOp.Equals(item.Nome))
                            {
                                p.Itens.Add(i);
                                break;
                            }
                            else p = null;

                        }
                        if (p == null)
                        {
                            Console.WriteLine("Nome não encontrado!");
                            Helper.ContinueMessage();
                            continue;
                        }

                        Console.WriteLine("Continuar adicionando mais itens? [SIM] [NAO]");
                        String bOp = Console.ReadLine();
                        if (bOp.Equals("NAO"))
                        {
                            break;
                        }
                        continue;
                    }
                }
                else if (op == 5)
                {
                    break;
                }
            }
        }
    }
}