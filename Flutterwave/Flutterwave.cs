using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Flutterwave.Interfaces;
using Newtonsoft.Json;

namespace Flutterwave
{
    public class Flutterwave
    {
        /// <summary>
        /// 
        /// </summary>
        private string Sec_Key { get; set; }

        public Flutterwave(string SecKey)
        {
            Sec_Key = Sec_Key;
        }

        public async Task<IDataFlutterwaveStanRes> Standard(IFlutterwaveReqPara para)
        {
            var Api = Sec_Key;
            var json = JsonConvert.SerializeObject(para);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var fetch = new HttpClient();
            fetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            fetch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Api);
            
            var response = await fetch.PostAsync(new Uri("https://api.flutterwave.com/v3/payments"), data);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IDataFlutterwaveStanRes>(result);
        }
    }
}