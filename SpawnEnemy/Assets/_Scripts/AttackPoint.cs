using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _places;
    private int _currentIndex;

    private void Awake()
    {
        _path = Instantiate(_path, transform.position, Quaternion.identity);
    }

    private void Start()
    {
        _places = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _places[i] = _path.GetChild(i);
        }

        _currentIndex = Random.Range(0, _path.childCount);
    }

    private void Update()
    {   
        Vector3 targetPosition = _places[_currentIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            RiseIndex();
        }
    }

    private void RiseIndex()
    {
        _currentIndex++;

        if (_currentIndex >= _places.Length)
        {
            _currentIndex = 0;
        }
    }
}