using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class NewWords
{
    public Dictionary<string, string> Words;

    public NewWords()
    {
        Words = new Dictionary<string, string>();
    }
    public void AddToDictionary(string original, string translated)
    {
        original = original.ToLower();
        if (!Words.ContainsKey(original))
        {
            Words.Add(original, translated);
        }
    }
    public void RemoveFromDictionary(string original)
    {
        if (Words.ContainsKey(original))
        {
            Words.Remove(original);
        }
    }
}
