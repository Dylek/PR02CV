using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

    //dzięki kilku źródłom dźwięku chronimy się od sutuacjy gdy zagranie jednego dźwięku urywa inny
    private List<AudioSource> audioSourcePool;
    //SoundContoller to singleton
    public static SoundController instance = null;
    void Awake(){
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
    void Start(){
        audioSourcePool = new List<AudioSource>();
        for (int i = 0; i < 10; i++)
        {
            AudioSource temp = gameObject.AddComponent<AudioSource>();
            temp.enabled = enabled;
            audioSourcePool.Add(temp);
        }

    }

  
    public void PlayMyClip(AudioClip clip){
        GetFirstFree().PlayOneShot(clip, 1f);
    }
    //Bierzemy kolejne źródło które nie gra w danym momencie
    public AudioSource GetFirstFree(){
        foreach (AudioSource temp in audioSourcePool){
            if (temp.isPlaying == false){
                return temp;
            }
        }
        return null;
    }
}
