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
                    ParseDatabase();
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
            return;
        }
    }
}
