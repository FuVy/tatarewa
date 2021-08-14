using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWords
{
    [SerializeField]
    private Dictionary<string, string> _dictionary;

    public Dictionary<string, string> Dictionary => _dictionary;
}
