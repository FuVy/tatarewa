using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputManager))]
public class InputFieldSwipe : MonoBehaviour
{
    [SerializeField]
    private Scrollbar _scrollbar;

    private InputManager _inputManager;
    [SerializeField]
    private Vector2 _pointerPosition;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {
        _pointerPosition = _inputManager.PrimaryPosition();
        HandleSwipe();
    }

    private void HandleSwipe()
    {
        //доделать с утра
    }
}
