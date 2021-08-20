using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ClickableText : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _readArea;
    [SerializeField]
    private TextSelector _selector;
    [SerializeField]
    private WordPopup _popup;
    [SerializeField]
    private UnityEvent OnClick;
    [SerializeField]
    private UnityEvent OnCancel;
    public void TryToOutputWord()
    {
        OnClick.Invoke();

        int stringPosition = _readArea.stringPosition;

        if(stringPosition >= _readArea.text.Length)
        {
            OnCancel.Invoke();
            return;
        }

        int wordStartIndex = _readArea.text.WordStart(stringPosition);
        int wordEndIndex = _readArea.text.WordEnd(stringPosition);
        if (wordStartIndex >= wordEndIndex)
        {
            OnCancel.Invoke();
            return;
        }

        string word = _readArea.text.Substring(wordStartIndex, wordEndIndex - wordStartIndex);

        _popup.gameObject.SetActive(true);
        _popup.SetPosition(_readArea.caretPosition);
        _popup.Show(word);

        StartCoroutine(_selector.Select(wordStartIndex, wordEndIndex));
    }
}
