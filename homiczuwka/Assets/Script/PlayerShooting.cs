using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Bullet bulletPrefab;
    [SerializeField] private float fireDelay = 0.25f;
    private float cooldownTimer = 0f;
    [SerializeField] private KeyCode fireKey = KeyCode.Space;

    
    // Start is called before the first frame update
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(fireKey) && cooldownTimer <= 0f)
        {
            Debug.Log("Shoot!");
            cooldownTimer = fireDelay;

            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.bulletShooter = this.GetComponent<Player>().playerType;
        }
    }
}
