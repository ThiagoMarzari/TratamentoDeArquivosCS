using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    class PersonagemJogavel : Personagem
    {
        public List<Item> Itens = new List<Item>();

        public override void Movimentar(float posX, float posY, float posZ)
        {
            //TODO
        }
        
        public void InitPersonagem()
        {
            Helper.HeaderText("COMPLETE AS SEGUINTES INFORMAÇÕES");
            Console.WriteLine();

            Console.WriteLine("Digite o nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite a força: ");
            Forca = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a estamina: ");
            Estamina = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a agilidade: ");
            Agilidade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a inteligência: ");
            Inteligencia = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a carisma: ");
            Carisma = int.Parse(Console.ReadLine());
        }

        public void MostrarItems()
        {
            if (Itens.Count == 0)
            {
                Console.WriteLine("Este personagem não possui nenhum item!");
            }
            else
            {
                Console.WriteLine("==== ITEMS ====");
                foreach(Item item in Itens)
                {
                    Console.WriteLine($"Nome: {item.Nome} | Tipo: {item.Tipo} | Preço: {item.Preco} ");
                }
                Console.WriteLine("==== ITEMS ====");
            }
        }
    }
}
