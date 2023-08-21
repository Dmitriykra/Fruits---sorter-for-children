using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSound : MonoBehaviour
{
    AudioSource mainMenuSound;
    GameObject[] menuMusic;
    // Start is called before the first frame update

    void Start()
    {
        
        menuMusic = GameObject.FindGameObjectsWithTag("menumusic");
        mainMenuSound = GetComponent<AudioSource>();
        
    
    }

    void Update() {
        {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(currentSceneIndex);

        Debug.Log("My GO: "+menuMusic.Length);
        if(menuMusic.Length>1)
        {
            Destroy(this.gameObject);
        }

        if(!mainMenuSound.isPlaying){mainMenuSound.Play();}

        
        if(currentSceneIndex>1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        }
    }
}
