using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteProjectRacerPage.Domain
{
    public class AboutMeManager
    {
        private string aboutMeTextFile = "PersistentData/AboutMe.txt";
        public string GetTextForAboutMe()
        {
            string result = "The file does not exist.";
            if (System.IO.File.Exists(aboutMeTextFile))
            {
                var userData = System.IO.File.ReadAllLines(aboutMeTextFile);
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
            try
            {
                if (aboutMeText != String.Empty)
                    System.IO.File.WriteAllTextAsync(aboutMeTextFile, aboutMeText);
            } catch(IOException)
            {
                Debug.WriteLine("File path does not eksist Path: " + aboutMeTextFile );
            }
        }
    }
}
