using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class LoadMyText : MonoBehaviour
{

    public static void getWords(string language)
    {
        Debug.Log("Language in getWords: " + language);
        Dictionary<string, string> words = new Dictionary<string, string>();
        TextAsset mytxtData = (TextAsset)Resources.Load(language + "/" + language);
        Debug.Log(mytxtData.text);
        string all = mytxtData.text;
        string[] line = Regex.Split(all, "\n|\r|\r\n");
        for (int i = 0; i < line.Length; i++)
        {
            string[] parts = Regex.Split(line[i], "=");
            if (parts.Length == 2)
            {
                words.Add(parts[0], parts[1]);
            }
            
        }
        MyGameManager.LearningLanguage = new Dictionary<string, string>(words);
    }

    public static void getMyLanguage()
    {
        Dictionary<string, string> words = new Dictionary<string, string>();
        TextAsset mytxtData = (TextAsset)Resources.Load("Translation");
        Debug.Log(mytxtData.text);
        string all = mytxtData.text;
        string[] line = Regex.Split(all, "\n|\r|\r\n");
        for (int i = 0; i < line.Length; i++)
        {
            string[] parts = Regex.Split(line[i], "=");
            if (parts.Length == 2)
            {
                words.Add(parts[0], parts[1]);
            }

        }
        MyGameManager.Keys = new List<string>(words.Keys);
        MyGameManager.MyLanguage = new Dictionary<string, string>(words);
    }
}

