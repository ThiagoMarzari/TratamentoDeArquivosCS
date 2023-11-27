using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class Item
    {
        private string _nome;
        private string _tipo;
        private float _preco;

        public string Nome { get => _nome; }
        public string Tipo { get => _tipo; }
        public float Preco { get => _preco; }

        public Item(string nome, string tipo, float preco)
        {
            _nome = nome;
            _tipo = tipo;
            _preco = preco;
        }
    }
}
