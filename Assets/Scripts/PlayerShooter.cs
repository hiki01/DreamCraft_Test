using System;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float _shootForce = 10f;
    
    [Header("Object Refs")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject[] _projectilePrefabs;

    private GameObject _projectile;
    private Camera _mainCamera;
    private Bullets _bullet;
    private Vector3 _worldMousePosition;
    private Plane _groundPlane;
    
    private enum Bullets
    {
        Bullet1, 
        Bullet2, 
        Bullet3 
    }

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

        if (Input.GetButtonDown("Fire2")) // Change Weapon type
        {
            var currentBullet = (int)_bullet;

            // Calculate the index of the next enum value, wrapping around if needed
            var nextBullet = (currentBullet + 1) % System.Enum.GetValues(typeof(Bullets)).Length;

            // Update the currentState with the next enum value
            _bullet = (Bullets)nextBullet;
        }
        
        if (Input.GetButtonDown("Fire1")) // Shoot
        {
            Shoot(_bullet);
        }
    }

    private void Shoot(Bullets bullet)
    {
        _projectile = bullet switch
        {
            Bullets.Bullet1 => _projectilePrefabs[0],
            Bullets.Bullet2 => _projectilePrefabs[1],
            Bullets.Bullet3 => _projectilePrefabs[2],
            _ => _projectile
        };
        
        var newProjectile = Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
        
        var rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(_shootPoint.forward * _shootForce, ForceMode.Impulse);
        }
        
        Destroy(newProjectile, 5f); // Clean up shooted bullets
    }
}
