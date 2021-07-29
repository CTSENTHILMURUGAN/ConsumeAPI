using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumeAPI
{
    public class API
    {

        private string url = "http://magazinestore.azurewebsites.net";

        public string GetToekn()
        {
            string token = string.Empty;
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("api/token");
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var responseData = readTask.Result;
                    tokenModel tmodel = JsonSerializer.Deserialize<tokenModel>(responseData);
                    token = tmodel.token;
                }
            }
            return token;
        }


        public CategoryModel GetCategory()
        {
            CategoryModel model = new CategoryModel();
            string token = GetToekn();
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("api/categories/" + token);
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var responseData = readTask.Result;
                    model = JsonSerializer.Deserialize<CategoryModel>(responseData);
                }
            }
            return model;
        }


        public SubscriberModel GetSubscriber()
        {
            SubscriberModel model = new SubscriberModel();
            string token = GetToekn();

            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("api/subscribers/" + token);
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var responseData = readTask.Result;
                    model = JsonSerializer.Deserialize<SubscriberModel>(responseData);
                }
            }
            return model;
        }



        public MagazinesModel GetMagazine(string category)
        {
            MagazinesModel model = new MagazinesModel();

            string token = GetToekn();
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);
                var responseTask = client.GetAsync("api/magazines/" + token + "/" + category);
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync();
                    readTask.Wait();
                    var responseData = readTask.Result;
                    model = JsonSerializer.Deserialize<MagazinesModel>(responseData);
                }
            }
            return model;
        }



        public void PostSubcribers(MagazineSubscriber _MagazineSubscriber)
        {
            string token = GetToekn();
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(url);

                //var postTask = client.PostAsJsonAsync<MagazineSubscriber>("DaimKEM/kem/ci/AddSupplier", _MagazineSubscriber);
                //postTask.Wait();
                //var result = postTask.Result;
                var content = new StringContent(_MagazineSubscriber.ToString(), Encoding.UTF8, "application/json");
                var responseTask = client.PostAsync("api/answer/" + token, content);
                responseTask.Wait();

                var response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("successfully posted");
                }
            }

        }
    }
}
