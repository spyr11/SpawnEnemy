using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    private SpawnPoint[] _points;
    private float _waitSeconds;

    private void Awake()
    {
        _points = new SpawnPoint[transform.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i).GetComponent<SpawnPoint>();
        }      
    }

    private void Start()
    {
        _waitSeconds = 2.0f;

        InvokeRepeating(nameof(SetRandomPoint), 0, _waitSeconds);
    }

    private void SetRandomPoint()
    {
        int index = Random.Range(0, _points.Length);
        
        _points[index].gameObject.SetActive(true);
    }
}