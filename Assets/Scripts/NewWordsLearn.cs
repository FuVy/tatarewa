using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class NewWordsLearn : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Speaker _speaker;
    [SerializeField]
    private Transform _toFlip, _rotateButton;
    [SerializeField]
    private GameObject _soundImage;

    Dictionary<string, string>.KeyCollection _keyCollection;
    private List<string> _keys = new List<string>();
    private string[] _currentPair = new string[2];
    private int _currentIndex = 0;
    private void Start()
    {
        _currentIndex = 0;
        ChangeCurrentWord(0);
    }

    private void UpdateKeys()
    {
        _keyCollection = PlayerDataHandler.Data.WordsToLearn.Words.Keys;
        _keys = new List<string>();
        foreach (string s in _keyCollection)
        {
            _keys.Add(s);
        }
    }

    public void ChangeCurrentWord(int value)
    {
        _speaker.Stop();
        _currentIndex += value;
        if (_currentIndex < 0)
        {
            _currentIndex = _keys.Count - 1;
        }
        else if (_currentIndex > _keys.Count - 1)
        {
            _currentIndex = 0;
        }
        UpdatePair();
        Read();
    }

    public void Read()
    {
        if (_keys.Count > 0)
        {
            Read(_currentPair[0]);
            _text.text = _currentPair[0];
        }
        else
        {
            _text.text = "Словарь пуст";
            _speaker.DeleteClip();
        }
    }

    private void UpdatePair()
    {
        if (HasItems())
        {
            _currentPair[0] = _keys[_currentIndex];
            _currentPair[1] = PlayerDataHandler.Data.WordsToLearn.Words[_keys[_currentIndex]];
        }
    }

    private void SwapPairValues()
    {
        string temp = _currentPair[0];
        _currentPair[0] = _currentPair[1];
        _currentPair[1] = temp;
    }

    private void Read(string text)
    {
        _speaker.Load(text);
    }

    public void ShowTranslation()
    {
        if (_keys.Count > 0)
        {
            _toFlip.DORotate(new Vector3(0, 90, 0), 0.3f)
                .OnComplete(() =>
                {
                    _text.text = _currentPair[1];
                    _toFlip.DORotate(new Vector3(0, 270, 0), 0f, RotateMode.FastBeyond360);
                    _toFlip.DORotate(new Vector3(0, 0, 0), 0.3f);
                    SwapPairValues();
                });
            _rotateButton.DOBlendableRotateBy(new Vector3(0, 0, -80), 1f);
        }
    }

    public void RemoveFromDictionary()
    {
        if (_currentIndex < _keys.Count && _currentIndex >= 0)
        {
            PlayerDataHandler.Data.WordsToLearn.RemoveFromDictionary(_keys[_currentIndex]);
            UpdateKeys();
            ChangeCurrentWord(-1);
            print(_keys.Count);
        }
    }

    private bool HasItems()
    {
        if (_keys.Count > 0)
        {
            return true;
        }
        else return false;
    }
    private void OnEnable()
    {
        UpdateKeys();
    }
    private void OnDisable()
    {
        PlayerDataHandler.Save();
    }
}
