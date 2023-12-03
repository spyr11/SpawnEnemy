using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private AttackPoint _target;
    [SerializeField] private float _maxTargetDistance;

    private float _waitSeconds = 1f;

    private void Awake()
    {
        _target = Instantiate(_target, newPosition(), Quaternion.identity);
    }

    private void OnEnable()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity).SetProperty(_target, GetColor());

        Invoke(nameof(Deactivate), _waitSeconds);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private Vector3 newPosition()
    {
        float newX = transform.position.x + Random.Range(-_maxTargetDistance, _maxTargetDistance);
        float newZ = transform.position.z + Random.Range(-_maxTargetDistance, _maxTargetDistance);

        return new Vector3(newX, Quaternion.identity.y, newZ);
    }

    private Color GetColor()
    {
        return GetComponent<MeshRenderer>().materials[0].color;
    }
}