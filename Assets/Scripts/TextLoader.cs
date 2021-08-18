using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextLoader : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _textArea;
    [SerializeField]
    private UnityEvent OnStart;
    private string _bookName;

    private void Start()
    {
        OnStart.Invoke();
    }

    public void LoadBook()
    {
        _bookName = PlayerPrefs.GetString("BookToRead");
        print(_bookName);
        var textFile = Resources.Load("Text/" + _bookName) as TextAsset;
        //_textArea.text = textFile.text;
        Load(textFile.text);
        //_reader.Restart();
    }

    public void Load(string text)
    {
        _textArea.text = text;
    }
}
