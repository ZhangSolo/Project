using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReadFileDeathAndTime : MonoBehaviour
{
    static public int DeathNum = 0;
    private Text txtcount;
    static public int hour;
    static public int minute;
    static public int second;
    // 已经花费的时间 
    static public float timeSpend = 0.0f;
    // 显示时间区域的文本 
    Text text_timeSpend;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("save").SendMessage("OnClickLoad");
        text_timeSpend = GameObject.Find("Txt_Time").GetComponent<Text>();
        txtcount = GameObject.Find("Txt_DeathNum").GetComponent<Text>();
        timeSpend = GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.TimeSpend;
        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;

        txtcount.text = DeathNum.ToString();

        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
