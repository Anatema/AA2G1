using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField]
    private int _healAmount;
    [SerializeField]
    private float _refreshTimer;
    private void OnTriggerEnter(Collider other)
    {
        HealthController health = other.GetComponent<HealthController>();
        if (health)
        {
            if (health.Heal(_healAmount))
            {
                gameObject.SetActive(false);
                ActivateWithDelay(_refreshTimer);
            }
        }
    }
    
    

    private async void ActivateWithDelay(float delay)
    {
        int timeInMilliseconds = (int)(delay * 1000);
        await Task.Delay(timeInMilliseconds);
        gameObject.SetActive(true);
    }
}
