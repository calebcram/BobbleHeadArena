using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager2 : MonoBehaviour
{
    public GameObject[] panels;

    public void openPanel(string panelName)
    {
        foreach(GameObject go in panels)
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
        Time.timeScale = 1;
        openPanel("");
    }
    public void quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            openPanel("MainMenu");
        }
        //pause time
        //open main menu when user hits escape
    }
}
