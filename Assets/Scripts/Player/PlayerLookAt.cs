using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 _worldMousePosition;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        var plane = new Plane(Vector3.up, 0);
        
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out var distance))
        {
            _worldMousePosition = ray.GetPoint(distance);
            transform.LookAt(_worldMousePosition + Vector3.one);
        }
    }
}
