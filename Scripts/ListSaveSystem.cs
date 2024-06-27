using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace ProjectManagementSystem.Scripts
{
    internal class ListSaveSystem<T>
    {
        private string _path;

        public ListSaveSystem(string path)
        {
            _path = path;
        }

        public BindingList<T> LoadData()
        {
            bool fileExists = File.Exists(_path);
            if(!fileExists)
            {
                File.CreateText(_path).Dispose();
                return new BindingList<T>();
            }
            using (StreamReader reader = File.OpenText(_path))
            {
                string text = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<T>>(text);
            }
        }

        public void SaveData(object objToSave)
        {
            using (StreamWriter writer = File.CreateText(_path))
            {
                string output = JsonConvert.SerializeObject(objToSave);
                writer.Write(output);
            }
        }
    }
}
