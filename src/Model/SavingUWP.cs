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

        /// <summary>
        /// Create the file if it didn't existed
        /// </summary>
        public static void CreateFile()
        {
            savefile = appfolder.CreateFileAsync("config.json", CreationCollisionOption.OpenIfExists).AsTask().Result;
        }

        public async static Task<bool> CheckIfSaveExists()
        {
            StorageFile save;
            try
            {
                save = await appfolder.GetFileAsync("config.json");
            }
            catch (Exception) { return false; }
            return save != null;
        }
        public static string ObjectToString(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return json;
        }

        #region SavingToDisk
        public async static void SaveToDisk(string jsonInString)
        {
            if(!CheckIfSaveExists().Result)
            { CreateFile(); }
            await FileIO.WriteTextAsync(savefile, jsonInString);

        }
        public async static void SaveToDisk(JObject jsonInJObject)
        {
            if (!CheckIfSaveExists().Result)
            { CreateFile(); }
            var json = jsonInJObject.ToString();
            await FileIO.WriteTextAsync(savefile, json);
        }
        public static void SaveToDisk(object jsonInObj)
        {
            if (!CheckIfSaveExists().Result)
            { CreateFile(); }
            var json = ObjectToString(jsonInObj);
            var x = FileIO.WriteTextAsync(savefile, json);
            while (!(x.Status == Windows.Foundation.AsyncStatus.Completed))
            {
                continue;
            }
            return;
        }
        #endregion

        public static JObject FileToJObject()
        {
            if (!CheckIfSaveExists().Result)
            { CreateFile(); }
            string fileTxt = FileIO.ReadTextAsync(savefile).GetResults();
            JObject jobj = JObject.Parse(fileTxt);
            return jobj;
        }

        public static T FileToObject<T>() where T : class
        {
            if (!CheckIfSaveExists().Result)
            { CreateFile(); }
            string text = FileIO.ReadTextAsync(savefile).GetResults();
            return JsonConvert.DeserializeObject<T>(text);
        }
        #region WriteOldSave
        public async static void WriteOldSave(string jsoninstring)
        {
            StorageFile oldsavefile =await appfolder.CreateFileAsync("config-" + DateTime.Now + ".old");
            await FileIO.WriteTextAsync(oldsavefile, jsoninstring);
        }
        public async static void WriteOldSave(object jsoninobj)
        {
            StorageFile oldsavefile = await appfolder.CreateFileAsync("config-" + DateTime.Now + ".old");
            var x = ObjectToString(jsoninobj);
            await FileIO.WriteTextAsync(oldsavefile, x);
        }
        public async static void WriteOldSave(JObject jsoninJobject)
        {
            StorageFile oldsavefile = await appfolder.CreateFileAsync("config-" + DateTime.Now + ".old");
            var x = jsoninJobject.ToString();
            await FileIO.WriteTextAsync(oldsavefile, x);
        }
        #endregion
    }
}
