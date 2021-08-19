using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TextLoader : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textArea;
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    protected UnityEvent OnStart;
    protected string _bookName;

    private void Start()
    {
         OnStart.Invoke();
    }
    public void LoadBook()
    {
        _bookName = PlayerPrefs.GetString("BookToRead");
        print(_bookName);
        var textFile = Resources.Load("Text/" + _bookName) as TextAsset;
        Load(textFile.text);
    }
    public void Load(string text)
    {
        _inputField?.Load(text);
        _textArea?.Load(text);
    }
}