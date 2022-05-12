using System.Collections.Generic;
using UnityEngine;

public class VolumeSingleton : Singleton<VolumeSingleton>
{
    public static float musicVolumeLevel = 0.2f;
    public static float sxfVolumeLevel = 0.2f;
    public static int totalTokens = 0;

    protected override void Awake() {
        base.Awake();
    }

    private void OnEnable()
    {
        EventHandler.LoadNextSceneEvent += SetTokenTotals;
    }

    private void OnDisable()
    {
        EventHandler.LoadNextSceneEvent -= SetTokenTotals;
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

    private void SetTokenTotals()
    {
        totalTokens = GameObject.FindWithTag(Tags.GAME_HANDLER_TAG).GetComponent<GameHandler>().GetTotalTokens();
    }

    public int GetTokenTotals()
    {
        return totalTokens;
    }

}
