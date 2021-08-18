using System.Collections;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "NewBook", menuName = "Book")]
public class Book : ScriptableObject
{
    [SerializeField]
    private string _name;

    public string Name => _name;

    [SerializeField]
    private Sprite _coverImage;

    public Sprite CoverImage => _coverImage;

    [SerializeField]
    private string _description;

    public string Description => _description;
}
