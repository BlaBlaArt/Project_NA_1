using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House_1Script : MonoBehaviour
{
 
    GameObject player;
    GameObject GameManager;

    public GameObject MyZonePref;

    private void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void PlayerOnEvent()
    {

      /*  for(int i = 1; i<=GameManager.GetComponent<GameManagerScript>().EventsOnChangePlayerPos.Count; i++)
        {
            Debug.Log(GameManager.GetComponent<GameManagerScript>().EventsOnChangePlayerPos[i]);

         //   GameManager.GetComponent<GameManagerScript>().EventsOnChangePlayerPos[i] = false;
        }*/

        player = GameObject.FindGameObjectWithTag("Player");
        Player.PointEventObject = this.gameObject;

        GameObject tmpZone = Instantiate<GameObject>(MyZonePref);
        player.transform.position = (tmpZone.GetComponentInChildren<ZoneSpawnPlayer>().zonePos.position);
    }

}
