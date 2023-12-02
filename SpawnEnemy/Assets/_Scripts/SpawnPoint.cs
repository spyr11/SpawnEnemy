using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Movement _enemy;
    [SerializeField] private AttackPoint _attackPoint;
    [SerializeField] private float _maxRespawnDistance;

    private float _waitSeconds = 1f;

    private void OnEnable()
    {
        _attackPoint = Instantiate(_attackPoint, newPosition(), Quaternion.identity);

        if (_attackPoint != null)
        {
            Instantiate(_enemy, transform.position, Quaternion.identity)
            .GetTarget(_attackPoint);
        }

        Invoke(nameof(Deactivate), _waitSeconds);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private Vector3 newPosition()
    {
        float newX = transform.position.x + Random.Range(-_maxRespawnDistance, _maxRespawnDistance);
        float newY = transform.position.y;
        float newZ = transform.position.z + Random.Range(-_maxRespawnDistance, _maxRespawnDistance);

        return new Vector3(newX, Quaternion.identity.y, newZ);
    }
}