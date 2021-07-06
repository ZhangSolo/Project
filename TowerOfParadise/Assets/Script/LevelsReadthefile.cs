using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsReadthefile : MonoBehaviour
{
    static public int LevelsWrite;
    private Text LevelsWriteCount;
    // Start is called before the first frame update
    void Start()
    {
        LevelsWriteCount = GameObject.Find("Txt_Levels").GetComponent<Text>();
        LevelsWrite = GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.LevelsNum;
        LevelsWriteCount.text = LevelsWrite.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
