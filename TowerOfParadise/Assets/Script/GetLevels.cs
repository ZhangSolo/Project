using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetLevels : MonoBehaviour
{
    public Button GetScenesButton;
    static public int Levels;
    Text text_levelsSpend;
    // Start is called before the first frame update
    void Start()
    {
        text_levelsSpend = GetComponent<Text>();
        //Levels = GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.LevelsNum;
        //GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.LevelsNum = Levels;
        //GameObject.Find("save").SendMessage("OnClickSave");
    }
    private void Awake()
    {
        GetScenesButton.onClick.AddListener(GetScenes);

    }
    private void GetScenes()
    {
        Levels = Level.Levels;
        Levels = LevelsReadthefile.LevelsWrite;
        SceneManager.LoadScene(Levels);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
