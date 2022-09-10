using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{

    public static AudioClip deadAudio, winAudio, jumpAudio;
    static AudioSource gameAudioSource;



    // Start is called before the first frame update
    void Start()
    {
        deadAudio = Resources.Load<AudioClip>("DeadAudio");
        winAudio = Resources.Load<AudioClip>("WinAudio");
        jumpAudio = Resources.Load<AudioClip>("JumpAudio");

        gameAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayAudio (string clip) 
    {
        switch (clip)
        {
            case ("dead"):
                gameAudioSource.PlayOneShot(deadAudio);
                break;

            case ("win"):
                gameAudioSource.PlayOneShot(winAudio);
                break;

            case ("jump"):
                gameAudioSource.PlayOneShot(jumpAudio);
                break;

        }

    }

}
