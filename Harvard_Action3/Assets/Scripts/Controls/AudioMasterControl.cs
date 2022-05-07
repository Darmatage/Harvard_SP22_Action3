using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Game.Control
{
    public class AudioMasterControl : MonoBehaviour 
    {
            [SerializeField] AudioMixer musicMixer;
            [SerializeField] Slider musicSliderVolumeCtrl;

            [SerializeField] AudioMixer sFXMixer;
            [SerializeField] Slider sFXSliderVolumeCtrl;

            private VolumeSingleton volumeSingleton;
            private AudioSource levelMusicSource;

            private void Awake ()
            {
                volumeSingleton = GameObject.FindWithTag(Tags.VOLUME_STATE_PERSISTS_TAG).GetComponent<VolumeSingleton>();
                levelMusicSource = GameObject.FindWithTag(Tags.LEVEL_MUSIC_TAG).GetComponent<AudioSource>();
            }

            private void OnEnable()
            {
                EventHandler.ActiveGameUI += ToggleLevelMusic;
            }

            private void OnDisable()
            {
                EventHandler.ActiveGameUI -= ToggleLevelMusic;
            }

            private void Start() 
            {
                SetMusicLevel(volumeSingleton.GetMusicVolumeLevel());
                SetSFXLevel(volumeSingleton.GetSXFVolumeLevel());
            }

            public void SetMusicLevel (float sliderValue)
            {
                volumeSingleton.SetMusicVolumeLevel(sliderValue);
                musicMixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
                musicSliderVolumeCtrl.value = sliderValue;
            }
            
            public void SetSFXLevel (float sliderValue)
            {
                volumeSingleton.SetSFXVolumeLevel(sliderValue);
                sFXMixer.SetFloat("SFXVolume", Mathf.Log10 (sliderValue) * 20);
                sFXSliderVolumeCtrl.value = sliderValue;
            }

            private void ToggleLevelMusic(bool isGamePaused)
            {
                if (levelMusicSource.isPlaying)
                {
                    levelMusicSource.Pause();
                }
                else
                {
                    levelMusicSource.Play();
                }
            }
    }
}
