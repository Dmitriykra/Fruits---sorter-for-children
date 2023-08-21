using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    int levelsUnlocke;
    public Button[] buttons;
    public Image[] images;
    [SerializeField] private Sprite _lock, _unlock, _locker;
    
    // Start is called before the first frame update
    void Start()
    {
        levelsUnlocke = PlayerPrefs.GetInt("levelsUnlockeV2", 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            //if(i==10){return;}
            buttons[i].interactable = false;
            images[i].sprite = _locker;
            buttons[i].GetComponent<Image>().sprite = _lock;
        }

        for(int i = 0; i < levelsUnlocke; i++)
        {
            if(i==10){return;}
            Debug.Log(i);
            buttons[i].interactable = true;
            images[i].gameObject.SetActive(false);
            buttons[i].GetComponent<Image>().sprite = _unlock;
        }
    }

    public void LoadLevelManager(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
