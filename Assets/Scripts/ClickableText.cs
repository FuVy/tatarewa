using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickableText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _readArea;

    private string _text;

    private void Start()
    {
        _text = _readArea.text;
    }

    private int FindWordStart(int startPosition)
    {
        int i = startPosition;
        while(char.IsLetter(_text[i]))
        {
            i--;
        }
        return i;
    }

    private int FindWordEnd(int startPosition)
    {
        int i = startPosition;
        while(char.IsLetter(_text[i]))
        {
            i++;
        }
        return i;
    }

    public void TryToOutputWord()
    {
        int caretPosition = _readArea.stringPosition;

        if(caretPosition >= _text.Length)
        {
            return;
        }

        int wordStartIndex = FindWordStart(caretPosition);
        int wordEndIndex = FindWordEnd(caretPosition);

        if (wordStartIndex == wordEndIndex)
        {
            return;
        }

        print(wordStartIndex);
        print(_readArea.caretPosition);
        ChangeSelection(wordStartIndex, wordEndIndex, wordStartIndex + (wordEndIndex - wordStartIndex) - _readArea.caretPosition);

        string word = _text.Substring(wordStartIndex, wordEndIndex - wordStartIndex);

        //print(word);
    }

    private void ChangeSelection(int start, int end, int adjustValue)
    {
        _readArea.selectionAnchorPosition = start - adjustValue;
        _readArea.selectionFocusPosition = end - adjustValue;
    }
}
