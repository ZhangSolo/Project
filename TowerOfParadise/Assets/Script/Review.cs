using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Review : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform newTransform;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            player.transform.position = newTransform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}