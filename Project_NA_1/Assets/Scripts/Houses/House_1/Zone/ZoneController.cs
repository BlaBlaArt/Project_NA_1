using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    GameObject player;
    public GameObject House_1Door;

    public void PlayerOnEvent()
    {
        Debug.Log("EventZone");

        player = GameObject.FindGameObjectWithTag("Player");
        House_1Door = Player.PointEventObject;


        player.transform.position = (House_1Door.transform.position);

        Player.PointEventObject = null; 

        Destroy(this.gameObject);
    }
}
