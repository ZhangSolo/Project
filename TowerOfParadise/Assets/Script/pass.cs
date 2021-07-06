using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pass : MonoBehaviour
{
    // Start is called before the first frame update
 
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other .gameObject.tag == "Player") {
            SceneManager.LoadScene("No.1");

        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
