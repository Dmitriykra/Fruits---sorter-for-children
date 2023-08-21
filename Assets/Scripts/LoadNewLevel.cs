using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;


public class LoadNewLevel : MonoBehaviour
{
    public InterstitialAdExample interstitialAdsButton;

    public void LoadLevel()
    {
        
        interstitialAdsButton.ShowAd();

        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int correctScene = currentSceneIndex - 1;
        Debug.Log("Loading new scene: "+currentSceneIndex);
            if(currentSceneIndex >= PlayerPrefs.GetInt("levelsUnlockeV2"))
            {
                PlayerPrefs.SetInt("levelsUnlockeV2", correctScene + 1);
            }
            Debug.Log("LEVEL "+PlayerPrefs.GetInt("levelsUnlockeV2")+" UNLOCKED");

            if(currentSceneIndex<11)
            {
                SceneManager.LoadScene(currentSceneIndex + 1); 
            } else {
                SceneManager.LoadScene("Level 0");
            }
        
    }
}
