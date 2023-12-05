using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class NPC : Personagem
    {
        public override void Movimentar()
        {
            Random random = new Random();
            _posX = random.Next(0, 999);
            _posY = random.Next(0, 999);
            _posZ = random.Next(0, 999);
        }
    }
}
