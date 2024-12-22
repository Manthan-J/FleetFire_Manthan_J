using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject Healthbar;
    public GameObject Crosshair;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused=false;
        PauseMenuCanvas.SetActive(false);
        Healthbar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        isPaused=true;
        PauseMenuCanvas.SetActive(true);
        Healthbar.SetActive(false);
        Crosshair.SetActive(false);
        Time.timeScale=0f;
    }
    public void Resume()
    {
        isPaused=false;
        PauseMenuCanvas.SetActive(false);
        Healthbar.SetActive(true);
        Crosshair.SetActive(true);
        Time.timeScale=1f;
    }
    public void restart()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Pressed restart buttuon");
    }
    public void MainMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Pressed mainmenu button");
    }
}