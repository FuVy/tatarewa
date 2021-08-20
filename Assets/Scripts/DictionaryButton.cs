using UnityEngine;

public class DictionaryButton : MonoBehaviour
{
    [SerializeField]
    private Translator _translator;
    public void AddToDictionary()
    {
        PlayerDataHandler.Data.WordsToLearn.AddToDictionary(_translator.OriginalWord, _translator.TranslatedWord);
        PlayerDataHandler.Save();
    }
}
