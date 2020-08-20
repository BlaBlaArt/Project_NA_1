using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject textHp;
    int hp;
    public int Health
    {
        set
        {
            hp = value;
            if (hp >= 100)
                hp = 100;
            if(hp <= 0)
            {
                Death();
            }
            else
            {
                string HP = hp.ToString();
                textHp.GetComponent<Text>().text = (HP);
            }
        }
        get
        {
            return hp;
        }
    }
    public GameObject textHollyPower;
    int holPow;
    public int HollyPower
    {
        set
        {
            holPow = value;
            if(holPow <= 0)
            {
                holPow = 0;
                Debug.Log("no holly power, its time to pray");
                string HP = holPow.ToString();
                textHollyPower.GetComponent<Text>().text = (HP);
            }
            if (holPow >= 100)
            {
                holPow = 100;
                Debug.Log("преисполнился");
                StopCoroutine("HollyPowercontrol");
                string HP = holPow.ToString();
                textHollyPower.GetComponent<Text>().text = (HP);
            }
            else
            {
                string HP = holPow.ToString();
                textHollyPower.GetComponent<Text>().text = (HP);
            }
        }
        get
        {
            return holPow;
        }
    }
    [SerializeField] float prayTime = 1; 

    Rigidbody2D rb;
    public float Speed = 10f;
    [SerializeField] float axs;
    [SerializeField] bool moveCheck = false;
    public float AxisToRotate
    {
        set
        {
            axs = value;
   
        }

        get
        {
            return axs;
        }
    }
    public GameObject AttackWave;
    public GameObject AttackClassic;
    public GameObject AttackPointSpawn;
    public float Attack_speedWave;
    public float Attack_timeLiveAttackWave;
    public float Attack_timeLiveAttackClassic;
    public float Attack_timeAttackWave;
    public float Attack_timeAttackClassic;
    public bool CanAttackWave = true;
    public bool CanAttackClassic = true;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Health = 100;
        HollyPower = 100;
    }

    private void Update()
    {
        MoveCheck();
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
        if (!moveCheck)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void Move()
    {
        if (moveCheck)
        {
            MoveHorizontal();

            MoveVertical();
        }
    }

    public bool MoveCheck()
    {
        if(Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            moveCheck = true;
        }
        else if(!Input.GetButton("Vertical") && !Input.GetButton("Horizontal"))
        {
            moveCheck = false;
            //rb.velocity = new Vector2(0, 0);
        }

        return moveCheck;
    }

    public void MoveVertical()
    {
        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Flip("up");
                rb.velocity = new Vector2(0, 1) * Speed;

            }

            if (Input.GetAxis("Vertical") < 0)
            {
                Flip("down");

                rb.velocity = new Vector2(0, -1) * Speed;

            }

            if (Input.GetButton("Horizontal"))
            {
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
                {
                    Flip("upright");

                    rb.velocity = new Vector2(1, 1) * Speed;
                }

                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
                {
                    Flip("downright");

                    rb.velocity = new Vector2(1, -1) * Speed;

                }

                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
                {
                    Flip("upleft");

                    rb.velocity = new Vector2(-1, 1) * Speed;

                }

                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
                {
                    Flip("downleft");

                    rb.velocity = new Vector2(-1, -1) * Speed;

                }

            }
        }
    }

    public void MoveHorizontal()
    {

        if (Input.GetButton("Horizontal"))
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                Flip("right");
                rb.velocity = new Vector2(1, 0) * Speed;
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                Flip("left");
                rb.velocity = new Vector2(-1, 0) * Speed;

            }
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0)
                {
                    Flip("upright");

                    rb.velocity = new Vector2(1, 1) * Speed;
                }

                if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") < 0)
                {
                    Flip("downright");

                    rb.velocity = new Vector2(1, -1) * Speed;

                }

                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0)
                {
                    Flip("upleft");

                    rb.velocity = new Vector2(-1, 1) * Speed;

                }

                if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") < 0)
                {
                    Flip("downleft");

                    rb.velocity = new Vector2(-1, -1) * Speed;

                }
            }
        }

    }

    void Flip(string str)
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (str == "up")
        {
            AxisToRotate = 90;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if(str == "down")
        {
            AxisToRotate = -90;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "left")
        {
            AxisToRotate = 180;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "right")
        {
            AxisToRotate = 0;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "upright")
        {
            AxisToRotate = 45;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "upleft")
        {
            AxisToRotate = 135;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "downleft")
        {
            AxisToRotate = -135;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
        if (str == "downright")
        {
            AxisToRotate = -45;
            transform.rotation = Quaternion.AngleAxis(AxisToRotate, new Vector3(0, 0, 1));
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire1") && CanAttackClassic)
        {
            StartCoroutine("Attack_Classic");
            StartCoroutine("AttackClassicTime");
        }

        if (Input.GetButtonDown("Fire2") && CanAttackWave && HollyPower >= 10)
        {
            StartCoroutine("Attack_Wave");
            StartCoroutine("AttackWaveTime");
            HollyPower -= 10;
        }
    }

    IEnumerator AttackClassicTime()
    {
        CanAttackClassic = false;
        yield return new WaitForSeconds(Attack_timeAttackClassic);
        CanAttackClassic = true;
    }

    IEnumerator AttackWaveTime()
    {
        CanAttackWave = false;
        yield return new WaitForSeconds(Attack_timeAttackWave);
        CanAttackWave = true;
    }

    IEnumerator Attack_Wave()
    {

        GameObject tmpAttackWave = Instantiate<GameObject>(AttackWave);
        tmpAttackWave.transform.position = AttackPointSpawn.transform.position;
        tmpAttackWave.transform.rotation = transform.rotation;
        tmpAttackWave.GetComponent<Attack_wave>().Speed = Attack_speedWave;
        StartCoroutine("DestroyAttackWave", tmpAttackWave);

        yield return null;
    }

    IEnumerator Attack_Classic()
    {

        GameObject tmpAttackClassic = Instantiate<GameObject>(AttackClassic);
        tmpAttackClassic.transform.position = transform.position;
        tmpAttackClassic.transform.rotation = transform.rotation;
        StartCoroutine("DestroyAttackClassic", tmpAttackClassic);

        yield return null;
    }

    IEnumerator DestroyAttackWave(GameObject attack)
    {
        yield return new WaitForSeconds(Attack_timeLiveAttackWave);

        Destroy(attack);
    }

    IEnumerator DestroyAttackClassic(GameObject attack)
    {
        yield return new WaitForSeconds(Attack_timeLiveAttackClassic);

        Destroy(attack);
    }

    void Death()
    {

    }

    IEnumerator HollyPowercontrol()
    {
        yield return new WaitForSeconds(prayTime);
        HollyPower++;
        yield return new WaitForSeconds(prayTime);
    }

    public void TakeDammage(int dam)
    {
        Health -= dam;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PrayZone"))
        {
            StartCoroutine("HollyPowercontrol");
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("PrayZone"))
        {
            StopCoroutine("HollyPowercontrol");
        }
    }
}
