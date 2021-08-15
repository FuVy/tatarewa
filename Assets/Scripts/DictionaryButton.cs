using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryButton : MonoBehaviour
{
    [SerializeField]
    private Translator _translator;
    [SerializeField]
    private NewWordsHolder _dictionary;

    public void AddToDictionary()
    {
        _dictionary.AddToDictionary(_translator.OriginalWord, _translator.TranslatedWord);
    }
}
