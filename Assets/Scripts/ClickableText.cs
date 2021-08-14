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
        int stringPosition = _readArea.stringPosition;

        if(stringPosition >= _text.Length)
        {
            return;
        }

        int wordStartIndex = FindWordStart(stringPosition);
        int wordEndIndex = FindWordEnd(stringPosition);

        if (wordStartIndex == wordEndIndex)
        {
            return;
        }

        ChangeSelection(wordStartIndex, wordEndIndex, stringPosition - _readArea.caretPosition);

        //string word = _text.Substring(wordStartIndex, wordEndIndex - wordStartIndex);

        //print(word);
    }

    private void ChangeSelection(int start, int end, int adjustValue)
    {
        _readArea.selectionAnchorPosition = start - adjustValue + 1;
        _readArea.selectionFocusPosition = end - adjustValue;
    }
}
