using System;
using System.Collections.Generic;
using UnityEngine;

namespace MultiLanguage
{
    public class LanguageManager : MonoBehaviour
    {
        private Dictionary<string, string[]> lines = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

        private string resourceLanguageFolder = "Languages";

        private string languageExtensionFile = ".yaml";
        
        private string defaultLanguage = "en";

        private string overrideLanguage = "";
        
        private void Awake()
        {
            //TODO get's available languages labels 
        }
    }
}