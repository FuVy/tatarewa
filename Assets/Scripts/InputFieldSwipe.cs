using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(InputManager))]
public class InputFieldSwipe : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float _scrollMultiplier = 0.5f;
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private Scrollbar _scrollbar;

    private InputManager _inputManager;

    [SerializeField]
    private Vector2 _pointerPosition;

    private float _positionDelta;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        HandleSwipe();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector2 newPosition = _inputManager.PrimaryPosition();
        _pointerPosition = newPosition;
    }

    private void HandleSwipe()
    {
        _positionDelta = _pointerPosition.y - _inputManager.PrimaryPosition().y;
        print(_positionDelta);
        _scrollbar.value -= _positionDelta * _scrollMultiplier;
        _scrollbar.value = Mathf.Clamp(_scrollbar.value, 0f, 1f);
    }

    private void OnEnable()
    {
        _pointerPosition = _inputManager.PrimaryPosition();
    }
}
