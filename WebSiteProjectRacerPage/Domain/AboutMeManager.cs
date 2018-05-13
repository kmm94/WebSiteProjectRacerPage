using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class AboutMeManager
    {
        public string GetTextForAboutMe()
        {
            var dataFile = "PersistentData/AboutMe.txt";
            string result = "The file does not exist.";
            if (System.IO.File.Exists(dataFile))
            {
                var userData = System.IO.File.ReadAllLines(dataFile);
                if (userData == null)
                {
                    result = "The file is empty.";
                }
                else
                {
                    result = null;
                    foreach (string item in userData)
                    {
                        result += item;
                    }
                }
            }
            return result;
        }
        public void SaveAboutMeText(string aboutMeText)
        {
            if(aboutMeText != String.Empty)
            System.IO.File.WriteAllTextAsync("PersistentData/AboutMe.txt", aboutMeText);
        }
    }
}
