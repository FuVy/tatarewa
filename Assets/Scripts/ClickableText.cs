using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickableText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _readArea;
    [SerializeField]
    private TextSelector _selector;
    [SerializeField]
    private WordPopup _popup;
    [SerializeField]
    private Reader _reader;

    private string _text;

    private void Start()
    {
        _text = _readArea.text;

        _readArea.verticalScrollbar.value = 0; //временно, в будущем вынести в отдельный скрипт, который будет ставить значение согласно сохраненному
    }

    public void TryToOutputWord()
    {
        _reader.Pause();

        int stringPosition = _readArea.stringPosition;

        if(stringPosition >= _text.Length)
        {
            return;
        }

        int wordStartIndex = _text.WordStart(stringPosition);
        int wordEndIndex = _text.WordEnd(stringPosition);

        if (wordStartIndex == wordEndIndex)
        {
            return;
        }

        StartCoroutine(_selector.Select(wordStartIndex, wordEndIndex, stringPosition - _readArea.caretPosition));

        string word = _text.Substring(wordStartIndex, wordEndIndex - wordStartIndex);

        _popup.gameObject.SetActive(true);
        _popup.SetPosition(_readArea.caretPosition - (word.Length / 2));
        _popup.Show(word);
    }
}
