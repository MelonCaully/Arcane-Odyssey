using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool isMovingLeft;
    private float leftEdge;
    private float rightEdge;
    // Start is called before the first frame update
    void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else 
                isMovingLeft = false;
        } 
        else 
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            } else 
                isMovingLeft = true;
        }
    }
}
