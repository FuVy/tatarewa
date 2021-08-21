using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;

    [SerializeField]
    private Image _imageComponent;

    public void ChangePauseStatus(int status)
    {
        _imageComponent.overrideSprite = _sprites[status];
    }
}
