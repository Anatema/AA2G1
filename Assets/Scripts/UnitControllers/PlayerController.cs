using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class PlayerController : MonoBehaviour
{
    private Unit _unit;

    [SerializeField]
    private Joystick _joystick;

    public void Awake()
    {
        _unit = GetComponent<Unit>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = _joystick.Direction;

#if UNITY_EDITOR
        direction = new Vector2(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
#endif


        _unit.Move(direction);
    }
}
