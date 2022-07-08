using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int numberofchoices;

    GameObject selectedbutton;
    GameObject thebuttonitself;

    public Sprite defaultSprite;
    public int targetsuccess;

   
    public GameObject[] Buttons;
    public Button pause;
    public Button continuebtn;
    
    

    public Text timertext;
    public Text resultimertext;

    public GameObject[] GameEndPanels;
    

    public GameObject Grid;
    public GameObject Pool;
   
    public Text matchesnumbertext;




    float min;
    float second;
    bool timer;
   

    int momentsuccess;

    bool createstatus;
    int createnumber;
    int number;
    int totalelement;

    int matchesnumber;

    public float counter;


    public int nextSceneLoad;



    void Start()
    {
        totalelement = Pool.transform.childCount;

        matchesnumber = 0;
        numberofchoices = 0;
        timer = true;


        createstatus = true;
        createnumber = 0;

        StartCoroutine(Create());
    }

    private void Update()
    {
        counter += Time.deltaTime;
        min = Mathf.FloorToInt(counter / 60);
        second = Mathf.FloorToInt(counter % 60);
        timertext.text = string.Format("{0:00}:{1:00}", min, second);
    }



    IEnumerator Create()
    {
        yield return new WaitForSeconds(.5f);

        while(createstatus)
        {
            int randomnumber = Random.Range(0, Pool.transform.childCount-1 );

            if (Pool.transform.GetChild(randomnumber).gameObject!=null)
            {
                Pool.transform.GetChild(randomnumber).transform.SetParent(Grid.transform);
                createnumber++;

                if(createnumber==totalelement)
                {
                    createstatus = false;
                   
                }
              
            }

         
        }

    }

        public void Retry()
         {

      
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           int currentlevel = SceneManager.GetActiveScene().buildIndex;
          PlayerPrefs.SetInt("levelsUnlocked", currentlevel);
          GameEndPanels[1].SetActive(true);
            Time.timeScale = 1;

    }


        public void NextLevel()
        {
         
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
          GameEndPanels[1].SetActive(true);
          Time.timeScale = 1;

    }

        void NextLevelPanel()
       {


   
        Time.timeScale = 0;
        GameEndPanels[0].SetActive(true);
        matchesnumbertext.text =matchesnumber.ToString();

        if(min==0 && second>9)
        {
            resultimertext.text = "00:"+second ;
        }
        else if(min == 0 && second <= 9)
        {
            resultimertext.text = "00:0" + second;
        }
        else
        {
            resultimertext.text = min + " : " + second;
        }

        }







    public void MainMenu()
    {

        int currentlevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("levelsUnlocked", currentlevel);
        SceneManager.LoadScene(1);

    }



    public void MainMenuOyunIcý()
    {

        int currentlevel = SceneManager.GetActiveScene().buildIndex;
      
        SceneManager.LoadScene(1);

    }





    public void Pause()
    {
        pause.gameObject.GetComponent<Image>().gameObject.SetActive(false);
        continuebtn.gameObject.GetComponent<Image>().gameObject.SetActive(true);
        pause.interactable = false;
        continuebtn.interactable = true;
      
        
        
        Time.timeScale = 0;
    }

   

    public void Continue()
    {



        pause.gameObject.GetComponent<Image>().gameObject.SetActive(true);
        continuebtn.gameObject.GetComponent<Image>().gameObject.SetActive(false);
        continuebtn.interactable = false;
        pause.interactable = true;
      
       
        Time.timeScale = 1;
    }

    public void GiveObject(GameObject obj)
    {
        thebuttonitself = obj;
        thebuttonitself.GetComponent<Image>().sprite = thebuttonitself.GetComponentInChildren<SpriteRenderer>().sprite;
        thebuttonitself.GetComponent<Image>().raycastTarget = false;
      
    }

    void StatusOfButtons(bool status )
    {
        foreach(var item in Buttons)
        {
            if (item != null)
            {
                item.GetComponent<Image>().raycastTarget = status;
            }
        }
    }

    public void ButtonClick(int deger)
    {

        Controller(deger);

    }

    void Controller(int incomingvalue)
    {
        if (numberofchoices == 0)
        {
            numberofchoices = incomingvalue;
            selectedbutton = thebuttonitself;
        }
        else
        {
            StartCoroutine(check(incomingvalue));
        }
    }

    IEnumerator check(int incomingvalue)
    {

        matchesnumber++;

        
        StatusOfButtons(false);
        yield return new WaitForSeconds(.8f);

        if (numberofchoices == incomingvalue)
        {

           
            momentsuccess++;
            selectedbutton.GetComponent<Image>().enabled=false;
            thebuttonitself.GetComponent<Image>().enabled = false;

            numberofchoices = 0;
            selectedbutton = null;
            StatusOfButtons(true);


            if (targetsuccess==momentsuccess)
            {
                NextLevelPanel();
            }

        }
        else
        {
           
            selectedbutton.GetComponent<Image>().sprite = defaultSprite;
            thebuttonitself.GetComponent<Image>().sprite = defaultSprite;

            selectedbutton.GetComponent<Image>().raycastTarget = true;
            thebuttonitself.GetComponent<Image>().raycastTarget = true;

            numberofchoices = 0;
            selectedbutton = null;
            StatusOfButtons(true);
        }
    }

}
