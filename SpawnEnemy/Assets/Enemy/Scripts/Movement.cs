using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private AttackPoint _target;
    private bool _isMoving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isMoving = true;
    }

    private void Update()
    {
        Vector3 targetPosition = _target.transform.position;

        transform.LookAt(targetPosition);

        if (_isMoving)
        {
            _rigidbody.velocity = transform.forward * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other==_target.GetComponent<Collider>())
        {
            _isMoving = false;
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other==_target.GetComponent<Collider>())
        {
            _isMoving = true;
        }
    }

    public void GetTarget(AttackPoint target)
    {
        _target = target;
    }
}