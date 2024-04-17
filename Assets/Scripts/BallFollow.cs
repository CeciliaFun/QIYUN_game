using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollow : MonoBehaviour
{
    public RectTransform ball;
    public Transform up;
    public Transform down;
    public float mul = 10f;

    public void yidong(Vector2 movent)
    {
        var oldPosition = ball.position;
        var newX = oldPosition.x + movent.x * mul;
        var newY = Mathf.Clamp(oldPosition.y + movent.y * mul, down.position.y, up.position.y);

        var newPosition = new Vector3(newX, newY, 0);
        ball.position = newPosition;
    }
}