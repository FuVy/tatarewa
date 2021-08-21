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
    [SerializeField]
    private ImageChanger _pauseChecker;

    private int _currentIndex;
    private Sentence[] _sentences;
    private bool _paused = false;

    public bool Paused => _paused;

    private void Start()
    {
        _readArea.text = BookDataHandler.Data.Text;
        _sentences = _readArea.text.Sentences();
        _currentIndex = BookDataHandler.Data.LeftOff;
        ReadSentence();
        print(_currentIndex);
    }

    public void ReadSentence()
    {
        UpdateSelection();
        _speaker.Load(_sentences[_currentIndex].text);
    }

    private void UpdateSelection()
    {
        StartCoroutine(_selector.Select(_sentences[_currentIndex].startIndex, _sentences[_currentIndex].endIndex));
    }

    public void Pause()
    {
        _speaker.Pause();
        Time.timeScale = 0f;
        _paused = true;
        _pauseChecker?.ChangePauseStatus(1);
    }

    public void Unpause()
    {
        _speaker.Unpause();
        Time.timeScale = 1f;
        _paused = false;
        UpdateSelection();
        _pauseChecker?.ChangePauseStatus(0);
    }

    public void CheckPause()
    {
        print(_paused);
        if (_paused)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    public void StartCountdown()
    {
        if (_currentIndex < _sentences.Length - 1)
        {
            _speaker.Play();
            CheckPause();
            Invoke("UpdateCurrentIndex", _speaker.ClipLength);
            Invoke("ReadSentence", _speaker.ClipLength + 0.01f);
        }
    }
    
    public void UpdateCurrentIndex()
    {
        _currentIndex++;
    }

    public void Restart()
    {
        _currentIndex = 0;
        CancelInvoke();
        ReadSentence();
    }

    public void InversePause()
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

    private void OnDestroy()
    {
        print(_currentIndex);
        BookDataHandler.Data.UpdateSentence(_currentIndex);
        BookDataHandler.Save();
    }
}
