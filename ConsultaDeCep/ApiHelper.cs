﻿using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using static System.Net.WebRequestMethods;


namespace ConsultaDeCep
{
    internal static class ApiHelper
    {
        private static HttpClient? ApiClient;

        private static HttpClient GetApiClient()
        {
            if(ApiClient == null) {
                ApiClient = new HttpClient();
                ApiClient.DefaultRequestHeaders.Accept.Clear();
                ApiClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            }
            return ApiClient;
        }

        internal static async Task<CepQueryResponse> AddConsultedCepAsync(CepQuery cepQuery)
        {
            HttpClient ApiClient = GetApiClient();
            var url = $"https://646cc5e27b42c06c3b2bfe57.mockapi.io/cepQuery";
           
            using (HttpResponseMessage response = await ApiClient.PostAsJsonAsync(url, cepQuery))
            {
                CepQueryResponse cepQueryResponse = new CepQueryResponse();
                if (response.IsSuccessStatusCode)
                {
                    cepQueryResponse = await response.Content.ReadAsAsync<CepQueryResponse>();
                }
                return cepQueryResponse;
            }
        }

        internal static async Task<CepResponse> GetCepInfoAsync(string? cep)
        {
            HttpClient ApiClient = GetApiClient();

            var url = $"https://viacep.com.br/ws/{cep}/json/";

            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                CepResponse cepResponse = new CepResponse();
                if (response.IsSuccessStatusCode)
                {
                    cepResponse = await response.Content.ReadAsAsync<CepResponse>();
                }
                return cepResponse;
            }

        }

    }
}
