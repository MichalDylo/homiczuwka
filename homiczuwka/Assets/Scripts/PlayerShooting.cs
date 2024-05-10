using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float fireDelay = 0.25f;
    private float cooldownTimer = 0f;
    
    // Start is called before the first frame update
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0f)
        {
            Debug.Log("Shoot!");
            cooldownTimer = fireDelay;
        }
    }
}
