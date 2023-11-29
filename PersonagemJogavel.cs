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
        

        public void Init() 
        {
            base.Init();
            Console.WriteLine("Digite a posição X: ");
            _posX = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Y: ");
            _posY = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Z: ");
            _posZ = float.Parse(Console.ReadLine());
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
