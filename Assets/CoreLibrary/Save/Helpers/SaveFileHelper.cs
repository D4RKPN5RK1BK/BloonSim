using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace CoreLibrary.Save
{
    public class SaveFileHelper<T> where T : ISaveModel, new()
    {
        private const string SaveExtension = "save";
        private const string SaveFilePattern = "*." + SaveExtension;

        private static string SaveFileName(string saveName) => $"{saveName}.{SaveExtension}";

        public void SaveData(T save)
        {
            var dataPath = Application.persistentDataPath;
            var savePath = Path.Combine(dataPath, SaveFileName(save.FileName));
            var formatter = new BinaryFormatter();

            using var fileStream = new FileStream(savePath, FileMode.Create);

            formatter.Serialize(fileStream, save);
        }

        public ISaveModel LoadData(string saveName)
        {
            var formatter = new BinaryFormatter();
            var dataPath = Application.persistentDataPath;
            var savePath = Path.Combine(dataPath, saveName);

            if (!File.Exists(savePath))
                return new T();

            using var fileStream = new FileStream(savePath, FileMode.Open);
            var data = formatter.Deserialize(fileStream) as ISaveModel;

            return data;
        }

        public void DeleteData(string saveName)
        {
            var dataPath = Application.persistentDataPath;
            var fileName = SaveFileName(saveName);
            File.Delete(Path.Combine(dataPath, fileName));
        }

        public ISaveModel[] All()
        {
            var formatter = new BinaryFormatter();
            var dataPath = Application.persistentDataPath;
            var files = Directory.GetFiles(Application.persistentDataPath, SaveFilePattern);
            var saves = new ISaveModel[files.Count()];

            for (var i = 0; i < saves.Count(); i++)
            {
                var savePath = Path.Combine(dataPath, files[i]);
                using var fileStream = new FileStream(savePath, FileMode.Open);
                saves[i] = formatter.Deserialize(fileStream) as ISaveModel;
            }

            return saves;
        }
    }
}
