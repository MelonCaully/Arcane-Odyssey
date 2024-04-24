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

    void Awake()
    {
        initScale = enemy.localScale;
    }

    void Update()
    {
        MoveInDirection(1);
    }

    void MoveInDirection(int _direction)
    {
        // Move enemy in facing direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, 
            initScale.y, initScale.z);

        // Rotate enemy to face the direction
        if (_direction > 0)
        {
           enemy.localRotation = Quaternion.Euler(0, 0, 0); // Face right
        }
        else if (_direction < 0)
        {
           enemy.localRotation = Quaternion.Euler(0, 180, 0); // Face left
        }

        // Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime *_direction * speed, 
            enemy.position.y, enemy.position.z);
    }
}
