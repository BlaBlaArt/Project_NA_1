using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1Script : MonoBehaviour
{

    GameObject player;

    public float speed = 0;

    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * speed;
    }
}
