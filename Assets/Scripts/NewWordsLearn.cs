using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewWordsLearn : MonoBehaviour
{
    [SerializeField]
    private NewWordsHolder _newWords;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Speaker _speaker;

    private Dictionary<string, string>.KeyCollection _keyCollection;
    private List<string> _keys = new List<string>();
    private int _currentIndex = 0;
    private void Start()
    {
        Setup();
        Read();
    }

    private void Setup()
    {
        _keyCollection = _newWords.Words.Dictionary.Keys;

        foreach (string s in _keyCollection)
        {
            _keys.Add(s);
        }
    }

    public void ChangeCurrentWord(int value)
    {
        _currentIndex += value;
        if (_currentIndex < 0)
        {
            _currentIndex = _keys.Count - 1;
        }
        else if (_currentIndex > _keys.Count - 1)
        {
            _currentIndex = 0;
        }
        Read();
    }

    public void Read()
    {
        if (_keys.Count > 0)
        {
            _speaker.Load(_keys[_currentIndex]);
            _text.text = _keys[_currentIndex];
        }
    }
}
