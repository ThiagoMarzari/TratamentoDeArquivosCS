using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public abstract class Personagem : IGetInfo
    {
        private string _nome;
        private int _forca;
        private int _estamina;
        private int _agilidade;
        private int _inteligencia;
        private int _carisma;

        public string Nome { get => _nome; set => _nome = value; }
        public int Forca { get => _forca; set => _forca = value; }
        public int Estamina { get => _estamina; set => _estamina = value; }
        public int Agilidade { get => _agilidade; set => _agilidade = value; }
        public int Inteligencia { get => _inteligencia; set => _inteligencia = value; }
        public int Carisma { get => _carisma; set => _carisma = value; }

        protected double _posX;
        protected double _posY;
        protected double _posZ;

        public double PosX { get => _posX; }
        public double PosY { get => _posY; }
        public double PosZ { get => _posZ; }

        public abstract void Movimentar(); //Não possui implementação por ser um método abstrato

        public void Init()
        {
            Helper.HeaderText("COMPLETE AS SEGUINTES INFORMAÇÕES");

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
            Movimentar();
        }

        public void SetPos(double x, double y, double z)
        {
            _posX = x;
            _posY = y;
            _posZ = z;  
        }

        public string GetInfo()
        {
            return Nome + ";" + Forca + ";" + Estamina + ";" + Agilidade + ";" + Inteligencia + ";" + Carisma +
                ";" + PosX + ";" + PosY + ";" + PosZ;
        }
    }
}