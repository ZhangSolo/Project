using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFire : MonoBehaviour
{
    // Use this for initialization
    public float speed = 3f;
    private bool movingRight = true;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //假设我在x轴-5到5之间左右循环移动
        if (movingRight)
        {
            //我正在右移
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            //如果我移到了5，那么接下来就是左移，所以把右移设为false
            /*if (transform.position.x >= 5)
            {
                movingRight = false;
            }*/
        }
        else
        {
            //当我在左移，而且x轴坐标到了-5，说明结束左移，开始右移
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            //左移结束，右移开始，设置状态为true
            /*if (transform.position.x <= -5)
            {
                movingRight = true;
            }*/
        }
    }
    public void OnCollisionEnter(Collision other)
    {

        if (other.collider.name == "batL")
        {
            movingRight = false;
        }//进入碰撞器执行的代码
        if (other.collider.name == "batR")
        {
            movingRight = true;
        }//进入碰撞器执行的代码
    }
}
