using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    public class NPC : Personagem
    {
        public override void Movimentar(float posX, float posY, float posZ)
        {
            Random random = new Random();
            posX = random.Next(0, 100);
            posY = random.Next(0, 100);
            posZ = random.Next(0, 100);
        }

    }
}
