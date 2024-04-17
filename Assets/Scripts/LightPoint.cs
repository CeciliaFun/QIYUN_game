using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour
{
    public Transform LP;
    public Transform up ;
    public Transform down /*= GameObject.Find("BorderDown").transform.position*/;

    private void Start()
    {
        //Debug.Log("down" + down.position.y + "up" + up.position.y);
    }

    private void FixedUpdate()
    {
        //LP.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        float positionX = LP.position.x;
        float positionY = LP.position.y;
        var newPosition = Vector2.zero;

        positionY = Mathf.Clamp(positionY, down.position.y, up.position.y);
       // Debug.Log("positionY" + positionY);

        newPosition.x = LP.position.x;
        //Debug.Log("newPosition" + newPosition);
        newPosition.y = positionY;
        LP.position = newPosition;        
    }
}
