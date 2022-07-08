using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{

    int levelsUnlocked;

    public Button[] lvlButtons;
 

    private void Start()
    {   
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for(int i=0;i<lvlButtons.Length;i++)
        {
            lvlButtons[i].interactable = false;        
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
                if(i == 5)
                {
                lvlButtons[5].interactable = true;

                break;
                }
               else
               {
                lvlButtons[i].interactable = true;
               }

               
            
           

        }

    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);   
            
            
    }


    public void Reset()
    {

        PlayerPrefs.DeleteAll();

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            lvlButtons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            lvlButtons[i].interactable = true;
        }

        SceneManager.LoadScene(1) ;

       

    }

  

    

}
