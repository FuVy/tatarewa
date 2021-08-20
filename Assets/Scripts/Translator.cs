using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class Translator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _translatedText;
    [SerializeField]
    private TMP_Text _originalText;
    [SerializeField]
    private UnityEvent<string> OnOutput;

    private string _translatedWord;

    public string TranslatedWord => _translatedWord;

    private string _originalWord;

    public string OriginalWord => _originalWord;

    private TranslatorResponse _response;


    public void Translate(string text)
    {
        StartCoroutine(GetTranslation(text));
        _originalWord = text;
    }

    IEnumerator GetTranslation(string text)
    {
        WWWForm form = new WWWForm();
        form.AddField("langpair", "tat|rus");
        form.AddField("q", text);
        form.AddField("markUnknown", "no");
        using (UnityWebRequest www = UnityWebRequest.Post(ServerConfig.TRANSLATOR_SERVER_URL, form))
        {
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string responseJson = www.downloadHandler.text;
                _response = JsonUtility.FromJson<TranslatorResponse>(responseJson);
                Clear();
                _translatedWord = _response.responseData.translatedText;
                OnOutput.Invoke(_translatedWord);
            }
        }
    }

    private void Clear()
    {
        _response.responseData.translatedText = _response.responseData.translatedText.Replace("#", "");
    }

    public void Output()
    {
        if (_translatedText)
        {
            _translatedText.text = _translatedWord;
        }
        if (_originalText)
        {
            _originalText.text = _originalWord;
        }
        if (_translatedWord == _originalWord)
        {
            _translatedText.text = "Перевод отсутствует";
        }
    }
}
