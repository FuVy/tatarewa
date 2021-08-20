using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class ProfilePageHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _quantity;

    void Awake()
    {
        PlayerDataHandler.Init();
    }

    public void UpdateQuantity()
    {
        _quantity.text = string.Format("Количество слов для изучения: {0}", PlayerDataHandler.Data.WordsToLearn.Words.Keys.Count);
    }

    private void OnEnable()
    {
        UpdateQuantity();
    }
}
