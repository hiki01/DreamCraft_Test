using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _OffsetToStop = 3f;

    private Transform _player;
    private Vector3 _distance;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        _distance = _player.position - transform.position;
        
        if (Mathf.Abs(_distance.x) < _OffsetToStop && Mathf.Abs(_distance.y) < _OffsetToStop) return;
        
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
    }
}
