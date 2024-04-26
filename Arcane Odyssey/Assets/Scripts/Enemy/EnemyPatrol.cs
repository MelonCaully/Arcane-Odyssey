using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

     [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    void Awake()
    {
        initScale = enemy.localScale;
    }

    void Update()
    {
        
        if (movingLeft) //Moves character left until it reaches the edge
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            } else {
                DirectionChange();
            }
        } 
        else //Moves character right until it reaches the edge
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            } else {
                DirectionChange();
            }
        }
    }

    void MoveInDirection(int _direction)
    {
        //Rotate Enemy to face moving direction.
        if (_direction > 0)
        {
            enemy.rotation = Quaternion.Euler(0, 0, 0); // Facing right
        }
        else if (_direction < 0)
        {
            enemy.rotation = Quaternion.Euler(0, 180, 0); // Facing left
        }

        // Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, 
            enemy.position.y, enemy.position.z);
    }

    void DirectionChange()
    {
        movingLeft = !movingLeft;
    }
}
