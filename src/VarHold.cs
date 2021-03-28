using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Newtonsoft.Json.Linq;
using TesteCSharp.Windows;
using TesteCSharp;
using TesteCSharp.Assistant;
using System.IO;

namespace TesteCSharp.Assistant
{
    public class Saving
    {
        readonly string apppath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rodrigo's_Stuff\Ficha";
        public JObject CreateJSONFile()
        {
            JObject saveFile =
                new JObject(
                    new JProperty("ficha",
                        new JObject(
                            new JProperty("character",
                                new JObject(
                                    new JProperty("nome", TempData.nome),
                                    new JProperty("classe", TempData.classe),
                                    new JProperty("pacto", TempData.pacto),
                                    new JProperty("mochila", TempData.mochila))),
                            new JProperty("habilidades",
                                new JObject(
                                    new JProperty("forca", TempData.habilidades["forca"]),
                                    new JProperty("vitalidade", TempData.habilidades["vitalidade"]),
                                    new JProperty("resistencia", TempData.habilidades["resistencia"]),
                                    new JProperty("destreza", TempData.habilidades["destreza"]),
                                    new JProperty("percepcao", TempData.habilidades["percepcao"]),
                                    new JProperty("memoria", TempData.habilidades["memoria"]),
                                    new JProperty("labia", TempData.habilidades["labia"]),
                                    new JProperty("fe", TempData.habilidades["fe"]),
                                    new JProperty("trevas", TempData.habilidades["trevas"]),
                                    new JProperty("total", TempData.habilidades["total"]))
                                    ),
                            new JProperty("stats",
                                new JObject(
                                    new JProperty("xp", TempData.experience),
                                    new JProperty("nivel", TempData.level),
                                    new JProperty("is_progression_stopped", TempData.isLevelProgressionStopped),
                                    new JProperty("vida_total", TempData.VidaTotal),
                                    new JProperty("vida_atual", TempData.VidaAtual),
                                    new JProperty("ouro", TempData.money))))),
                    new JProperty("config",
                        new JObject(
                            new JProperty("_comment", "not implemented yet"))),
                    new JProperty("core_rpg",
                        new JObject(
                            new JProperty("_comment", "NÃO MODIFICAR ISTO, PODE QUEBRAR O APP"),
                            new JProperty("levelxp", TempData.levelxp)))
                    );
            return saveFile;
        }
        public void SaveToDisk(JObject jsonfile)
        {
            if (Directory.Exists(apppath))
            {
                File.WriteAllText(apppath+@"\config.json", jsonfile.ToString());
            }
            else
            {
                Directory.CreateDirectory(apppath);
                File.WriteAllText(apppath + @"\config.json", jsonfile.ToString());
            }
        }
        public JObject GetJSONFromFile()
        {
            if (!Directory.Exists(apppath))
            {
                Directory.CreateDirectory(apppath);
            }
            if (!File.Exists(apppath + @"\config.json"))
            {
                SaveToDisk(CreateJSONFile());
            ;}
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Rodrigo's_Stuff\Ficha\config.json";
            JObject file = JObject.Parse(File.ReadAllText(path));
            return file;


        }
        public void LoadFromJSON(JObject jsonfile)
        {
            //ficha
            TempData.money = (ulong)jsonfile["ficha"]["stats"]["ouro"];
            TempData.nome = (string)jsonfile["ficha"]["character"]["nome"];
            TempData.classe = (string)jsonfile["ficha"]["character"]["classe"];
            TempData.pacto = (string)jsonfile["ficha"]["character"]["pacto"];
            TempData.mochila = (string)jsonfile["ficha"]["character"]["mochila"];
            TempData.VidaTotal = (int)jsonfile["ficha"]["stats"]["vida_total"];
            TempData.VidaAtual = (int)jsonfile["ficha"]["stats"]["vida_atual"];
            TempData.experience = (double)jsonfile["ficha"]["stats"]["xp"];
            TempData.level = (int)jsonfile["ficha"]["stats"]["nivel"];
            TempData.isLevelProgressionStopped = (bool)jsonfile["ficha"]["stats"]["is_progression_stopped"];
            TempData.habilidades["total"] = (ulong)jsonfile["ficha"]["habilidades"]["total"];
            TempData.habilidades["forca"] = (ulong)jsonfile["ficha"]["habilidades"]["forca"];
            TempData.habilidades["vitalidade"] = (ulong)jsonfile["ficha"]["habilidades"]["vitalidade"];
            TempData.habilidades["resistencia"] = (ulong)jsonfile["ficha"]["habilidades"]["resistencia"];
            TempData.habilidades["destreza"] = (ulong)jsonfile["ficha"]["habilidades"]["destreza"];
            TempData.habilidades["percepcao"] = (ulong)jsonfile["ficha"]["habilidades"]["percepcao"];
            TempData.habilidades["memoria"] = (ulong)jsonfile["ficha"]["habilidades"]["memoria"];
            TempData.habilidades["labia"] = (ulong)jsonfile["ficha"]["habilidades"]["labia"];
            TempData.habilidades["fe"] = (ulong)jsonfile["ficha"]["habilidades"]["fe"];
            TempData.habilidades["trevas"] = (ulong)jsonfile["ficha"]["habilidades"]["trevas"];
            //will not change for now, not ready yet
            //core mechanics
            //var x = jsonfile["core_rpg"]["levelxp"];
            //TempData.levelxp.Clear();
            //foreach(int y in x)
            //{
            //    TempData.levelxp.Add(y);
            //}
        }
    }
    public static class TempData
    {
        public static ulong money = 0;

        public static string nome = "Nome";
        public static string classe = "Classe";
        public static string pacto = "Pacto";
        public static string mochila = "Vazia";

        public static int VidaTotal = 10;
        public static int VidaAtual = 10;

        public static double experience = 0;
        public static int level = 1;

        public static List<int> levelxp = new List<int>()
        {
            0,50,70,120,160,200,250,270,300,400,500,600,850,900,950,1000
        };
        public static bool isLevelProgressionStopped = false;

        public static Dictionary<String, ulong> habilidades = new Dictionary<String, ulong>()
        {
            {"total",0 },
            {"forca",0 },
            {"vitalidade",0 },
            {"resistencia",0 },
            {"destreza",0 },
            {"percepcao",0 },
            {"memoria",0 },
            {"labia",0 },
            {"fe",0 },
            {"trevas",0 },
        };
    }
}
