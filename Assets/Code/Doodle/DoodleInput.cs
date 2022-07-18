using System;
using UnityEngine;

public class DoodleInput : MonoBehaviour
{
    const float _inputInvertModify = -1f;

    [SerializeField] private Camera _camera;
    [SerializeField] [Range(1, 10)] private float _movementSpeed = 2f;

    public event Action<Vector3> PositionChanged;

    private Vector3 _tapPosition;

    private void OnValidate()
    {
        if (_camera == null)
            _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 position = _camera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, 0, 0));

        if (Input.GetMouseButtonDown(0))
            _tapPosition = position;
        if (Input.GetMouseButton(0))
            PositionChanged?.Invoke((_tapPosition - position) * _inputInvertModify * _movementSpeed * Time.deltaTime);
    }
}
