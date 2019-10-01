using App1.Infra;
using SQLite;

namespace App1.Model
{
    public class Funcionario : IEntityObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Salario { get; set; }
        public string CodigoMoeda { get; set; }
    }
}
