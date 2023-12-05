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
        private string _owner; //quem é o dono desse item

        public Item(string owner, string nome, string tipo, double preco)
        {
            _owner = owner;
            _nome = nome;
            _tipo = tipo;
            _preco = preco;
        }

        public string Nome { get => _nome; }
        public string Tipo { get => _tipo; }
        public double Preco { get => _preco;  }
        internal string Owner { get => _owner;}

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
            return  Owner + ";" + Nome + ";" + Tipo + ";" + Preco;
        }
    }
}
