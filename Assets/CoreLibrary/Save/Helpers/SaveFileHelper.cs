using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CoreLibrary.Save
{
    public class SaveFileHelper<T> where T : class, ISaveModel, new() 
    {
        private const string SaveExtension = "sf";
        private const string SaveFilePattern = "*." + SaveExtension;

        private static string SaveFileName(string saveName) => $"{saveName}.{SaveExtension}";

        public void Save(T save)
        {
            var dataPath = Application.persistentDataPath;
            var savePath = Path.Combine(dataPath, SaveFileName(save.FileName));
            var formatter = new BinaryFormatter();

            using var fileStream = new FileStream(savePath, FileMode.Create);

            formatter.Serialize(fileStream, save);
        }

        public T Load(string saveName)
        {
            var formatter = new BinaryFormatter();
            var dataPath = Application.persistentDataPath;
            var savePath = Path.Combine(dataPath, saveName);

            if (!File.Exists(savePath))
                return new T();

            using var fileStream = new FileStream(savePath, FileMode.Open);
            var data = formatter.Deserialize(fileStream) as T;

            return data;
        }

        public void Delete(T save)
        {
            var dataPath = Application.persistentDataPath;
            var fileName = SaveFileName(save.FileName);
            File.Delete(Path.Combine(dataPath, fileName));
        }

        public T[] All()
        {
            var formatter = new BinaryFormatter();
            var dataPath = Application.persistentDataPath;
            var files = Directory.GetFiles(Application.persistentDataPath, SaveFilePattern);
            var saves = new T[files.Count()];

            for (var i = 0; i < saves.Count(); i++)
            {
                var savePath = Path.Combine(dataPath, files[i]);
                using var fileStream = new FileStream(savePath, FileMode.Open);
                saves[i] = formatter.Deserialize(fileStream) as T;
            }

            return saves;
        }
    }
}
