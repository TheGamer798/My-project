using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PrefrencesManager
{
    
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat("MasterVolume", 1);
    }
    
    public static void SetMasterVolume(float soundLeve1)
    {
        PlayerPrefs.GetFloat("MasterVolume", soundLeve1);
    }

}
