using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "Bullet", order = 1)]
public class Bullet : ScriptableObject
{
    public GameObject _prefab;
    public float _shootRate;
}
