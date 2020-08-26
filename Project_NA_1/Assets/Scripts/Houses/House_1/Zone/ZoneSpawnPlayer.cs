using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneSpawnPlayer : MonoBehaviour
{
    public Transform zonePos;

    private void Awake()
    {
        zonePos = transform;
    }

}
