using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class Item : IGetInfo
    {
        private string _nome;
        private string _tipo;
        private float _preco;

        public string Nome { get => _nome; }
        public string Tipo { get => _tipo; }
        public float Preco { get => _preco; }

        public void Init()
        {
            Console.WriteLine("Digite o nome do item: ");
            _nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo do item: ");
            _tipo = Console.ReadLine();
            Console.WriteLine("Digite o preço do item: ");
            _preco = float.Parse(Console.ReadLine());
        }

        public string GetInfos()
        {
            return Nome + ";" + Tipo + ";" + Preco;
        }
    }
}
