using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha.Models
{
    public class BackpackItem
    {
        public int Quantity { get; set; } = 1;
        public string Name { get; set; } = "Objeto Desconhecido";
        public bool IsWeapon { get; set; } = false;
        public int BaseDamage { get; set; } = 0;
        public string SpecialEffect { get; set; } = "Sem efeito especial";
        public Skills RelatedSkill { get; set; } = Skills.None;
        public float SkillMultiplicator { get; set; } = 0;

        public string MainDisplay
        {
            get
            {
                if (IsWeapon)
                {
                    return $"{Name}";
                }
                //is item
                return $"{Name} x{Quantity}";
            }
        }
        public string SecondaryDisplay
        {
            get
            {
                if (IsWeapon)
                {
                    if(SkillMultiplicator > 0 && RelatedSkill != Skills.None)
                    {
                        //has skill
                        return $"Dano: {BaseDamage} + {RelatedSkill.UserFriendlyName}*{SkillMultiplicator} HP";
                    }
                    //doesn't have skill
                    return $"Dano: {BaseDamage}HP";

                }
                //is item
                return $"{SpecialEffect}";
            }
        }
    }
}
