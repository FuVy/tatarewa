using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWords", menuName = "Dictionary")]
public class NewWordsHolder : ScriptableObject
{
    [SerializeField]
    private NewWords _words;

    public NewWords Words => _words;

    public void AddToDictionary(string original, string translated)
    {
        if (!_words.Dictionary.ContainsKey(original))
        {
            _words.Dictionary.Add(original, translated);
        }
    }

    public void RemoveFromDictionary(string original)
    {
        if (_words.Dictionary.ContainsKey(original))
        {
            _words.Dictionary.Remove(original);
        }
    }
}
