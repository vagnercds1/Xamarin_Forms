using System.Collections.Generic;

namespace App1.Model
{
    public class Value
    {
        public string simbolo { get; set; }
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
    }

    public class Moedas
    {
        public string context { get; set; }
        public List<Value> value { get; set; }
    }
}
