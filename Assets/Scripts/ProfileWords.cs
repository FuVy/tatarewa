using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileWords : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _quantity;

    void Start()
    {
        NewWordsIO.Init("NewWords");
        UpdateQuantity();
    }

    public void UpdateQuantity()
    {
        _quantity.text = string.Format("Количество слов для изучения: {0}", NewWordsIO.CurrentWords.Words.Keys.Count);
    }
}
