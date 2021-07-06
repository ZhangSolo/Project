using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using System.Text;

using System.IO;

public class Json_SavaAndLoad : MonoBehaviour
{
    public Button SaveButton;
    public Button LoadButton;
    public Text Info;
    public SaveData TestData;
    // Start is called before the first frame update
    private void Awake()
    {
        //SaveButton.onClick.AddListener(OnClickSave);
        //LoadButton.onClick.AddListener(OnClickLoad);
    }
    private void OnClickSave()
    {
        TestData.DeathNum = PlayerController.DeathNum;
        TestData.TimeHour = GetTime.hour;
        TestData.TimeMinute = GetTime.minute;
        TestData.TimeSecond = GetTime.second;
        TestData.TimeSpend = GetTime.timeSpend;
        TestData.LevelsNum = Level.Levels;
        //TestData.DeathNum += GetComponent<PlayerController>().DeathNum;
        //这里直接调用JsonUtility.ToJson(TestData);
        string jsonStr = JsonUtility.ToJson(TestData);
        //将转换好的Json存储到PLayerPrefs
        PlayerPrefs.SetString("SAVE_DATA", jsonStr);
        //保存时清空数据以便测试加载
        //TestData.DeathNum = 0;TestData.TimeHour = 0; ;TestData.TimeMinute = 0;TestData.TimeSecond = 0;
        //StreanWriter写入文件
        string PATH = Application.dataPath + "/Save.data";
        StreamWriter sw = new StreamWriter(PATH);
        sw.Write(jsonStr);//直接写入
        sw.Close();//写入完关闭Stream
    }
    public void NewSave()
    {
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.DeathNum = 0;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.LevelsNum = 0;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.TimeHour = 0;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.TimeMinute = 0;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.TimeSecond = 0;
        GameObject.Find("save").GetComponent<Json_SavaAndLoad>().TestData.TimeSpend = 0;
        OnClickSave();
    }
    private void OnClickLoad()
    {
        //string loadStr = PlayerPrefs.GetString("SAVE_DATA", "");
        //使用对应的StreamReader加载文件
        string PATH = Application.dataPath + "/Save.data";
        StreamReader sr = new StreamReader(PATH);
        string loadStr = sr.ReadToEnd();
        sr.Close();

        if (loadStr.Length > 0)
        {
            //可以调用FronJson<T>这个方法将Json转换成指定类
            TestData = JsonUtility.FromJson<SaveData>(loadStr);
            //Info.text = TestData.ToString();
        }
        PlayerController.DeathNum = TestData.DeathNum;
        GetTime.hour = TestData.TimeHour;
        GetTime.minute = TestData.TimeMinute;
        GetTime.second = TestData.TimeSecond;
        GetTime.timeSpend = TestData.TimeSpend;
        ReadFileDeathAndTime.DeathNum = TestData.DeathNum;
        ReadFileDeathAndTime.hour = TestData.TimeHour;
        ReadFileDeathAndTime.minute = TestData.TimeMinute;
        ReadFileDeathAndTime.second = TestData.TimeSecond;
        ReadFileDeathAndTime.timeSpend = TestData.TimeSpend;
        Level.Levels = TestData.LevelsNum;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //TestData.DeathNum = PlayerController.DeathNum;
    }

}


[System.Serializable]
public class SaveData
{
    public int DeathNum;
    public int TimeHour;
    public int TimeMinute;
    public int TimeSecond;
    public float TimeSpend;
    public int LevelsNum;

    //public override string ToString()
    //{
    //    return "死亡数:" + DeathNum + ", 上次存档时刻:" + Time/* + ", 上次存档关卡:" + LevelsNum*/;
    //}
}
