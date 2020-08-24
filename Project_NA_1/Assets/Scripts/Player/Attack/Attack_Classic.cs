using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Classic : MonoBehaviour
{
    public int Damage = 0;

    private void Start()
    {
        if(this.gameObject.name == "ClassicAttack(Clone)")
        {
            Damage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().ClassicAttack_Dammage;
        }
        if (this.gameObject.name == "Classic_attack_1(Clone)")
        {
            Damage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().ClassicAttack_1_Damage;
        }
        if (this.gameObject.name == "Classic_attack_2(Clone)")
        {
            Damage = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>().ClassicAttack_2_Damage;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SceneOBJ"))
        {
            collision.GetComponent<Box_1>().TakeDamage(Damage);
        }

        if (collision.CompareTag("enemy"))
        {
            collision.GetComponent<Enemy_1Script>().TakeDamage(Damage, this.gameObject);
        }
    }


}
