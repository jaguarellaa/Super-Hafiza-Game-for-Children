using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


   public void Pass()
    {
        int currentlevel = SceneManager.GetActiveScene().buildIndex;
       
        if(currentlevel >= PlayerPrefs.GetInt("levelsUnlocked") )
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentlevel );
        }

        

        Debug.Log("Level" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");


   
    }
}
