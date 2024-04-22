using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public static AudioManager Instance { get { return instance; } }

    public AudioMixer masterMixer;

    public Slider masterSlider;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        masterMixer.SetFloat("MasterVol", PrefrencesManager.GetMasterVolume());

        if (masterSlider != null)
            PrefrencesManager.GetMasterVolume();
    }

    public void ChangeSoundVolume(float soundLeve1)
    {
        masterMixer.SetFloat("MasterVol", soundLeve1);
        PrefrencesManager.SetMasterVolume(soundLeve1);
    }
}
