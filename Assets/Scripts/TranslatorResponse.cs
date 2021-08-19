[System.Serializable]
public class TranslatorResponse
{
    public ResponseData responseData;
    public string responseDetails;
    public int responseStatus;
}

[System.Serializable]
public class ResponseData
{
    public string translatedText;
}
