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
                Console.WriteLine("1 - Adicionar personagens na lista");
                Console.WriteLine("2 - Adicionar itens na lista: ");
                Console.WriteLine("3 - Mostrar os personagens da lista: ");
                Console.WriteLine("4 - Mostrar os itens da lista: ");
                Console.WriteLine("5 - Para fechar o programa: ");
                op = int.Parse(Console.ReadLine());

                if (op == 1) //Adiconar personagens na lista
                {
                    listaPersonagens.Clear(); //Limpando a lista porque ele tava duplicando algumas linhas //Não entendi mt o pq
                    Console.WriteLine("[1] Personagem jogavel [2] NPC");
                    int opc = int.Parse(Console.ReadLine());
                    Personagem p = opc == 1 ? new PersonagemJogavel() : new NPC();
                    p.Init();
                    listaPersonagens.Add(p);

                    arquivoP.CreateFile();
                    //arquivoP.SaveList<Personagem>(listaPersonagens); //Posso passar o tipo se quiser, assim como é o instantiate na unity
                    arquivoP.SaveList(listaPersonagens);
                    arquivoP.Close();

                    Console.WriteLine("Personagem adicionado!");
                    Helper.ContinueMessage();
                    Console.Clear();
                }
                else if (op == 2) //Adicionar itens na lista
                {
                    Console.Clear();
                    Personagem p = ChooseCharacter(listaPersonagens, arquivoP);
                    if (p == null) continue;

                    while (true)
                    {
                        listaItens.Clear();
                        Console.WriteLine("Digite o nome do item: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o tipo do item: ");
                        string tipo = Console.ReadLine();
                        Console.WriteLine("Digite o preço do item: ");
                        double preco = double.Parse(Console.ReadLine());
                        Item i = new Item(p.Nome, nome, tipo, preco);
                        listaItens.Add(i);

                        arquivoI.CreateFile();
                        arquivoI.SaveList(listaItens);
                        arquivoI.Close();

                        Console.WriteLine("Item adicionado!");
                        Console.WriteLine("Continuar adicionando mais itens? [SIM] [NAO]");
                        string bOp = Console.ReadLine();
                        if (bOp.Equals("NAO"))
                        {
                            Helper.ContinueMessage();
                            Console.Clear();
                            break;
                            
                        }
                        Console.Clear();
                        continue;
                    }
                }
                else if (op == 3) //Mostrar personagens da lista
                {
                    Console.Clear();
                    Helper.HeaderText("LISTA DE PERSONAGENS");

                    listaPersonagens.Clear();
                    arquivoP.LoadCharacterList(listaPersonagens);
                    
                    foreach (var per in listaPersonagens)
                    {
                        Console.Write("Nome:" + per.Nome + " | ");
                        Console.Write("Força: " + per.Forca + " | ");
                        Console.Write("Estamina: " + per.Estamina + " | ");
                        Console.Write("Agilidade: " + per.Agilidade + " | ");
                        Console.Write("Inteligência: " + per.Inteligencia + " | ");
                        Console.Write("Carisma: " + per.Carisma + " | ");
                        Console.Write("Pos X: " + per.PosX + " | ");
                        Console.Write("Pos Y: " + per.PosY + " | ");
                        Console.Write("Pos Z: " + per.PosZ);

                        Console.WriteLine();
                    }

                    Helper.ContinueMessage();
                }
                else if (op == 4) //Ver itens da lista
                {
                    Personagem p = ChooseCharacter(listaPersonagens, arquivoP);
                    if (p == null) continue;

                    Console.Clear();
                    Helper.HeaderText("LISTA DE ITENS");

                    try
                    {
                        listaItens.Clear();
                        arquivoI.LoadItemList(listaItens);
                        Console.WriteLine("DONO: " + p.Nome);
                        Console.WriteLine();
                        foreach (var item in listaItens)
                        {
                            if (p.Nome == item.Owner)
                            {
                                Console.Write("Nome:" + item.Nome + " | ");
                                Console.Write("Tipo:" + item.Tipo + " | ");
                                Console.Write("Preço:" + item.Preco + " | ");

                                Console.WriteLine();
                            }
                        }
                        
                        Helper.ContinueMessage();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error!!");
                        Helper.ContinueMessage();
                    }
                }
                else if (op == 5) //Fechar programa
                {
                    break;
                }
            }
        }

        static Personagem ChooseCharacter(List<Personagem> listaPersonagens, Arquivo arquivoP)
        {
            Helper.HeaderText("PERSONAGENS DISPONÍVEIS");
            listaPersonagens.Clear();
            arquivoP.LoadCharacterList(listaPersonagens);

            Console.WriteLine("Escolha qual dos personagens: ");
            foreach (var per in listaPersonagens)
            {
                if (per is PersonagemJogavel)//Ver se o tipo da classe é do tipo PersonagemJogavel
                    Console.WriteLine(per.Nome);
            }
            string opc = Console.ReadLine();

            Personagem p = null; //Variavel local para armazenar o personagem escolhido;
            foreach (Personagem per in listaPersonagens)
            {
                if (per is PersonagemJogavel && opc.Equals(per.Nome)) //Ver se o tipo da classe é do tipo PersonagemJogavel
                {
                    p = per;
                    return p;
                }
                else p = null;
            }
            if (p == null)
            {
                Console.WriteLine("Nome não encontrado!");
                Helper.ContinueMessage();
                return null;
            }
            return null;
        }
    }
}