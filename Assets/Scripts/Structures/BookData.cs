[System.Serializable]
public class BookData
{
    private string _title;

    public string Title => _title;

    private string _text;

    public string Text => _text;

    private Sentence _leftOff;

    public Sentence LeftOff;
}
