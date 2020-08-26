using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_1Script : MonoBehaviour
{
 
    GameObject player;

    public GameObject MyZonePref;


    public void PlayerOnEvent()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Player.PointEventObject = this.gameObject;

        GameObject tmpZone = Instantiate<GameObject>(MyZonePref);
        player.transform.position = (tmpZone.GetComponentInChildren<ZoneSpawnPlayer>().zonePos.position);
    }

}
