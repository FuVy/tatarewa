using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _slide;
    [SerializeField]
    private TMP_Text _buttonText;

    private static List<TMP_Text> _buttonsText = new List<TMP_Text>();
    private static List<GameObject> _slides = new List<GameObject>();

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        if (!_buttonsText.Contains(_buttonText))
        {
            _buttonsText.Add(_buttonText);
        }

        if (!_slides.Contains(_slide))
        {
            _slides.Add(_slide);
        }
    }

    public static void TurnOff()
    {
        foreach (TMP_Text text in _buttonsText)
        {
            text.color = Color.black;
        }
        foreach (GameObject slide in _slides)
        {
            slide.gameObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        TurnOff();
        _buttonText.color = Color.red;
        _slide.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _slides = new List<GameObject>();
    }
}
