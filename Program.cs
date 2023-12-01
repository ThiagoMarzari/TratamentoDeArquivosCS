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
                Console.WriteLine("5 - Adicionar itens para um personagem: ");
                Console.WriteLine("6 - Para ver os itens de um personagem: ");
                Console.WriteLine("7 - Para fechar o programa: ");
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
                    listaItens.Clear();
                    Item i = new Item();
                    i.Init();
                    listaItens.Add(i);

                    arquivoI.CreateFile();
                    arquivoI.SaveList(listaItens);
                    arquivoI.Close();

                    Console.WriteLine("Item adicionado!");
                    Helper.ContinueMessage();
                    Console.Clear();
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

                        Console.WriteLine();
                    }

                    Helper.ContinueMessage();
                }
                else if (op == 4) //Ver itens da lista
                {
                    Console.Clear();
                    Helper.HeaderText("LISTA DE ITENS");

                    listaItens.Clear();
                    arquivoI.LoadItemList(listaItens);

                    foreach (var item in listaItens)
                    {
                        Console.Write("Nome:" + item.Nome + " | ");
                        Console.Write("Nome:" + item.Tipo + " | ");
                        Console.Write("Nome:" + item.Preco + " | ");

                        Console.WriteLine();
                    }
                    Helper.ContinueMessage();
                }
                else if (op == 5) //Adicionar itens para o personagem
                {
                    try
                    {
                        Console.Clear();
                        Helper.HeaderText("PERSONAGENS DISPONÍVEIS");
                        listaPersonagens.Clear();
                        arquivoP.LoadCharacterList(listaPersonagens);

                        Console.WriteLine("Escolha qual dos personagens: ");
                        foreach (var pers in listaPersonagens)
                        {
                            if (pers.GetType().Name == nameof(PersonagemJogavel)) //Ver se o tipo da classe é do tipo PersonagemJogavel
                                Console.WriteLine(pers.Nome);
                        }
                        string opc = Console.ReadLine(); 

                        PersonagemJogavel p = new PersonagemJogavel(); //Variavel local para armazenar o personagem escolhido;
                        ///////TODO/////////////////////////
                        foreach (PersonagemJogavel per in listaPersonagens) 
                        {
                            if (opc.Equals(per.Nome) && (per.GetType().Name == nameof(PersonagemJogavel))) //Ver se o tipo da classe é do tipo PersonagemJogavel
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


                        ////////////////ADICIONAR ITENS////////////////////
                        ///
                        listaItens.Clear();
                        arquivoI.LoadItemList(listaItens);

                        if (listaItens.Count == 0) //Verificar se a lista está vazia, se estiver volta para o inicio
                        {
                            Console.WriteLine("Lista de itens vazia!");
                            Helper.ContinueMessage();
                            Console.Clear();
                            continue;
                        }

                        Helper.HeaderText("Adicione itens para: " + p.Nome);
                        while (true)
                        {
                            //TODO ADICIONAR ITENS
                            Console.WriteLine("Escolha qual dos itens: ");
                            listaItens.Clear();
                            arquivoI.LoadItemList(listaItens);

                            foreach (Item item in listaItens) //Mostrar itens disponíveis
                            {
                                Console.WriteLine("NOME: " + item.Nome);
                            }

                            string itemOp = Console.ReadLine();
                            Item i = new Item(); //Variavel local para armazenar o item escolhido;

                            foreach (Item item in listaItens)
                            {
                                if (itemOp.Equals(item.Nome)) /////////////////////////////------------------------------------AQUI REFORMULAR TODO CÒDIGO PARA ADICIONAR ITENS
                                {
                                    i = item;   
                                    p.AddItem(item);
                                    p.ShowItens();
                                    break;
                                }
                                else i = null;
                            }
                            if (i == null)
                            {
                                Console.WriteLine("Item não encontrado!");
                                Helper.ContinueMessage();
                                break;
                            }

                            Console.WriteLine("Continuar adicionando mais itens? [SIM] [NAO]");
                            string bOp = Console.ReadLine();
                            if (bOp.Equals("NAO"))
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    catch 
                    {
                        Console.WriteLine("ERRO!!!");
                    }
                }
                else if (op == 6)
                {
                    Console.Clear();
                    Helper.HeaderText("PERSONAGENS DISPONÍVEIS");
                    listaPersonagens.Clear();
                    arquivoP.LoadCharacterList(listaPersonagens);

                    Console.WriteLine("Escolha qual dos personagens: ");
                    foreach (var pers in listaPersonagens)
                    {
                        if (pers.GetType().Name == nameof(PersonagemJogavel)) //Ver se o tipo da classe é do tipo PersonagemJogavel
                            Console.WriteLine(pers.Nome);
                    }
                    string opc = Console.ReadLine();

                    PersonagemJogavel p = new PersonagemJogavel(); //Variavel local para armazenar o personagem escolhido;
                                                                   ///////TODO/////////////////////////
                    foreach (PersonagemJogavel per in listaPersonagens)
                    {
                        if (opc.Equals(per.Nome) && (per.GetType().Name == nameof(PersonagemJogavel))) //Ver se o tipo da classe é do tipo PersonagemJogavel
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

                    p.ShowItens();
                }
                else if (op == 6) //Fechar programa
                {
                    break;
                }
            }
        }
    }
}