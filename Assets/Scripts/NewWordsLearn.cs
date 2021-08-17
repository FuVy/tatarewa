using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class NewWordsLearn : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Speaker _speaker;
    [SerializeField]
    private Transform _toFlip;

    Dictionary<string, string>.KeyCollection _keyCollection;
    private List<string> _keys = new List<string>();
    private int _currentIndex = 0;
    private void Start()
    {
        Setup();
        Read();
    }

    private void Setup()
    {
        NewWordsIO.Init("NewWords");
        UpdateKeys();
    }

    private void UpdateKeys()
    {
        _keyCollection = NewWordsIO.CurrentWords.Words.Keys;
        _keys = new List<string>();
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
        else
        {
            _text.text = "Словарь пуст";
            _speaker.DeleteClip();
        }
    }

    public void GetTranslation()
    {
        if (_keys.Count > 0)
        {
            _toFlip.DORotate(new Vector3(0, 180, 0), 0.5f)
                .OnComplete(() =>
                {
                    _text.text = NewWordsIO.CurrentWords.Words[_keys[_currentIndex]];
                    _toFlip.DORotate(Vector3.zero, 0.5f);
                });
        }
    }

    public void RemoveFromDictionary()
    {
        if (_currentIndex < _keys.Count && _currentIndex >= 0)
        {
            NewWordsIO.RemoveFromDictionary(_keys[_currentIndex]);
            UpdateKeys();
            ChangeCurrentWord(-1);
            print(_keys.Count);
        }
    }

    private void OnDestroy()
    {
        NewWordsIO.SaveWords();
    }
}
