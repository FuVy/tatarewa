using System.Collections;
using UnityEngine;
using TMPro;

public class WordPopup : MonoBehaviour
{
    [SerializeField]
    private Vector2 _popupOffset;
    [SerializeField]
    private Speaker _speaker;
    [SerializeField]
    private Reader _reader;
    [SerializeField]
    private Translator _translator;
    [SerializeField]
    private TextMeshProUGUI _text;

    [SerializeField]
    private RectTransform _canvas;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        gameObject.SetActive(false);
    }

    public void Show(string originalWord)
    {
        _speaker.Load(originalWord);
        _translator.Translate(originalWord);
    }

    public void SetPosition(int index)
    {
        var position = _text.textInfo.characterInfo[index].bottomLeft;
        Vector2 newPosition = _text.transform.TransformPoint(position) + (Vector3)_popupOffset;

        _transform.position = newPosition;
        ClampToScreen();
    }

    private void ClampToScreen()
    { 
        var sizeDelta = _canvas.sizeDelta - _transform.sizeDelta;
        var transformPivot = _transform.pivot;
        var position = _transform.anchoredPosition;
        position.x = Mathf.Clamp(position.x, -sizeDelta.x * transformPivot.x, sizeDelta.x * (1 - transformPivot.x));
        position.y = Mathf.Clamp(position.y, -sizeDelta.y * transformPivot.y, sizeDelta.y * (1 - transformPivot.y));
        _transform.anchoredPosition = position;
    }

    public void Hide()
    {
        _reader.Unpause();
        gameObject.SetActive(false);
    }
}
