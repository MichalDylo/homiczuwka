using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5;
    public float turnSpeed = 2;
    private bool touchTheBoundary;
    public int EnemyType = 0;
    private float timeIns = 0;

    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeIns <= 3)
        {
            timeIns += Time.deltaTime;
        }
        else 
        {
            rigidbody2D.simulated = true;
            EnemyMovement();
        }
        EnemyAttack();
    }

    float timeMarker = 0;
    void EnemyMovement()
    {
        if (touchTheBoundary == false)
        {
            timeMarker = 0;
            transform.Translate(Vector2.right * moveSpeed * EnemyType * Time.deltaTime);
        }
        else
        {
            timeMarker += Time.deltaTime;
            transform.Translate(Vector2.down * turnSpeed * EnemyType * Time.deltaTime);
            if (timeMarker >= 0.5f)
            {
                touchTheBoundary = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            touchTheBoundary = true;
            moveSpeed *= -1;
        }
    }

    void EnemyAttack()
    {

    }
}
