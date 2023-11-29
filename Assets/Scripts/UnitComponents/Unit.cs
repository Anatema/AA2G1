using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Movement))]
[RequireComponent (typeof(HealthController))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private byte _side;
    public byte Side => _side;

    private Movement _movement;
    private HealthController _health;

    public UnityEvent<Unit> OnUnitDestroyed = new UnityEvent<Unit>();
    public UnityEvent<Unit, float> OnUnitHealthChanged = new UnityEvent<Unit, float>();

    public void Awake()
    {
        _movement = GetComponent<Movement>();

        _health = GetComponent<HealthController>();
        _health.Initialize(this);
    }
    public void Move(Vector2 direction)
    {
        _movement.Move(direction);
    }

    public void Death()
    {
        OnUnitDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
    

}
