using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM S;
    public AudioSource snd;
    public AudioClip BackgroundMusic;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (S == null)
            S = this;
        else if (S != this)
        {
            if (S.BackgroundMusic != BackgroundMusic) {
                S.BackgroundMusic = BackgroundMusic;
                S.snd.clip = BackgroundMusic;
                S.snd.Play();
            }

            Destroy(gameObject);
        }
            

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        snd.clip = BackgroundMusic;
        snd.volume = 0.3f;
        snd.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
