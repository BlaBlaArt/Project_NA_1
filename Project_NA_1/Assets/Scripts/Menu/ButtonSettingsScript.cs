using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettingsScript : MonoBehaviour
{
    GameObject QuestCanvas;
  //  GameObject MenuCanvas;

    private void Start()
    {
        QuestCanvas = GameObject.FindGameObjectWithTag("QuestCanvas");
    //    MenuCanvas = GameObject.FindGameObjectWithTag("MenuCanvas");
    }

    public void ShowQuestCanvas()
    {
        QuestCanvas.GetComponent<Canvas>().enabled = true;
     //   MenuCanvas.GetComponent<Canvas>().enabled = false;
    }

    public void BackToMenu()
    {
        QuestCanvas.GetComponent<Canvas>().enabled = false;
     //   MenuCanvas.GetComponent<Canvas>().enabled = true;
    }

}
