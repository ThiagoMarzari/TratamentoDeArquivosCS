using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    class PersonagemJogavel : Personagem
    {
        public override void Movimentar()
        {
            Console.WriteLine("Digite a posição X: ");
            _posX = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Y: ");
            _posY = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite a posição Z: ");
            _posZ = double.Parse(Console.ReadLine());
        }        

        public void Init() 
        {
            base.Init(); //Herdando parte da função da classe pai
            Movimentar();
        }
    }
}
