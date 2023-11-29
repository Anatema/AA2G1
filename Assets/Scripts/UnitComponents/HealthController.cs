using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private int _currentHealth = 0;
    public int Health => _currentHealth;
    [SerializeField]
    private int _maxHealth = 10;
    public int MaxHealth => _maxHealth;

    [SerializeField]
    private float _invulFrame = 1f;
    [SerializeField]
    private float _invulCountdown = 0;
    private bool _canTakeDamage = true;

    private Unit _unit;
    public Unit Owner => _unit;

    private int _minimalDamage = 1;
    public void Initialize(Unit unit)
    {
        _unit = unit;
    }
    public void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(int damage, int defence, Unit owner)
    {
        if (owner.Side == _unit.Side)
        {
            return;
        }

        if(!_canTakeDamage)
        {
            Debug.Log($"invul frame from {owner.name} to {this.name}");
            return;
        }

        _invulCountdown = _invulFrame;
        _canTakeDamage = false;

        int damageValue = damage - defence;
        damageValue = Mathf.Clamp(damageValue, _minimalDamage, damageValue);
        _currentHealth -= damageValue;

        Debug.Log($"{owner.name} dealed {damageValue} damage to {this.name}");
        _unit.OnUnitHealthChanged.Invoke(_unit, (float)_currentHealth / (float)_maxHealth);
        if (_currentHealth <= 0)
        {
            Death();
        }
    }
    public void Update()
    {
        if (!_canTakeDamage) 
        {
            _invulCountdown -= Time.deltaTime;
            if(_invulCountdown < 0)
            {
                _canTakeDamage = true;
            }
        }
    }
    public bool Heal(int healAmount)
    {
        if(_currentHealth > _maxHealth)
        {
            return false;
        }
        _currentHealth += healAmount;
        _unit.OnUnitHealthChanged.Invoke(_unit, (float)_currentHealth / (float)_maxHealth);
        return true;
    }
    private void Death()
    {
        _unit?.Death();
    }
}
