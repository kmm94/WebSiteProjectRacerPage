using System;
using System.Diagnostics;
using System.IO;

namespace WebSiteProjectRacerPage.Domain
{
    public class AboutMeManager
    {
        private string aboutMeTextFile = "PersistentData/AboutMe.txt";
        public string GetTextForAboutMe()
        {
            string result = "The file does not exist.";
            if (File.Exists(aboutMeTextFile))
            {
                var userData = File.ReadAllLines(aboutMeTextFile);
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
                    File.WriteAllTextAsync(aboutMeTextFile, aboutMeText);
            }
            catch (IOException)
            {
                Debug.WriteLine("File path does not eksist Path: " + aboutMeTextFile);
            }
        }
    }
}
