using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_1 : MonoBehaviour
{
    public GameObject EXPstar;
    public GameObject Money;

    int hp;
    int _health
    {
        set
        {
            hp = value;
            if(hp <= 0)
            {
                GetDestroy(Random.Range(0,4), Random.Range(0,10));
            }
        }
        get
        {
            return hp;
        }
    }

    private void Start()
    {
        _health = 20;
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

        for(int i = 0; i <= count_star; i++)
        {
            float range_x = Random.Range(-5.5f, 5.5f);
            float range_y = Random.Range(-5.5f, 5.5f);
            GameObject tmpStar = Instantiate(EXPstar);
            tmpStar.transform.position = new Vector3(transform.position.x + range_x, transform.position.y + range_y, transform.position.z);
        }

        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
