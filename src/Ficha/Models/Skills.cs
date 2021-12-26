using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.SmartEnum;

namespace Ficha.Models
{
    public sealed class Skills : SmartEnum<Skills>
    {
        public static readonly Skills None = new("None", 0, "Nada", "NUL");
        public static readonly Skills Dexterity = new("Dexterity", 1, "Destreza", "DES");
        public static readonly Skills Strength = new("Strength", 2, "Força", "FOR");
        public static readonly Skills Vitality = new("Vitality", 3, "Vitalidade", "VIT");
        public static readonly Skills Intelligence = new("Intelligence", 4, "Inteligência", "INT");
        public static readonly Skills Speak = new("Speak", 5, "Lábia", "LAB");
        public static readonly Skills Wisdom = new("Wisdom", 6, "Sabedoria", "SAB");

        public string UserFriendlyName { get; }
        public string Code { get; }

        public Skills(string name, int value, string userFriendlyName, string code) : base(name, value)
        {
            UserFriendlyName=userFriendlyName;
            Code=code;
        }
        public static Skills FromCode(string code)
        {
            return code switch
            {
                "NUL" => None,
                "DES" => Dexterity,
                "FOR" => Strength,
                "VIT" => Vitality,
                "INT" => Intelligence,
                "LAB" => Speak,
                "SAB" => Wisdom,
                _ => None,
            };
        }
    }
}
