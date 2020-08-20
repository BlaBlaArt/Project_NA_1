using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_wave : MonoBehaviour
{
    [SerializeField] GameObject attackpoint, player;
    Vector3 attack;
    Rigidbody2D rb;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        attackpoint = GameObject.FindGameObjectWithTag("Attack_point");
        player = GameObject.FindGameObjectWithTag("Player");      
        rb = GetComponent<Rigidbody2D>();
        attack = attackpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (attack-transform.position) * Speed;
    }


}
