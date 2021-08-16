using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLoader : MonoBehaviour
{
    [SerializeField]
    private Reader _reader;
    [SerializeField]
    private TMP_InputField _textArea;
    private string _bookName;

    private void Start()
    {
        _bookName = PlayerPrefs.GetString("BookToRead");
        print(_bookName);
        var textFile = Resources.Load("Text/" + _bookName) as TextAsset;
        _textArea.text = textFile.text;
        _reader.Restart();
    }
}
