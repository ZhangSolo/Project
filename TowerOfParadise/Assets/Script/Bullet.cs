using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Destroy(collision.gameObject);
            //破坏音效
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
