using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Classic : MonoBehaviour
{
    public int Damage;

    private void Start()
    {
        Damage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().ClassicAttack_Dammage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneOBJ"))
        {
            collision.GetComponent<Box_1>().TakeDamage(Damage);
        }
    }


}
