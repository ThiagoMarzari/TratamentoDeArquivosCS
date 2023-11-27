using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public abstract class Personagem
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


        private float _posX;
        private float _posY;
        private float _posZ;

        public float PosX { get => _posX; }
        public float PosY { get => _posY; }
        public float PosZ { get => _posZ; }


        public abstract void Movimentar(float posX, float posY, float posZ); //Não possui implementação por ser um método abstrato

        public string PegarCaracteristicas()
        {
            return Nome + ";" + Forca + ";" + Estamina + ";" + Agilidade + ";" + Inteligencia + ";" + Carisma;
        }
    }
}
