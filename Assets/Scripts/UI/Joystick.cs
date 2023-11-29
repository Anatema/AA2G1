using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    private Vector2 _direction = new Vector3(0, 0);
    public Vector2 Direction => _direction;

    public void TurnLeft()
    {
        _direction.y = -1;
    }
    public void TurnRight()
    {
        _direction.y = 1;
    }

    public void Forward()
    {
        _direction.x = 1;
    }
    public void Backward()
    {
        _direction.x = -1;
    }

    public void ResetSteering()
    {
        _direction.y = 0;
    }
    public void ResetMoving()
    {
        _direction.x = 0;
    }
}
