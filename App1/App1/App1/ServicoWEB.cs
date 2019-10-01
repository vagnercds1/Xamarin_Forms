using App1.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace App1
{
    public class ServicoWEB
    {
        public Moedas GetMoedas()
        {
            Moedas obj = new Moedas();

            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = client.GetAsync("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objJsonString = response.Content.ReadAsStringAsync().Result;
                             
                            obj = JsonConvert.DeserializeObject<Moedas>(objJsonString); 
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }
    }
}
