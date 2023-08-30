using System;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float _shootForce = 10f;
    
    
    [Header("Object Refs")]
    [SerializeField] private Transform _shootPoint;
    
    private PlayerWeaponChanger _weaponChanger;
    private float _time;

    private void Awake()
    {
        _weaponChanger = GetComponent<PlayerWeaponChanger>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _time) // Shoot
        {
            Shoot();
            _time += _weaponChanger.Rate; // Limit shoot rate
        }
    }

    private void Shoot()
    {
        var newProjectile = Instantiate(_weaponChanger.Projectile, _shootPoint.position, _shootPoint.rotation);
        
        var rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(_shootPoint.forward * _shootForce, ForceMode.Impulse);
        }
        
        Destroy(newProjectile, 5f); // Clean up shooted bullets
    }
}
