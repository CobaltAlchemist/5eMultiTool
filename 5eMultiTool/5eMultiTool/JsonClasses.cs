using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5eMultiTool.JsonClasses
{
    public class JsonMonster
    {
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string source { get; set; }
        public string alignment { get; set; }
        public string ac { get; set; }
        public string hp { get; set; }
        public string speed { get; set; }
        public string strength { get; set; }
        public string dexterity { get; set; }
        public string constitution { get; set; }
        public string intelligence { get; set; }
        public string wisdom { get; set; }
        public string charisma { get; set; }
        public string[] skills { get; set; }
        public string passivePerception { get; set; }
        public string languages { get; set; }
        public string cr { get; set; }
        public List<JsonLatr> trait { get; set; }
        public List<JsonLatr> action { get; set; }
        public string save { get; set; }
        public string spells { get; set; }
        public string senses { get; set; }
        public List<JsonLatr>  legendary { get; set; }
        public string immune { get; set; }
        public string description { get; set; }
        public string resist { get; set; }
        public string conditionImmune { get; set; }
        public string vulnerable { get; set; }
        public JsonLatr reaction { get; set; }
    }

    public class JsonLatr
    {
        public string name { get; set; }
        public string[] text { get; set; }
        public string[] attack { get; set; }
    }

    public class RootMonsterObject
    {
        public List<JsonMonster> monster { get; set; }
    }
}
