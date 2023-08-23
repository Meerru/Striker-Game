using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private GameObject player;
    private float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveSpeed = 2f;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveEnemy();
    }

    // Method to move enemy
    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y * moveSpeed);
    }

    private void LateUpdate()
    {
        if(enemyRb.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if(enemyRb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }
}
