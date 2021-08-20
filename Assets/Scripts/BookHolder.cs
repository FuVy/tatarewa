using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BookHolder : MonoBehaviour
{
    [SerializeField]
    private Book _book;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private TMP_Text _title, _author;

    public Book Book => _book;
    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        _image.sprite = _book.CoverImage;
        _title.text = _book.Title;
        _author.text = _book.Author;
    }

    public void LoadBook()
    {
        PlayerPrefs.SetString("BookToRead", _book.Title);
        SceneManager.LoadScene(1);
    }
}

