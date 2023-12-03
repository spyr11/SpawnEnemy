using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Transform _target;
    private bool _isMoving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isMoving = true;
    }

    private void Update()
    {
        transform.LookAt(_target.position);

        if (_isMoving)
        {
            _rigidbody.velocity = transform.forward * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _target.GetComponent<Collider>())
        {
            _rigidbody.velocity = Vector3.zero;
            _isMoving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == _target.GetComponent<Collider>())
        {
            _isMoving = true;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }    
}