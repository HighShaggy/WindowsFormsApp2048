using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2048
{
    public class UserManager
    {
        public static string Path = "results.json";

        public static List<User> GetAll()
        {
           if (FileProvaider.Exists(Path))
            {
                var jsonData = GetValue(Path);
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
            return new List<User>();
            
        }
        public static string GetValue(string filename)
        {

            var reader = new StreamReader(filename, Encoding.UTF8);
            var value = reader.ReadToEnd();
            reader.Close();
            return value;
        }
        public static void Add(User user)
        {
            var users= GetAll();
            users.Add(user);
            var jsonData=JsonConvert.SerializeObject(users);
            FileProvaider.Replace(Path, jsonData);
        }
    }
}
