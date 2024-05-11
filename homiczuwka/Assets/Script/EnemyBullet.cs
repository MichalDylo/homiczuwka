using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float deadZoneY = 7f;

    public int enemyType = 0;

    public int angleOffset = 90;
    Quaternion offsetVal;
    // Start is called before the first frame update
    void Start()
    {
        offsetVal = Quaternion.Euler(0, 0, Random.Range(-1 * angleOffset, angleOffset));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        pos += transform.rotation * (offsetVal * velocity) * enemyType * (-1);
        transform.position = pos;

        if (transform.position.y < -deadZoneY || transform.position.y > deadZoneY)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hunter")
        {
            int playerType = collision.gameObject.GetComponent<Player>().playerType;
            collision.gameObject.GetComponent<PlayerShooting>().sliderUI.HunterIsHit(playerType);

            Destroy(gameObject);
        }
    }
}
