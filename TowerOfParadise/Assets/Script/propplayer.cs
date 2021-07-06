using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class propplayer : MonoBehaviour
{
    [Header("把子弹预制体拉到这")]
    public GameObject _bullet;  //子弹预制体

    void Update()
    {

        if (propUI.Instance.Count > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_bullet);
                propUI.Instance.AutoAdd();
            }
        }
    }
}

