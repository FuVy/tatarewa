[System.Serializable]
public class BookData
{
    private string _title;

    public string Title => _title;

    private string _text;

    public string Text => _text;

    private int _leftOff;

    public int LeftOff => _leftOff;
    
    public BookData(string title, string text)
    {
        _title = title;
        _text = text;
        _leftOff = 0;
    }

    public BookData(){ }

    public void UpdateSentence(int index)
    {
        _leftOff = index;
    }
}
