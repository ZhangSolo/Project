using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject TnT;
    public Transform Location;
    public int BulletSpeed = 1000;
    public float lifetime = 2f;
    private float creationTime;

    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            if (Time.time > (creationTime + lifetime))
            {
                GameObject Bul = Instantiate(Bullet, Location.position, Location.rotation);
                Bul.GetComponent<Rigidbody>().velocity = Location.right * BulletSpeed * Time.deltaTime;
                creationTime = Time.time;

            }
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
