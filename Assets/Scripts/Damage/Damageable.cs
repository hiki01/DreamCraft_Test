using System;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private string _damageableFromTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_damageableFromTag))
        {
            _health -= other.GetComponent<DealDamage>().Damage;
        }
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
