using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    

    public Canvas canStart;
    public Canvas canInGame;
    public Canvas canPause;
    public Canvas canFinish;
    public Canvas canLose;
    public Canvas canWarm;
    public Canvas canContainer;
    

    private int Coint = 0;  // điểm
    private void Start()
    {
       
        PlayerPrefs.SetString("Loaded", "true");

        canStart.gameObject.SetActive(true);
        canInGame.gameObject.SetActive(false);
        canPause.gameObject.SetActive(false);
        canFinish.gameObject.SetActive(false);
        canLose.gameObject.SetActive(false);
        canWarm.gameObject.SetActive(false);
        
    }

    public void btnClickStart()
    {
        if (Time.time < 5)
        {
            canWarm.gameObject.SetActive(true);
            return;
        }
        canStart.gameObject.SetActive(false);
        canInGame.gameObject.SetActive(true);
        canWarm.gameObject.SetActive(false);

    }

    public void btnClickPause()
    {
        canInGame.gameObject.SetActive(false);
        canPause.gameObject.SetActive(true);
        
    }

    public void btnClickContinue()
    {
        canInGame.gameObject.SetActive(true);
        canPause.gameObject.SetActive(false);
        
    }

    public void btnClickAgain()
    {
        Coint = 0;
        SceneManager.LoadScene(0);
        canStart.gameObject.SetActive(false);
        canInGame.gameObject.SetActive(true);
        canPause.gameObject.SetActive(false);
        canFinish.gameObject.SetActive(false);
        canLose.gameObject.SetActive(false);
        GameObject.Find("Ball_Player").SendMessage("ReSpawn", true);

    }

    public void btnClickOut()
    {
        Application.Quit();
    }
    // cộng điểm
    public void AddCoint()
    {
        Coint++;
        GameObject.Find("Ball_Player").SendMessage("boolCoDiem");
        Debug.Log(Coint);
    }
    // game done
    public void Finish()
    {
        
        canStart.gameObject.SetActive(false);
        canInGame.gameObject.SetActive(false);
        canPause.gameObject.SetActive(false);
        if (Coint == 3)
        {
            canFinish.gameObject.SetActive(true);
            canLose.gameObject.SetActive(false);
        }
        else
        {
            canFinish.gameObject.SetActive(false);
            canLose.gameObject.SetActive(true);
        }
        
    }

   

}
