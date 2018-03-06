using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour
{
    public string nextLevel;
    public GameObject objToDestroy;
    GameObject objUI;
    public GameObject YouWinPanel;
   // public float loadScene = 3f;
    public float timer = 7f;
  

    void Start()
    {
       
        objUI = GameObject.Find("Skaiciuoja");

    }
    void Update()
    {
        objUI.GetComponent<Text>().text = ObjectsToCollect.objects.ToString();
        if(ObjectsToCollect.objects == 0)
        {
            
           Destroy(objToDestroy);
            objUI.GetComponent<Text>().text = "ALL SKULLS COLLECTED";
            YouWinPanel.SetActive(true);
          
            timer -= Time.deltaTime;
          
            if (timer <= 0)
            {
               
                Application.LoadLevel(nextLevel);
            }
        }
        
    }

}
