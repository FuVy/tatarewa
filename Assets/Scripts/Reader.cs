using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reader : MonoBehaviour
{
    [SerializeField]
    private int _offset;
    [SerializeField]
    private Speaker _speaker;
    [SerializeField]
    private TextSelector _selector;
    [SerializeField]
    private TMP_InputField _readArea;

    private int _currentIndex = 0;
    private int _nextIndex = 0;
    private string _textToSpeech = "";
    private void Start()
    {
        ReadSentence();
    }

    private void ReadSentence()
    {
        
        _nextIndex = _readArea.text.SentenceEnd(_currentIndex);

        for (int i = _currentIndex + _offset; i < _nextIndex; i++)
        {
            _textToSpeech += _readArea.text[i];
        }

        StartCoroutine(_selector.Select(_currentIndex, _nextIndex, 0));

        if (_currentIndex >= _readArea.text.Length)
        {
            return;
        }
        _speaker.Load(_textToSpeech);
        _currentIndex = _nextIndex + 1;
        _textToSpeech = "";
        
        //_speaker.Play();
    }

    public void Pause()
    {
        _speaker.Pause();
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        _speaker.Unpause();
        Time.timeScale = 1f;
    }

    public void StartCountdown()
    { 
        Invoke("ReadSentence", _speaker.ClipLength);
    }

}
