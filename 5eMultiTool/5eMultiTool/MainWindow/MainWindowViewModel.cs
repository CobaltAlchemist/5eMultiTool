using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Web.Script.Serialization;

namespace _5eMultiTool
{
    class MainWindowViewModel : ObservableObject
    {
        private DelegateCommand _parseMonstersCommand;
        public DelegateCommand ParseMonstersCommand
        { get { return _parseMonstersCommand; } }

        public MainWindowViewModel()
        {
            LoadMainWindowViewModel();
        }

        private void LoadMainWindowViewModel()
        {
            _parseMonstersCommand = new DelegateCommand(
                (x)=>
                {
                    ParseDatabase();//jk
                });
        }

        private void ParseDatabase()
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://astranauta.github.io//data//bestiary.json");
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            JsonClasses.RootMonsterObject monsters = js.Deserialize<JsonClasses.RootMonsterObject>(json);
            MessageBox.Show(monsters.monster[0].ToString());
            _5eDatabaseDataContext db = new _5eDatabaseDataContext();
            foreach (JsonClasses.JsonMonster jm in monsters.monster)
            {
                Monster m = new Monster();
                m.Name = jm.name;
                m.Type = jm.type;
                m.Source = jm.source;
                m.Alignment = jm.alignment;
                m.AC = Convert.ToByte(jm.ac);
                m.AvgHP = Convert.ToInt16(jm.hp.Substring(0, jm.hp.IndexOf(' ')));
                m.HP = jm.hp.Substring(jm.hp.IndexOf(" ") + 1);
                m.Speed = jm.speed;
                m.Strength = Convert.ToByte(jm.strength);
                m.Dexterity = Convert.ToByte(jm.dexterity);
                m.Constitution = Convert.ToByte(jm.constitution);
                m.Intelligence = Convert.ToByte(jm.intelligence);
                m.Wisdom = Convert.ToByte(jm.wisdom);
                m.Charisma = Convert.ToByte(jm.charisma);
                m.Passive_Perception = Convert.ToByte(jm.passivePerception);
                if (jm.cr.Contains("/"))
                {
                    m.CR = Convert.ToDecimal(jm.cr[0]) / Convert.ToDecimal(jm.cr[2]);
                }
                else
                    m.CR = Convert.ToDecimal(jm.cr);
                db.Monsters.InsertOnSubmit(m);
                List<Trait> ts = new List<Trait>();
                foreach (JsonClasses.JsonLatr jl in jm.trait)
                {
                    Trait t = new Trait();
                    t.Name = jl.name;
                    t.Description = jl.text;
                }
                db.SubmitChanges();
            }
            return;
        }
    }
}
