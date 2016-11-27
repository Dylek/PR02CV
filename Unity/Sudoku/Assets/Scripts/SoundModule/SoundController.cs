using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

    //dzięki kilku źródłom dźwięku chronimy się od sutuacjy gdy zagranie jednego dźwięku urywa inny
    private List<AudioSource> audioSourcePool;
    private AudioSource background;
    public AudioClip buttonClickedSound;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    //SoundContoller to singleton
    public static SoundController instance = null;
    private 
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
        background = gameObject.AddComponent<AudioSource>();
        background.loop = true;
        audioSourcePool = new List<AudioSource>();
        for (int i = 0; i < 10; i++)
        {
            AudioSource temp = gameObject.AddComponent<AudioSource>();
            temp.enabled = enabled;
            audioSourcePool.Add(temp);
        }
        PlayBackground(SoundController.instance.music2);
    }
    public void ButtonClicked()
    {
        PlayMyClip(buttonClickedSound);
    }
  
    public void PlayMyClip(AudioClip clip){
        GetFirstFree().PlayOneShot(clip, 1f);
    }
    public void PlayBackground(AudioClip clip)
    {
        background.clip = clip;
        background.Play();
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

    public void SetSound(float volume)
    {
       
        foreach(AudioSource temp in audioSourcePool)
        {
            temp.volume = volume;
        }
        background.volume = volume;
    }
}
