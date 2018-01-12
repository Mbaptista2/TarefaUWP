using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace TarefaUWP.Data.Servicos
{
    public static class StorageService
    {

        private static StorageFolder _localCacheFolder => ApplicationData.Current.LocalFolder;

        private static ApplicationDataContainer _localSettings => ApplicationData.Current.LocalSettings;

        public enum Settings
        {
            AppTheme
        }

        public static T GetSetting<T>(Settings setting, T defaultValue)
        {
            var value = _localSettings.Values[setting.ToString()];

            if (value != null)
            {
                return (T)value;
            }
            else
            {
                return defaultValue;
            }
        }

        public static void SaveSetting(Settings setting, object value)
        {
            _localSettings.Values[setting.ToString()] = value;
        }

        public enum Folders
        {
            TodoItems,
            Categories
        }

        private static async Task<StorageFolder> GetStorageFolder(Folders folder)
        {
            var storageFolder = await _localCacheFolder.CreateFolderAsync(folder.ToString(), CreationCollisionOption.OpenIfExists);

            return storageFolder;
        }

        private static async Task<StorageFile> GetStorageFile(Folders folder, string fileName)
        {
            var storageFolder = await GetStorageFolder(folder);

            fileName = GetFileNameWithExtension(fileName);

            var storageFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);

            return storageFile;
        }

        private static string GetFileNameWithExtension(string fileName)
        {
            return fileName + ".tdo";
        }

        public static async Task<IEnumerable<T>> LoadAllFiles<T>(Folders folder)
        {
            List<T> entityList = new List<T>();

            var storageFolder = await GetStorageFolder(folder);

            var files = await storageFolder.GetFilesAsync();

            foreach (var file in files)
            {
                string fileContent = await FileIO.ReadTextAsync(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);

                T entity = (T)JsonConvert.DeserializeObject<T>(fileContent);

                entityList.Add(entity);
            }

            return entityList;
        }

        public static async Task SaveFile<T>(T value, Folders folder, string fileName)
        {
            var storageFile = await GetStorageFile(folder, fileName);

            var fileContent = JsonConvert.SerializeObject(value);

            await FileIO.WriteTextAsync(storageFile, fileContent, Windows.Storage.Streams.UnicodeEncoding.Utf8);
        }

        public static async Task DeleteFile(Folders folder, string fileName)
        {
            var storageFile = await GetStorageFile(folder, fileName);

            await storageFile.DeleteAsync();
        }
    }
}

