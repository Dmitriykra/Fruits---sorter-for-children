using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
         SceneManager.LoadScene("Level 0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnBackPressedMainMenu() 
    {
        Invoke("OnMouseDown", 0.5f);
        
    }

    public void OnMouseDown() {
    
        Debug.Log("Log");
        SceneManager.LoadScene("MainMenu");
    }
    public void OnBackPressed() 
    {
        Invoke("LoadMenu", 0.5f);
        
    }
    void LoadMenu()
    {
        SceneManager.LoadScene("Level 0");
    }
}

