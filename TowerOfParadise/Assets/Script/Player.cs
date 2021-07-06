using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
 
    private Transform Player1;
    private Vector3 startPosition;
    public float m_speed = 5f;
    public float r_speed = 10f;
    public Rigidbody rg;
    public float Jumpforce = 10;
    public float RotSpeed = 10;
    bool isJump = false;
    bool isDoubleJump = false;
    public float moveDistance = 0.03f;

    void Start()
    {
        Player1 = gameObject.GetComponent<Transform>();
        rg = this.GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //shift加速
        if (Input.GetKey(KeyCode.LeftShift)| Input.GetKey(KeyCode.RightShift)) {
            //rg.AddForce(transform.right * 500f);
            if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(Vector3.right * -r_speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(Vector3.right * r_speed * Time.deltaTime);
            }

        }
        //闪现
        if (Input.GetKeyDown(KeyCode.X)) {
            Vector3 one = transform.position;
            Vector3 two = transform.position;
            Vector3 dir = (one+two);
            dir = dir.normalized;
            Vector3 targetpos = transform.position + dir * moveDistance;
            targetpos.y = one.y;
            transform.position = targetpos;

        }

        //左右
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.right * -m_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)//如果还在跳跃中，则不重复执行 
            {
                rg.velocity = Vector3.up * Jumpforce;
                isJump = true;
            }
            else
            {
                if (isDoubleJump)//判断是否在二段跳 
                {
                    return;//否则不能二段跳 
                }
                else
                {
                    isDoubleJump = true;
                    rg.velocity = Vector3.up * Jumpforce;
                }
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {  if (collision.collider.tag == "accelerate")
        {
            m_speed = 10f;
        }
        else {
            m_speed = 5f;
        }
        if (collision.collider.tag == "enemy") {
            transform.position = startPosition;
        }
        if (collision.collider.tag == "Ground")//碰撞的是Plane 
        {
            isJump = false;
            isDoubleJump = false;
        }
      
    }

}
