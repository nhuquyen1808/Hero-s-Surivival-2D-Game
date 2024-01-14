using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMusicController : MonoBehaviour
{
    public static UIMusicController ins;
    public Button musicOffBtn;
    public Button musicOnBtn;
    public Button vibrateON;
    public Button vibrateOff;
    public bool checkVirator = true;

    private void Awake()
    {
        ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        musicOffBtn.onClick.AddListener(OnclickMusicOn);
        musicOnBtn.onClick.AddListener(OnclickMusicOff);
        vibrateON.onClick.AddListener(VibrateOff);
        vibrateOff.onClick.AddListener(VibrateOn);
        SaveSoundAndMusic();
        AudiController.ins.BackGroundMusic();
    }
    // Update is called once per frame
    void Update()
    {
    }
    void SaveSoundAndMusic()
    {
        if (PlayerPrefs.GetInt("isMusic") == 0)
        {
            OnclickMusicOn();
        }
        else if (PlayerPrefs.GetInt("isMusic") == 1)
        {
            OnclickMusicOff();
        }
        if (PlayerPrefs.GetInt("isVibrate") == 0)
        {
            VibrateOn();
        }
        else if (PlayerPrefs.GetInt("isVibrate") == 1)
        {
            VibrateOff();
        }
    }

    public void OnclickMusicOff()
    {
        musicOnBtn.gameObject.SetActive(false);
        musicOffBtn.gameObject.SetActive(true);
        // Debug.Log("Music Off");
        PlayerPrefs.SetInt("isMusic", 1);
        PlayerPrefs.Save();
        AudiController.ins.BackGroundMusic();
    }
    public void OnclickMusicOn()
    {
        musicOnBtn.gameObject.SetActive(true);
        musicOffBtn.gameObject.SetActive(false);
        PlayerPrefs.SetInt("isMusic", 0);
        PlayerPrefs.Save();
        AudiController.ins.BackGroundMusic();
    }


    public void VibrateOn()
    {
        //ON
        vibrateOff.gameObject.SetActive(false);
        vibrateON.gameObject.SetActive(true);
        PlayerPrefs.SetInt("isVibrate", 0);
        checkVirator = true;

    }
    public void VibrateOff()
    {
        //Off
        vibrateOff.gameObject.SetActive(true);
        vibrateON.gameObject.SetActive(false);
        PlayerPrefs.SetInt("isVibrate", 1);
        checkVirator = false;
    }
}
