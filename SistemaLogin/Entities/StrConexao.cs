using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace SistemaLogin.Entities
{
    internal class StrConexao
    {
        public static string? strConexaoBd { get; private set; }
        public static void Caminho()
        {
            using(StreamReader reader = new StreamReader("LocalConexao.dll"))
            {
                strConexaoBd = reader.ReadToEnd();
            }
        }
    }
}
