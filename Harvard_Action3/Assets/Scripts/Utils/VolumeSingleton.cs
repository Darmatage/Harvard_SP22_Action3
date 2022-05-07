using System.Collections.Generic;
using UnityEngine;

public class VolumeSingleton : Singleton<VolumeSingleton>
{
    public static float musicVolumeLevel = 0.2f;
    public static float sxfVolumeLevel = 0.2f;

    protected override void Awake() {
        base.Awake();
    }

    public void SetMusicVolumeLevel(float level)
    {
        musicVolumeLevel = level;
    }

    public float GetMusicVolumeLevel()
    {
        return musicVolumeLevel;
    }

    public void SetSFXVolumeLevel(float level)
    {
        sxfVolumeLevel = level;
    }

    public float GetSXFVolumeLevel()
    {
        return sxfVolumeLevel;
    }

}
