using System;
using System.Collections.Generic;
using UnityEngine;

namespace MultiLanguage
{
    public class LanguageManager : MonoBehaviour
    {
        
        private static LanguageManager _instance;
        
        private Dictionary<string, string[]> lines = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

        private string resourceLanguageFolder = "Languages";

        private string languageExtensionFile = ".yaml";
        
        private string defaultLanguage = "en";

        private string overrideLanguage = "";

        private void Awake(){
            DontDestroyOnLoad (this);
         
            if (_instance == null) {
                _instance = this;
            } else {
                Destroy(gameObject);
            }
        }
    }
}