using App1.Model;
using SQLite;
using System.Collections.Generic;

namespace App1.Infra
{
    public static class DataBaseService
    {
        private static SQLiteConnection conn { get; set; }

        //Esta classe permite multiconexao com bancos 
        private static List<SQLiteConnection> listConn = new List<SQLiteConnection>();

        public static SQLiteConnection Conexao(string nomeBase)
        {
         
            var dbPath = Xamarin.Forms.DependencyService.Get<ISQLiteDataBasePathProvider>().GetDataBasePath(nomeBase);

            if (listConn.Count == 0)
            { 
                listConn.Add(new SQLiteConnection(dbPath));
                 
                return listConn[0]; 
            }
            else
            {                 
                foreach (var item in listConn)
                {
                    if (item.DatabasePath.ToString() == dbPath)
                    { 
                        return listConn[(listConn.Count-1)];
                    }
                }

                listConn.Add(new SQLiteConnection(dbPath));
                return listConn[(listConn.Count - 1)]; 
            } 
        }

        public static void DataBaseServiceStart(string nomeBase)
        {
            try
            {
                Conexao(nomeBase).CreateTable<Funcionario>();

            }
            catch (System.Exception ex)
            {

               
            } 
        }
    }
}
