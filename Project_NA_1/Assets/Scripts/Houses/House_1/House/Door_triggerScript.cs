using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_triggerScript : MonoBehaviour
{


    public GameObject MyHouse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.EventObject = MyHouse;
            Player.PlayerCanEvent = true;
          //  Debug.Log(Player.EventObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.EventObject = null;
            Player.PlayerCanEvent = false;

        }
    }
}
