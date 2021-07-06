using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    public AudioSource BGSound;//背景音乐音源
    public AudioSource FXSound;//音效音乐音源
    private Slider slider_bgVollume;
    private Slider slider_fxVollume;
    private Toggle tog_fullScreen;
    private Animator optionAnim;
    private bool tagEsc = false;
    //private bool tagPause = false;
    // Start is called before the first frame update
    void Awake()
    {
        slider_bgVollume = GameObject.Find("Slider_bgVollume").GetComponent<Slider>();
        slider_fxVollume = GameObject.Find("Slider_fxVollume").GetComponent<Slider>();
        tog_fullScreen = GameObject.Find("tog_fullScreen").GetComponent<Toggle>();
        optionAnim = GetComponent<Animator>();
    }
    void Start()
    {
        BGSound.volume = slider_bgVollume.value;//读取背景音乐的大小
        FXSound.volume = slider_fxVollume.value;//读取音效音乐的大小
        if (tog_fullScreen.isOn)
        {
            if (!Screen.fullScreen)
            {
                Screen.SetResolution(Screen.width, Screen.height, true);
            }
        }
        else
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(Screen.width, Screen.height, false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tagEsc = !tagEsc;
            if (tagEsc)
            {
                optionAnim.SetBool("OptionIn", true);
                optionAnim.SetBool("OptionOut", false);
            }
            else
            {
                optionAnim.SetBool("OptionOut", true);
                optionAnim.SetBool("OptionIn", false);
            }
        }
    }
    public void Onbtn_OK()
    {
        BGSound.volume = slider_bgVollume.value;//读取背景音乐的大小
        FXSound.volume = slider_fxVollume.value;//读取音效音乐的大小
        if (tog_fullScreen.isOn)
        {
            if (!Screen.fullScreen)
            {
                Screen.SetResolution(Screen.width, Screen.height, true);
            }
        }
        else
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(Screen.width, Screen.height, false);
            }
        }
        optionAnim.SetBool("OptionOut", true);
        optionAnim.SetBool("OptionIn", false);
        tagEsc = false;
    }
    public void Onbtn_reset()
    {
        BGSound.volume = 0.5f;
        FXSound.volume = 0.5f;
        slider_bgVollume.value = BGSound.volume;
        slider_fxVollume.value = FXSound.volume;
        tog_fullScreen.isOn = false;
    }
    public void OnChangebgVollume()
    {
        BGSound.volume = slider_bgVollume.value;

    }
    public void OnChangefxVollume()
    {
        FXSound.volume = slider_fxVollume.value;
    }

    public void OnChangeFullScreen()
    {
        if (tog_fullScreen.isOn)
        {
            if(!Screen.fullScreen){
                Screen.SetResolution(Screen.width, Screen.height, true);
            }
        }
        else
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(Screen.width, Screen.height, false);
            }
        }
    }
}
