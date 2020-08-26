using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1Script : MonoBehaviour
{

    GameObject player;
    GameObject GameManager;

    public float Speed = 0;
    float speed_X;
    float speed_Y;
    public float MaxSpeed = 5;
    public float MinSpeed = -5;
    float spd;
    float currentSpeed
    {
        set
        {
            spd = value;
            if (spd >= MaxSpeed)
                spd = MaxSpeed;
            if (spd <= MinSpeed)
                spd = MinSpeed;
        }
        get
        {
            return spd;
        }
    }

    public float Impulsespeed = 0;

    Rigidbody2D rb;

    public float TimeRandom_move = 3f;
    public float TimeImulseAttack = 1f;

    bool _goToPlayer = true;

    public GameObject EXPstar;
    public GameObject Money;

    Quaternion rotation;

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
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        _health = 50;
        // rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        GameManager.GetComponent<GameManagerScript>().EventsOnChangePlayerPos.Add(_goToPlayer);
    }

    private void FixedUpdate()
    {
        if (_goToPlayer)
        {
            // transform.LookAt(player.transform, Vector3.left);
            rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

            currentSpeed = (player.transform.position.x - transform.position.x) * Speed;
            speed_X = currentSpeed;
            currentSpeed = (player.transform.position.y - transform.position.y) * Speed;
            speed_Y = currentSpeed;

         //   rb.AddForce( new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y) * Speed);
            rb.velocity = new Vector2(speed_X, speed_Y);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {

            _goToPlayer = false;
            Debug.Log("stop move");
            StartCoroutine("RandomMove");
        }

    }

    IEnumerator RandomMove()
    {
        Debug.Log("start random move");


        rb.velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)) * Speed;
        yield return new WaitForSeconds(TimeRandom_move);
        StopCoroutine("RandomMove");
        _goToPlayer = true;
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

    public void TakeDamage(int damage, GameObject whoDammage)
    {
        _health -= damage;
        _goToPlayer = false;
        StartCoroutine("ImpulseAttack", whoDammage);
    }

    IEnumerator ImpulseAttack(GameObject impulseTaker)
    {
        rb.velocity = new Vector2(impulseTaker.transform.position.x + transform.position.x, impulseTaker.transform.position.y + transform.position.y) * Impulsespeed;
        yield return new WaitForSeconds(TimeImulseAttack);
        _goToPlayer = true;
        StopCoroutine("ImpulseAttack");
    }
}
