using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private Unit _owner;
    public void OnTriggerEnter(Collider other)
    {
        HealthTrigger health = other.GetComponent<HealthTrigger>();

        if(health)
        {
            health.TakeDamage(_damage, _owner);
        }
    }
}

