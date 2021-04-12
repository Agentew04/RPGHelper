using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace Ficha
{
    public static class SavingUWP
    {
        private readonly static StorageFolder appfolder = ApplicationData.Current.LocalFolder;
        public static StorageFile savefile;

        #region apploaded

        public static async void AppInitializedAsync()
        {
            if (savefile is null)
            {
                try
                {
                    savefile = await appfolder.GetFileAsync("config.json");
                }
                catch (Exception)
                {
                    savefile = await appfolder.CreateFileAsync("config.json");
                }
            }
            ConfigViewModel.Load();
        }

        #endregion

        #region othertasks

        public static string ObjectToString(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return json;
        }

        public async static Task<JObject> FileToJObjectAsync(StorageFile file)
        {
            string fileTxt = await FileIO.ReadTextAsync(file);
            return JObject.Parse(fileTxt);
        }

        public async static Task<T> FileToObjectAsync<T>(StorageFile file) where T : class
        {
            string text = await FileIO.ReadTextAsync(file);
            return JsonConvert.DeserializeObject<T>(text);
        }
        #endregion

        #region SavingToDisk

        public async static void SaveToDisk(StorageFile file, string jsonInString)
        {
            await FileIO.WriteTextAsync(file, jsonInString);
        }

        public async static void SaveToDisk(StorageFile file, JObject jsonInJObject)
        {
            await FileIO.WriteTextAsync(file, jsonInJObject.ToString());
        }

        public async static void SaveToDisk(StorageFile file, object jsonInObj)
        {           
            await FileIO.WriteTextAsync(file, ObjectToString(jsonInObj));
        }

        #endregion

        #region WriteOldSave

        public async static void WriteOldSave(string jsoninstring)
        {
            string timestamp = DateTime.Now.ToString();
            timestamp = timestamp.Replace('/', '-').Replace(':', '-').Replace(' ', '_');
            StorageFile oldsavefile = await appfolder.CreateFileAsync("config-" + timestamp + ".old");
            await FileIO.WriteTextAsync(oldsavefile, jsoninstring);
        }

        public async static void WriteOldSave(object jsoninobj)
        {
            string timestamp = DateTime.Now.ToString();
            timestamp = timestamp.Replace('/', '-').Replace(':', '-').Replace(' ', '_');
            StorageFile oldsavefile = await appfolder.CreateFileAsync("config-" + timestamp + ".old");
            await FileIO.WriteTextAsync(oldsavefile, ObjectToString(jsoninobj));
        }

        public async static void WriteOldSave(JObject jsoninJobject)
        {
            string timestamp = DateTime.Now.ToString();
            timestamp = timestamp.Replace('/', '-').Replace(':', '-').Replace(' ', '_');
            StorageFile oldsavefile = await appfolder.CreateFileAsync("config-" + timestamp + ".old");
            await FileIO.WriteTextAsync(oldsavefile, jsoninJobject.ToString());
        }

        #endregion  
    }
}
