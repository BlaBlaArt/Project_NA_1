using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Script : MonoBehaviour
{
    public bool AttackZone;
    public bool MoveZone;
    public bool CanAttack;

    GameObject player;

    public float Speed = 0;
    public float Impulsespeed = 0;

    Rigidbody2D rb;

    public GameObject EXPstar;
    public GameObject Money;

    public GameObject BulletPref;

    public float BulletTimeSpawn;
    public float BulletSpeed;
    public int BulletDammage;

    int hp;
    int _health
    {
        set
        {
            hp = value;
            if (hp <= 0)
            {
                GetDestroy(Random.Range(0, 4), Random.Range(0, 10));
            }
        }
        get
        {
            return hp;
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _health = 30;
        CanAttack = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Attack();

    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Attack()
    {
        if (AttackZone)
        {
            if (CanAttack)
                StartCoroutine("AttackBullet");
        }
    }

    IEnumerator AttackBullet()
    {
        
        CanAttack = false;
        
        GameObject tmpBullet = Instantiate<GameObject>(BulletPref);
        tmpBullet.transform.position = transform.position;
        tmpBullet.GetComponent<BulletScript>().Speed = BulletSpeed;
        tmpBullet.GetComponent<BulletScript>().Dammage = BulletDammage;

        yield return new WaitForSeconds(BulletTimeSpawn);
        Destroy(tmpBullet.gameObject);
        CanAttack = true;

    }

    private void Move()
    {
        if (MoveZone)
        { 
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * -Speed;

        }
        else
        {
            rb.velocity = new Vector2(player.transform.position.x - transform.position.x + Random.Range(-5,0), player.transform.position.y - transform.position.y + Random.Range(-5, 0)) * Speed;
        }
    }

    private void TakeDammage()
    {

    }

    void GetDestroy(int count_star, int count_money)
    {

        for (int i = 0; i <= count_money; i++)
        {
            float range_x = Random.Range(-5.5f, 5.5f);
            float range_y = Random.Range(-5.5f, 5.5f);
            GameObject tmpMoney = Instantiate(Money);
            tmpMoney.transform.position = new Vector3(transform.position.x + range_x, transform.position.y + range_y, transform.position.z);
        }

        for (int i = 0; i <= count_star; i++)
        {
            float range_x = Random.Range(-5.5f, 5.5f);
            float range_y = Random.Range(-5.5f, 5.5f);
            GameObject tmpStar = Instantiate(EXPstar);
            tmpStar.transform.position = new Vector3(transform.position.x + range_x, transform.position.y + range_y, transform.position.z);
        }

        Destroy(this.gameObject);
    }

}
