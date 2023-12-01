using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    class PersonagemJogavel : Personagem
    {
        private List<Item> _itens = new List<Item>();

        public override void Movimentar()
        {
            Console.WriteLine("Digite a posição X: ");
            _posX = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Y: ");
            _posY = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Z: ");
            _posZ = float.Parse(Console.ReadLine());
        }        

        public void Init() 
        {
            base.Init(); //Herdando parte da função da classe pai
            Movimentar();
        }

        public void AddItem(Item item)
        {
            _itens.Add(item);
        }

        public void ShowItens()
        {
            if (_itens.Count == 0)
            {
                Console.WriteLine("Este personagem não possui nenhum item!");
            }
            else
            {
                Console.WriteLine($"==== ITEMS: {Nome} ====");
                foreach(Item item in _itens)
                {
                    Console.WriteLine($"Nome: {item.Nome} | Tipo: {item.Tipo} | Preço: {item.Preco} ");
                }
                Console.WriteLine($"==== ITEMS: {Nome} ====");
            }
        }

        public string SaveItemList()
        {
            return "";
        }
    }
}
