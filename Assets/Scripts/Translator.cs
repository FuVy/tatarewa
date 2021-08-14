using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Translator : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _translatedText;
    [SerializeField]
    private TMP_Text _originalText;

    private string _translatedWord;

    public string TranslatedWord => _translatedWord;

    private string _originalWord;

    public string OriginalWord => _originalWord;

    private TranslatorResponse _response;

    public void Translate(string text)
    {
        StartCoroutine(GetTranslation(text));
        _originalWord = text;
        _originalText.text = _originalWord;
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
                Output();
            }
        }
    }

    private void Clear()
    {
        _response.responseData.translatedText = _response.responseData.translatedText.Replace("#", "");
    }

    private void Output()
    {
        _translatedText.text = _translatedWord;
    }
}
