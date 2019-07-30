using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Converters;

namespace Entities
{
    public class JsonSeed
    {
        public void  LoadSeed(string file,ref List<Customer>  obj)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }
        public void LoadSeed(string file, ref List<Product> obj)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }
        public void LoadSeed(string file, ref List<Category> obj)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<List<Category>>(json);
            }
        }
        public void LoadSeed(string file, ref List<CardType> obj)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                string json = reader.ReadToEnd();
                obj = JsonConvert.DeserializeObject<List<CardType>>(json);
            }
        }
    }

}
