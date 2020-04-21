using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int Health = 100;
    }

    public PlayerStats playerStats = new PlayerStats();

    public float speed;
    private Rigidbody2D rigidBody2DComponent;

    private int fallBoundary = -10;

    void Start()
    {
        rigidBody2DComponent = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Kill the player if they fall of the ledge
        if(transform.position.y <= fallBoundary)
        {
            GameMaster.KillPlayer(this);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rigidBody2DComponent.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidBody2DComponent.velocity = Vector2.up * jumpVelocity;
        }
    }    
}
