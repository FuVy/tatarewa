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

    private void Awake()
    {
        //OnStart.Invoke();
    }

    public void LoadBook()
    {
        //_bookName = PlayerPrefs.GetString("BookToRead");
        Load(BookDataHandler.Data.Text);
    }

    public void Load(string text)
    {
        _textArea.text = text;
    }
}
