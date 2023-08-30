using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnRate;
    [SerializeField] private int _spawnBigAfterWaves;

    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private Transform[] _spawnPos;

    private int _enemyCounter;
    private GameObject _currentEnemy;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, _spawnRate);
    }

    private void Spawn()
    {
        if (_enemyCounter == _spawnBigAfterWaves)
        {
            _currentEnemy = _enemy2;
            _enemyCounter = 0;
        }
        else
        {
            _currentEnemy = _enemy1;
            _enemyCounter++;
        }

        var randomPos = Random.Range(0, _spawnPos.Length - 1);
            
        Instantiate(_currentEnemy, _spawnPos[randomPos].position, Quaternion.identity);
    }
}
