using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public GameObject MyZone;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          //  Debug.Log("door_zone");
            Player.EventObject = MyZone;
            Player.PlayerCanEvent = true;
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
