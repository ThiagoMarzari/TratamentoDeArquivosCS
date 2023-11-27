using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    static class Helper //Não pode ser instanciada
    {
        public static void HeaderText(string text)
        {
            Console.WriteLine("-----------" + text + "---------------");
        }

        public static void ContinueMessage()
        {
            Console.WriteLine("Pressione ENTER para continuar: ");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
