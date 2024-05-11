using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float deadZoneY = 6f;

    public int bulletShooter = 0;
    public HunterSliderUI sliderUI;
    public int playerBulletUpgrade = 0;

    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;

        if (transform.position.y < -deadZoneY || transform.position.y > deadZoneY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Enemy>().EnemyType == (int)ObjectType.EnemyType.angel)
            {
                sliderUI.AngelIsHunted(bulletShooter);
            }
            else if (collision.gameObject.GetComponent<Enemy>().EnemyType == (int)ObjectType.EnemyType.demon)
            {
                sliderUI.DemonIsHunted(bulletShooter);
            }
            else
            {
                Debug.LogAssertion("=======illegal output=======");
            }

            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Hunter" && collision.gameObject.GetComponent<Player>().playerType == (-1) * playerBulletUpgrade)
        {
            collision.gameObject.GetComponent<PlayerShooting>().sliderUI.HunterIsHit(-1 * playerBulletUpgrade);
        }
    }
}
