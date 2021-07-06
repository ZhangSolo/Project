using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ***************Unity文字逐字显示实现***************
/// </summary>
public class Text_ : MonoBehaviour
{
    public Text text;
    public TextAsset m_TextAsset;
    private string str ;

    public float waitTime = 0.2f; //字符间隔

    //private float speed = 0;    //计时
    public AudioClip OpenDoorSound;  //指定需要播放的音效
    private AudioSource source;   //必须定义AudioSource才能调用AudioClip

    #region 第一种方法实现
    void Start()
    {
        str = m_TextAsset.text;
        source = GetComponent<AudioSource>();  //将this Object 上面的Component赋值给定义的AudioSource
        Go();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    
        //}
        
    }
    IEnumerator Numerator()
    {
        source.Play();
        //source.PlayOneShot(OpenDoorSound,1f);
        foreach (var item in str)
        {
            text.text += item;
            //
            yield return new WaitForSeconds(waitTime);
            
        }
        source.Stop();
        Destroy(gameObject, 5);
    }
    void Go()
    {
        StartCoroutine("Numerator");  //开启协程
    }
    #endregion

    #region 第二种方法实现
    //private void Update()
    //{
    //    //speed += 0.2f;     //直接加等于也可以      亲测可用
    //    speed += Time.deltaTime * 10f;   //感觉慢就乘上一个数

    //    text.text = str.Substring(0, (int)speed + 1);

    //    //Substring 逐个增加字符串的数量   vs 可按F12自行查看

    //}
    #endregion


}