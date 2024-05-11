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
    private float shootCD = 0;
    [SerializeField] private float deadZoneY = 7.5f;

    public EnemyBullet enemyBullet;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool rigidbodySet = false;

    // Update is called once per frame
    void Update()
    {
        if (timeIns <= 3)
        {
            timeIns += Time.deltaTime;
            if (timeIns >= 0.3f && rigidbodySet == false)
            {
                this.GetComponent<Rigidbody2D>().simulated = true;
                rigidbodySet = true;
            }
        }
        else
        {
            EnemyMovement();
        }
        if (shootCD <= 0.8f)
        {
            shootCD += Time.deltaTime;
        }
        else
        {
            EnemyAttack();
            shootCD = 0;
        }

        if (transform.position.y < -deadZoneY || transform.position.y > deadZoneY)
        {
            Destroy(gameObject);
        }
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
        else if (collision.gameObject.tag == "Hunter")
        {
            int playerType = collision.gameObject.GetComponent<Player>().playerType;
            if (EnemyType != playerType)
            {
                collision.gameObject.GetComponent<PlayerShooting>().sliderUI.HunterIsHit(playerType);
                Destroy(gameObject);
            }
        }
    }

    void EnemyAttack()
    {
        EnemyBullet enemyBulletIns = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        enemyBulletIns.enemyType = EnemyType;
    }
}
