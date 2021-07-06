using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    // Start is called before the first frame update
    public AudioSource snd;
    public AudioClip jumpAudio, curjumpAudio,deathAudio,teleAudio;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void JumpAudio()
    {
        snd.volume = 1;
        snd.clip = jumpAudio;
        snd.Play();
    }
    public void DeathAudio()
    {
        snd.volume = 0.4f;
        snd.clip = deathAudio;
        snd.Play();
    }

    public void CurJumpAudio()
    {
        snd.volume = 1;
        snd.clip = curjumpAudio;
        snd.Play();
    }
    public void TeleAudio()
    {
        snd.volume = 0.4f;
        snd.clip = teleAudio;
        snd.Play();
    }

}
