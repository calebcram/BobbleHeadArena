using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            openPanel("MainMenu");
        }
    }
    public GameObject[] menuPanels;

    public void openPanel(string panelName)
    {
        foreach(GameObject go in menuPanels)
        {
            if(go.name == panelName)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
    public void resumeGame()
    {
        openPanel("");
        Time.timeScale = 1;
    }
}
