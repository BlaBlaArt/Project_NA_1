using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_toPlayerScript : MonoBehaviour
{

    public GameObject Player;
    public float speed;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (GetComponentInChildren<Triiger_toOBJ>().onPlayer)
        {
            rb.velocity = new Vector2(Player.transform.position.x - transform.position.x, Player.transform.position.y - transform.position.y);
        }

    }

}
