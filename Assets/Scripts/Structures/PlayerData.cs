[System.Serializable]
public class PlayerData
{
    private string _nickname;

    public string Nickname => _nickname;

    private int _age;

    public int Age => _age;

    private int _points;

    public int Points => _points;

    private NewWords _wordsToLearn;

    public NewWords WordsToLearn => _wordsToLearn;

    public PlayerData()
    {
        _nickname = "blank";
        _age = 0;
        _points = 0;
        _wordsToLearn = new NewWords();
    }
}
