using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeTestQuest : MonoBehaviour
{
    public Image TestQuest;
    public GameObject QuestContent;

    private void Start()
    {
        QuestContent = GameObject.FindGameObjectWithTag("QuestContent");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.PlayerCanEvent = true;
            Player.EventObject = this.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.PlayerCanEvent = false;
            Player.EventObject = null;
        }
    }

    public void PlayerOnEvent()
    {
        Image tmpQuest = Instantiate<Image>(TestQuest);
        tmpQuest.transform.SetParent(QuestContent.transform, true);
    }
}
