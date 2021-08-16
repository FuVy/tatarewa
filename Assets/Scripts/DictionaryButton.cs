using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryButton : MonoBehaviour
{
    [SerializeField]
    private Translator _translator;

    public void AddToDictionary()
    {
        NewWordsIO.Init("NewWords");
        NewWordsIO.AddToDictionary(_translator.OriginalWord, _translator.TranslatedWord);
        NewWordsIO.SaveWords();
    }
}
