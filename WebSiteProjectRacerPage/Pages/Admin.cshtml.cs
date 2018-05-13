﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebSiteProjectRacerPage.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        public string AboutMeText { get; set; }
        [BindProperty]
        public string[] Subbs { get; set; }

        public async Task OnGetAsync()
        {

            Task<string[]> getsub = new Task<string[]>(()=> GetSubricbbers());
            Task<string> getaboutMeText = new Task<string>(() => GetTextForAboutMe());
            getsub.Start();
            getaboutMeText.Start();

            Subbs = await getsub;
            AboutMeText = await getaboutMeText;
        }

        public void OnPost()
        {
            SaveAboutMeText(AboutMeText);
        }

        private void SaveAboutMeText(string aboutMeText)
        {
            System.IO.File.WriteAllTextAsync("PersistentData/AboutMe.txt", aboutMeText);
        }

        private string GetTextForAboutMe()
        {
            //Dublikeret kode!
            var dataFile = "PersistentData/AboutMe.txt";
            string result = "The file does not exist.";
            if (System.IO.File.Exists(dataFile))
            {
                var userData = System.IO.File.ReadAllLines(dataFile);
                if (userData == null)
                {
                    // Empty file.
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

        private string[] GetSubricbbers()
        {
            var dataFile = "PersistentData/emails.txt";
            string result = "The file does not exist.";
            if (System.IO.File.Exists(dataFile))
            {
                var userData = System.IO.File.ReadAllLines(dataFile);
                if (userData == null)
                {
                    // Empty file.
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
            string[] vs = result.Split(";").ToArray();
            return vs;
        }

    }
}