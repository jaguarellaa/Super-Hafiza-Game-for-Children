using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startcontroller : MonoBehaviour
{
    
    public void fonkstart()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
