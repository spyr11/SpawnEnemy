using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Movement _movement;
    private AttackPoint _attackPoint;
    private Color _color;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        SetColor();
    }

    private void Update()
    {
        _movement.SetTarget(_attackPoint.transform);
    }

    public void SetProperty(AttackPoint attackPoint, Color color)
    {
        _attackPoint = attackPoint;
        _color = color;
    }

    private void SetColor()
    {
        GetComponentInChildren<Renderer>().material.color = _color;
    }
}
