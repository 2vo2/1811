using UnityEngine;

public class CarMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void Update()
    {
        _rigidbody.velocity = transform.forward * _speed * Time.deltaTime;
    }
}
