using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class ProfilePageHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _quantity, _nickname;

    void Awake()
    {
        PlayerDataHandler.Init();
    }

    public void UpdatePage()
    {
        _quantity.text = string.Format("Количество слов для изучения: {0}", PlayerDataHandler.Data.WordsToLearn.Words.Keys.Count);
        _nickname.text = PlayerDataHandler.Data.Nickname;
    }

    private void OnEnable()
    {
        UpdatePage();
    }
}
