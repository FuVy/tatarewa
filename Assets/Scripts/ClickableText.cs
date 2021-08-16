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

    private void Start()
    {
        _readArea.verticalScrollbar.value = 0; //временно, в будущем вынести в отдельный скрипт, который будет ставить значение согласно сохраненному
    }

    public void TryToOutputWord()
    {
        _reader.Pause();

        int stringPosition = _readArea.stringPosition;

        if(stringPosition >= _readArea.text.Length)
        {
            _reader.Unpause();
            return;
        }

        int wordStartIndex = _readArea.text.WordStart(stringPosition) + 1;
        int wordEndIndex = _readArea.text.WordEnd(stringPosition);
        if (wordStartIndex >= wordEndIndex)
        {
            _reader.Unpause();
            return;
        }

        string word = _readArea.text.Substring(wordStartIndex, wordEndIndex - wordStartIndex);

        _popup.gameObject.SetActive(true);
        _popup.SetPosition(_readArea.caretPosition);
        _popup.Show(word);

        StartCoroutine(_selector.Select(wordStartIndex, wordEndIndex));
    }
}
