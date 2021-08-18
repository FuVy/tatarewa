using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InputManager))]
public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float _minimumSwipeDistance = 0.1f;
    [SerializeField]
    private float _maximumSwipeTime = 1f;
    [SerializeField, Range(0, 1f)]
    private float _directionThreshold = 0.9f;
    [SerializeField]
    private UnityEvent OnSwipeStart;
    [SerializeField]
    private UnityEvent OnSwipeEnd;

    private InputManager _inputManager;

    private Vector2 _startPosition;
    private float _startTime;
    private Vector2 _endPosition;
    private float _endTime;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        OnSwipeStart.Invoke();
        _startPosition = position;
        _startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
        OnSwipeEnd.Invoke();
    }

    private void DetectSwipe()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        if (Vector3.Distance(_startPosition, _endPosition) >= _minimumSwipeDistance && (_endTime - _startTime) <= _maximumSwipeTime)
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.red, 1f);
            Vector2 direction = _endPosition - _startPosition;
            SwipeDirection(direction.normalized);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
        {
            Debug.Log("up");
        }
    }
}
