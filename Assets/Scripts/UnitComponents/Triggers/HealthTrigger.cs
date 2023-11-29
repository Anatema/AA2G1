using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTrigger : MonoBehaviour
{
    [SerializeField]
    private HealthController _healthController;
    [SerializeField]
    private int _defence;
    
    public void TakeDamage(int damage, Unit owner)
    {
        _healthController.TakeDamage(damage, _defence, owner);
    }
}
