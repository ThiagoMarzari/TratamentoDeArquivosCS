namespace TrabalhoFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomeArquivoP, nomeArquivoI;
            string mensagem; //Mensagem para armazenar no arquivo txt

            Console.WriteLine("Digite o nome do arquivo para os personagens: ");
            nomeArquivoP = Console.ReadLine();
            Arquivo arquivoP = new Arquivo(nomeArquivoP);

            //Console.WriteLine("Digite o nome do arquivo para os itens: ");
            //nomeArquivoI = Console.ReadLine();
            //Arquivo arquivoI = new Arquivo(nomeArquivoI);

            List<Item> items = new List<Item>();
            List<Personagem> listaPersonagens = new List<Personagem>();

            int op;

            Console.Clear();
            while (true)
            {
                Helper.HeaderText("MENU");
                Console.WriteLine("1 - Adicionar para ler personagens jogáveis: "); 
                Console.WriteLine("2 - Para mostrar os personagens da lista: ");
                Console.WriteLine("3 - Adicionar itens para um personagem: ");
                op = int.Parse(Console.ReadLine());

                if (op == 1) 
                {
                    arquivoP.CriaArquivo();
                    PersonagemJogavel p = new PersonagemJogavel(); 
                    p.InitPersonagem();

                    mensagem = p.PegarCaracteristicas();
                    arquivoP.GravaMensagem(mensagem);
                    arquivoP.FecharArquivo();
                    listaPersonagens.Add(p);
                }
                else if (op == 2)
                {
                    Console.Clear();
                    Helper.HeaderText("LISTA DE PERSONAGENS");

                    if (listaPersonagens.Count == 0)
                    {
                        Console.WriteLine("Lista vazia!");
                        Helper.ContinueMessage();
                        continue;
                    }

                    foreach (PersonagemJogavel personagem in listaPersonagens)
                    {
                        Console.WriteLine("Nome do personagem: " + personagem.Nome);
                        Console.WriteLine("Força do personagem: " + personagem.Forca);
                        Console.WriteLine("Estamina do personagem: " + personagem.Estamina);
                        personagem.MostrarItems();
                        Console.WriteLine();
                    }
                    Console.WriteLine("--------------------------");
                    Helper.ContinueMessage();
                }
                else if (op == 3)
                {
                    if (listaPersonagens.Count == 0)
                    {
                        Console.WriteLine("Lista vazia!");
                        Helper.ContinueMessage();
                        continue; //Volta para o inicio do loop
                    }

                    Console.WriteLine("Escolha qual dos personagens");
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
                        //To Do - Adiconar items para o personagem jogavel
                        Console.WriteLine("Digite o nome do item: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite o tipo do item: ");
                        string tipo = Console.ReadLine();
                        Console.WriteLine("Digite o preço do item: ");
                        float preco = float.Parse(Console.ReadLine());
                        Item item = new Item(nome, tipo, preco);

                        p.Items.Add(item);

                        Console.WriteLine("Continuar adicionando mais itens? [SIM] [NAO]");
                        String bOp = Console.ReadLine();
                        if (bOp.Equals("NAO"))
                        {
                            break;
                        }
                        continue;
                    }
                }
            }
        }
    }
}