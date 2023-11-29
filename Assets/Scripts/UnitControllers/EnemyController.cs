using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class EnemyController : MonoBehaviour
{
    private Unit _unit;
    [SerializeField]
    private Unit _tager;

    public void Awake()
    {
        _unit = GetComponent<Unit>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_tager)
        {
            return;
        }
        float _rotation = Vector3.SignedAngle(_tager.transform.position - transform.position, transform.forward, transform.up)/10;
        
        _rotation = Mathf.Clamp(_rotation, -1, 1);
        Vector2 direction = new Vector2(1, -_rotation);

        _unit.Move(direction);
    }
}
