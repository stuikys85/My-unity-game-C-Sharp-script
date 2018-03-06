using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 3f;
    public static GameManager gameManager;
    public GameObject GameOverPanel;
    public static GameManager instance = null;
   // public GameObject YouWinPanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

    }
    public void Win()
    {
       // YouWinPanel.SetActive(true);
        
    }



    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            GameOverPanel.SetActive(true);
            gameHasEnded = true;
            Debug.Log("GAME OVER");

            Invoke("Restart", restartDelay);
        }
       

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
      
    }
    
    


