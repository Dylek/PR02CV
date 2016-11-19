using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {


    private List<AudioSource> audioSourcePool;
    public static SoundController instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
    }

    // Use this for initialization
    void Start()
    {

        audioSourcePool = new List<AudioSource>();
        for (int i = 0; i < 10; i++)
        {
            AudioSource temp = gameObject.AddComponent<AudioSource>();
            temp.enabled = enabled;
            audioSourcePool.Add(temp);
        }

    }

  
    public void PlayMyClip(AudioClip clip)
    {
        GetFirstFree().PlayOneShot(clip, 1f);
    }
    public AudioSource GetFirstFree()
    {
        foreach (AudioSource temp in audioSourcePool)
        {
            if (temp.isPlaying == false)
            {
                return temp;
            }
        }
        return null;
    }
}
