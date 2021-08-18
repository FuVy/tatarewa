using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryButton : MonoBehaviour
{
    [SerializeField]
    private Translator _translator;

    private void Start()
    {
        NewWordsIO.Init("NewWords");
    }
    public void AddToDictionary()
    {
        NewWordsIO.AddToDictionary(_translator.OriginalWord, _translator.TranslatedWord);
        NewWordsIO.SaveWords();
    }
    public void AddToDictionaryReversed()
    {
        NewWordsIO.AddToDictionary(_translator.TranslatedWord, _translator.OriginalWord);
        NewWordsIO.SaveWords();
    }
}
