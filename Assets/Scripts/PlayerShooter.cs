using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Customize the input as needed
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newProjectile = Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);
        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(_shootPoint.forward * _shootForce, ForceMode.Impulse);
        }
    }
}
