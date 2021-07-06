using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class propUI : MonoBehaviour
{
    private static propUI _instance;

    public static propUI Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                return null;
            }
        }
    }
    public Text CountText;


    [Header("子弹总数")]
    public int Count;

    void Awake()
    {
        _instance = this;
        Count = 30;
    }
    public void AutoAdd()
    {
        CountText.text = "弹药:" + --Count;
    }
}