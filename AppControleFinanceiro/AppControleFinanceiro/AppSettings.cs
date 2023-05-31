using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro
{
    public class AppSettings
    {
        private static string DataBaseName = "ControleFinanceiro.db";
        private static string DataBaseDirectory = FileSystem.AppDataDirectory;
        public static string PathDataBase = Path.Combine(DataBaseDirectory, DataBaseName);
    }
}
