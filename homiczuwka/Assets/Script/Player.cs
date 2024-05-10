using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    private float speedX, speedY;
    private Rigidbody2D rb;
    enum PlayerType
    { 
        demonHunter = -1,
        angelHunter = 1
    }

    public int playerType = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerType == (int)PlayerType.demonHunter)
        {
            speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
            speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
            rb.velocity = new Vector2(speedX, 0);
        }
        else if (playerType == (int)PlayerType.angelHunter)
        {
            speedX = Input.GetAxisRaw("Horizontal2") * moveSpeed;
            speedY = Input.GetAxisRaw("Vertical") * moveSpeed;
            rb.velocity = new Vector2(speedX, 0);
        }
    }
}
