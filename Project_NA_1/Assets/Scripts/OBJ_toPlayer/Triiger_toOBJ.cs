using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triiger_toOBJ : MonoBehaviour
{
    public bool onPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onPlayer = true;
        }
    }
}
