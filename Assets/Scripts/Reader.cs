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
    private Sentence[] _sentences;
    private bool _paused = false;
    private void Start()
    {
        _sentences = _readArea.text.Sentences();
        ReadSentence();
    }

    private void ReadSentence()
    {
        UpdateSelection();
        _speaker.Load(_sentences[_currentIndex].text);
        
    }

    private void UpdateSelection()
    {
        StartCoroutine(_selector.Select(_sentences[_currentIndex].startIndex, _sentences[_currentIndex].endIndex, 0));
    }

    public void Pause()
    {
        _speaker.Pause();
        Time.timeScale = 0f;
        _paused = true;
    }

    public void Unpause()
    {
        _speaker.Unpause();
        Time.timeScale = 1f;
        _paused = false;
        UpdateSelection();
    }

    public void StartCountdown()
    {
        if (_currentIndex < _sentences.Length - 1)
        {
            Invoke("UpdateCurrentIndex", _speaker.ClipLength);
            Invoke("ReadSentence", _speaker.ClipLength);
        }
    }
    
    public void UpdateCurrentIndex()
    {
        _currentIndex++;
    }

    public void Restart()
    {
        _currentIndex = 0;
        _sentences = _readArea.text.Sentences();
        CancelInvoke();
        ReadSentence();
    }

    public void CheckPause()
    {
        if (_paused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }
}
