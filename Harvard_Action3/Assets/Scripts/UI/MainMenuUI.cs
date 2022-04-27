using System;
using System.Collections;
using System.Collections.Generic;
using Game.Enums;
using Game.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] float fadeTime = 0.5f;
        [SerializeField] int firstSceneBuildIndex = 1;
        [SerializeField] GameObject loadScreenCanvas = null;
        [SerializeField] GameObject startGameButton = null;

        private void Awake() {
            GetComponentInChildren<LoadCanvasUI>().loadScreenUpdated += ShowStartButton;
        }

        public void StartNewGame()
        {
            //savingWrapper.value.NewGame(firstSceneBuildIndex, fadeTime);
        }

        private void ShowStartButton()
        {
            if (startGameButton != null) startGameButton.SetActive(true);
        }

        private IEnumerator FadeToLoadScreen() 
        {
            CanvasFader fader = FindObjectOfType<CanvasFader>();
            yield return fader.FadeOut(fadeTime);
            if (loadScreenCanvas != null) loadScreenCanvas.SetActive(true);
            if (startGameButton != null) startGameButton.SetActive(false);
            yield return fader.FadeIn(fadeTime);
        }

    }
}