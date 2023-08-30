using System;
using UnityEngine;

public class EnemyLookAt : MonoBehaviour
{
    private Transform _player;
    
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.LookAt(_player);
    }
}
