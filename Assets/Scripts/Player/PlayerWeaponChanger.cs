using System;
using UnityEngine;

public class PlayerWeaponChanger : MonoBehaviour
{
    [SerializeField] private Bullet[] _projectiles;

    private Bullets _bullet;
    private GameObject _projectile;
    private float _rate;

    private enum Bullets
    {
        Bullet1, 
        Bullet2, 
        Bullet3 
    }

    #region Properties

    public GameObject Projectile
    {
        get => _projectile;
        set => _projectile = value;
    }

    public float Rate
    {
        get => _rate;
        set => _rate = value;
    }

    #endregion
    
    private void Update()
    {
        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (Input.GetButtonDown("Fire2")) // Change Weapon type
        {
            var currentBullet = (int)_bullet;

            // Calculate the index of the next enum value, wrapping around if needed
            var nextBullet = (currentBullet + 1) % System.Enum.GetValues(typeof(Bullets)).Length;

            // Update the currentState with the next enum value
            _bullet = (Bullets)nextBullet;
        }

        switch (_bullet)
        {
            case Bullets.Bullet1:
                _projectile = _projectiles[0]._prefab;
                _rate = _projectiles[0]._shootRate;
                break;
            case Bullets.Bullet2:
                _projectile = _projectiles[1]._prefab;
                _rate = _projectiles[1]._shootRate;
                break;
            case Bullets.Bullet3:
                _projectile = _projectiles[2]._prefab;
                _rate = _projectiles[2]._shootRate;
                break;
        }
    }
}
