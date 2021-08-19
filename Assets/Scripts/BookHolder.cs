using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BookHolder : MonoBehaviour
{
    [SerializeField]
    private Book _book;

    [SerializeField]
    private Image _image;

    public Book Book => _book;
    private void Start()
    {
        _image.sprite = _book.CoverImage;
    }

    public void LoadBook()
    {
        PlayerPrefs.SetString("BookToRead", _book.Title);
        SceneManager.LoadScene(1);
    }
}

