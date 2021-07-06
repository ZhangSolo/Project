using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScence : MonoBehaviour
{
    private Button btn_start;
    private Button btn_exit;
    private Animator optionAnim;


    public void OnStartButtonStart()
    {
        GameObject.Find("save").SendMessage("NewSave");
        SceneManager.LoadScene("0-1");
    }
    public void OnStartButtonsReadthefile()
    {
        SceneManager.LoadScene("Readthefile");
    }
    public void OnStartButtonExit()
    {
        Application.Quit();
    }
    public void OnStarButton()
    {
        GameObject.Find("save").SendMessage("OnClickSave");
        SceneManager.LoadScene("Start");
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
