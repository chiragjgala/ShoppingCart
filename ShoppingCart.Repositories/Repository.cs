using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _filePath;

        public Repository()
        {
            var type = typeof(T).Name;
            _filePath = GetFullFilePath(type);
            CreateSource(type);
        }

        private static string GetFullFilePath(string fileNameWithoutExtension)
        {
            return $"{fileNameWithoutExtension}.json";
        }

        private void CreateSource(string type)
        {
            if (File.Exists(type))
            {
                //throw Exception
                return;
            }
            var stream = File.Create(_filePath);
            stream.Close();
        }

        public IEnumerable<T> Get()
        {
            var content = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<IEnumerable<T>>(content);

            return data ?? Enumerable.Empty<T>();
        }

        public void Post(IEnumerable<T> data)
        {
            var content = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, content);
        }
    }
}
