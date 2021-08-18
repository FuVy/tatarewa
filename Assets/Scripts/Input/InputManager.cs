using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerControls _playerControls;
    private Camera _camera;

    #region Events
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;
    public delegate void DetectPosition(Vector2 position);
    public event DetectPosition OnDetectPosition;
    #endregion
    private void Awake()
    {
        _playerControls = new PlayerControls();
        _camera = Camera.main;
    }

    private void Start()
    {
        _playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        _playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(_camera.ScreenToWorld(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(_camera.ScreenToWorld(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 PrimaryPosition()
    {
        return _camera.ScreenToWorld(_playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }
}
