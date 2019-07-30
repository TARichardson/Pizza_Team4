using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Entities
{
    public class MyHttpClient
    {
        private static string _url = "https://localhost:44361";
        private static string _mediaType = "application/json";
        private static HttpClient _client = new HttpClient();
        private string _controller;
        public string ApiURL { get => "/api/" + _controller; set => _controller = value;}
        public string FullApiURL { get => _url + "/api/" + _controller; }
        public string BaseApiURL { get => _url; }
        public string MediaType { get => _mediaType; }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "customers";
            var res = await _client.GetStringAsync(_url + this.ApiURL);
            //var res = stringTask.Result;
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(res);

            if(customers != null)
            {
                return customers;
            }
            return null;   
        }

        public async Task<Customer> GetByCustomerId(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "customers";
            var stringTask = await _client.GetStringAsync(_url + this.ApiURL + $"/{id }");
            var customer = JsonConvert.DeserializeObject<Customer>(stringTask);

            if (customer != null)
            {
                return customer;
            }
            return null;
        }

        public async  Task<Customer> AddCustomer(CustomerDTO dto)
        {
        
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "customers";
            string data = JsonConvert.SerializeObject(dto);
            var jsonData = new StringContent(data, Encoding.UTF8, _mediaType);

           var res =  await _client.PostAsync(_url + this.ApiURL, jsonData);
            if (res.Content != null)
            {
                var resData = await res.Content.ReadAsStringAsync();

                Customer customer = JsonConvert.DeserializeObject<Customer>(resData);
                //Customer customer = await this.GetCustomersProfile(dto);
                // string content = await res.Content.ReadAsStringAsync();
                //customer = ;
                if (customer != null)
                {
                    return customer;
                }

            }

            return null;
        }
        public async Task<Customer> GetCustomersProfile(CustomerDTO dto)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "customers/profile";
            string data = JsonConvert.SerializeObject(dto);
            var jsonData = new StringContent(data, Encoding.UTF8, _mediaType);
            var res = await _client.PostAsync(_url + this.ApiURL, jsonData);
            if (res.Content != null)
            {
                var resData = await res.Content.ReadAsStringAsync();


                Customer customers = JsonConvert.DeserializeObject<Customer>(resData);

                if (customers != null)
                {
                    return customers;
                }
            }
            return null;
        }

        public async Task<Item> DeleteItem(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "items/";
            var streamString = await _client.DeleteAsync(_url + ApiURL + id);
            var res = await streamString.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<Item>(res);
            return item;

        }

        public async Task<IEnumerable<Payment>> Payment(string id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "orders/Payment/";
            var stringTask = await _client.GetStringAsync(_url + ApiURL + id);
            var payment = JsonConvert.DeserializeObject<IEnumerable<Payment>>(stringTask);
            return payment;
        }

        public async Task<IEnumerable<Payment>> Payment(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "orders/Payment/";
            var stringTask = await _client.GetStringAsync(_url + ApiURL + $"{id}");
            var payment = JsonConvert.DeserializeObject<IEnumerable<Payment>>(stringTask);
            return payment;
        }

        public async Task<IEnumerable<Item>> Transaction(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "orders/Transation/";
            var stringTask = await _client.GetStringAsync(_url + ApiURL + id);
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(stringTask);
            return items;
        }

        public async Task<IEnumerable<Item>> Cart(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));
            ApiURL = "items/";
            var stringTask = await _client.GetStringAsync(_url + ApiURL + id);
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(stringTask);
            return items;

        }

        public async Task<IEnumerable<Order>> history(int id)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(_mediaType));

            ApiURL = "orders/History/" + $"{id}";

            var stringTask = await _client.GetStringAsync(_url + ApiURL);
            var Orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringTask);
            return Orders;

        }
    }
}
