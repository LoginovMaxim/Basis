using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Utils
{
    public class CSVReader
    {
        static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHARS = { '\"' };
 
        public static List<Dictionary<string, object>> GetList(string file)
        {
            var list = new List<Dictionary<string, object>>();
            var data = Resources.Load(file) as TextAsset;
 
            var lines = Regex.Split(data.text, LINE_SPLIT_RE);
 
            if(lines.Length <= 1) 
                return list;
 
            var header = Regex.Split(lines[0], SPLIT_RE);
            for(var i=1; i < lines.Length; i++) {
 
                var values = Regex.Split(lines[i], SPLIT_RE);
                if(values.Length == 0 ||values[0] == "") 
                    continue;
 
                var entry = new Dictionary<string, object>();
                for(var j=0; j < header.Length && j < values.Length; j++ ) {
                    var value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;
                    
                    if(int.TryParse(value, out var n)) 
                    {
                        finalvalue = n;
                    } 
                    else if (float.TryParse(value, out var f)) 
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;
                }
                list.Add(entry);
            }
            
            return list;
        }
        
        public static Dictionary<string, Dictionary<string, object>> GetDictionary(string file)
        {
            var dictionary = new Dictionary<string, Dictionary<string, object>>();
            var data = Resources.Load<TextAsset>(file);
 
            var lines = Regex.Split(data.text, LINE_SPLIT_RE);
 
            if(lines.Length <= 1) 
                return dictionary;
 
            var header = Regex.Split(lines[0], SPLIT_RE);
            for(var i=1; i < lines.Length; i++) {
 
                var values = Regex.Split(lines[i], SPLIT_RE);
                if(values.Length == 0 ||values[0] == "") 
                    continue;
 
                var entry = new Dictionary<string, object>();
                for(var j=1; j < header.Length && j < values.Length; j++ ) {
                    var value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                    object finalvalue = value;
                    
                    if(int.TryParse(value, out var n)) 
                    {
                        finalvalue = n;
                    } 
                    else if (float.TryParse(value, out var f)) 
                    {
                        finalvalue = f;
                    }
                    entry[header[j]] = finalvalue;
                }
                
                dictionary.Add(values[0], entry);
            }
            
            return dictionary;
        }
    }
}