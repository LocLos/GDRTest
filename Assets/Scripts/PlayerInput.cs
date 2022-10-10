using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour, IPointerDownHandler
{
    Camera _camera;

    public void Start() =>
        _camera = Camera.main;

    private Vector3 _touchPos;

    public Vector2 TargetPos => _touchPos;
    public bool IsTouchScreen => Input.touchCount > 0 || Input.GetMouseButtonDown(0);

    public void OnPointerDown(PointerEventData eventData) => 
        _touchPos = _camera.ScreenToWorldPoint(eventData.position);
}

