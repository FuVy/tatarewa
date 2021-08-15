using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHolder : MonoBehaviour
{
    [SerializeField]
    private Book _book;

    public Book Book => _book;
}

