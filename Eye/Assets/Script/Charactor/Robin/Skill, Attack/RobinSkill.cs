using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobinSkill : MonoBehaviour
{
    public float speed = 10f;
    public float verticalSpeed = 5f;
    public Rigidbody2D rb; 
    public Transform monster;

    void Start()
    {
        Vector2 direction = (monster.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, monster.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.velocity = new Vector2(speed * Mathf.Cos(angle * Mathf.Deg2Rad), speed * Mathf.Sin(angle * Mathf.Deg2Rad) + verticalSpeed);
        rb.gravityScale = distance / 10f;
    }

    void Update()
    {
    
    }
}
