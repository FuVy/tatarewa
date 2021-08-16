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

    private void Start()
    {
        var textFile = Resources.Load("Text/text01") as TextAsset;
        _textArea.text = textFile.text;
        _reader.Restart();
    }
}
