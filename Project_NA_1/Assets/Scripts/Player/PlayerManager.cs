using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public GameObject textEXP;
    float exp;
    public float ExpiriencePoint
    {
        set
        {
            exp = value;
            string EXP = exp.ToString();
            textEXP.GetComponent<Text>().text = (EXP);
        }
        get
        {
            return exp;
        }
    }

    public GameObject textMoney;
    int mon;
    public int Money
    {
        set
        {
            mon = value;
            string MON = mon.ToString();
            textMoney.GetComponent<Text>().text = (MON);
        }
        get
        {
            return mon;
        }
    }


    public int ClassicAttack_Dammage = 10;
    public int WaveAttack_Dammage = 15;

    private void Start()
    {
        ExpiriencePoint = 0;
        Money = 0;
    }
}
