using System.Security.Cryptography;
using System.Text;

namespace API.Service
{
    public class CepService
    {
        private ICacheService _service;
        private static readonly HttpClient HttpClient = new HttpClient();

        public CepService(ICacheService service)
        {
            _service = service;
        }

        public async Task<dynamic> BuscarCep(string cep)
        {
            object result = _service.Get($"BuscarCep-{cep}");

            if (result != null)
                return result;


            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var resultado = await HttpClient.GetAsync(url);
            if (resultado.StatusCode != System.Net.HttpStatusCode.OK)
                throw new HttpRequestException($"{resultado.StatusCode}-{resultado.RequestMessage}");

            result = await resultado.Content.ReadAsStringAsync();
            _service.Set($"BuscarCep-{cep}", result);

            return result;
        }



    }
}
