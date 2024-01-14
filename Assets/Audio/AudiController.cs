using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiController : MonoBehaviour
{
    public AudioClip carCrash, getCoin, engine, wheelOfLuck, win, fail, click,accident,heicopter,hint,redLight;
    public AudioSource BGM;
    public AudioSource aus;

    public static AudiController ins;

    private void Awake()
    {
        if (ins != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            ins = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Vibrate();
        BackGroundMusic();

    }

    public void UpdateSoundAndMusic(AudioSource aus, AudioClip audioClip)
    {
        aus.PlayOneShot(audioClip);


    }


    public void BackGroundMusic()
    {
        if (PlayerPrefs.GetInt("isMusic") == 1)
        {
            BGM.Pause();
            aus.volume = 0;
        }
        else if (PlayerPrefs.GetInt("isMusic") == 0)
        {
            BGM.UnPause();
            aus.volume = 1;
        }
    }
    public void Vibrate()
    {
        if (PlayerPrefs.GetInt("isVibrate") == 1)
        {
            UIMusicController.ins.checkVirator = false;
        }
        else if (PlayerPrefs.GetInt("isVibrate") == 0)
        {
            UIMusicController.ins.checkVirator = true;
        }
    }
}
