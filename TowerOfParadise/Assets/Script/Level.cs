using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
    static public int Levels;
    private int sceneIndex;
    private Text Levelscount;
    // Start is called before the first frame update
    void Start()
    {
        Levelscount = GameObject.Find("Txt_Levels").GetComponent<Text>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        //Levelscount.text = Levels.ToString();

        //if (sceneIndex == 1)
        //{
        //    Levels = 1;
        //}
        //if (sceneIndex == 2)
        //{
        //    Levels = 2;
        //}
        //if (sceneIndex == 3)
        //{
        //    Levels = 3;
        //}
        //if (sceneIndex == 4)
        //{
        //    Levels = 4;
        //}

        Levels = SceneManager.GetActiveScene().buildIndex;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.LevelsNum = Levels;
        GameObject.Find("save").SendMessage("OnClickSave");
        GameObject.Find("save").SendMessage("OnClickLoad");
        Levelscount.text = Levels.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
