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
        private double _preco;

        public string Nome { get => _nome; set => _nome = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public double Preco { get => _preco; set => _preco = value; }

        public void Init()
        {
            Console.WriteLine("Digite o nome do item: ");
            _nome = Console.ReadLine();
            Console.WriteLine("Digite o tipo do item: ");
            _tipo = Console.ReadLine();
            Console.WriteLine("Digite o preço do item: ");
            _preco = double.Parse(Console.ReadLine());
        }

        public string GetInfo()
        {
            return Nome + ";" + Tipo + ";" + Preco;
        }
    }
}
