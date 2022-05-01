using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] GameObject uiPauseContainer = null;
        //[SerializeField] GameObject uiGameOverContainer = null;
        private bool isGamePaused = false;

        private void OnEnable()
        {
            EventHandler.EscapeActionEvent += EscapeToggle;
            EventHandler.GameOverActionEvent += GameOverUI;
            EventHandler.ActiveGameUI += GamePausedToggle;
        }

        private void OnDisable()
        {
            EventHandler.EscapeActionEvent -= EscapeToggle;
            EventHandler.GameOverActionEvent -= GameOverUI;
            EventHandler.ActiveGameUI -= GamePausedToggle;
        }

        private void Start()
        {
            uiPauseContainer.SetActive(false);
            //uiGameOverContainer.SetActive(false);
        }
        private void Update()
        {
            if(isGamePaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void OpenMenuHUDButton()
        {
            //MenuToggle();
        }

        public void ClosePauseUI()
        {
            MenuToggle(uiPauseContainer);
        }
        private void GameOverUI()
        {
            //MenuToggle(uiGameOverContainer);
            Debug.Log("Game Over");
        }

        private void EscapeToggle()
        {
            MenuToggle(uiPauseContainer);

            // if (!uiGameOverContainer.activeSelf)
            // {
            //     if(isGamePaused)
            //     {
            //         uiPauseContainer.SetActive(false);
            //         isGamePaused = false;
            //     }
            //     else 
            //     {
            //         Debug.Log("Open Pause UI");
            //         uiPauseContainer.SetActive(true);
            //         isGamePaused = true;
            //     }
            //     EventHandler.CallActiveGameUI(isGamePaused);
            //     Debug.Log("Escape toggle");

            //     }
        }

        private void CloseAllUI()
        {

            uiPauseContainer.SetActive(false);
            isGamePaused = false;
            EventHandler.CallActiveGameUI(isGamePaused);
        }

        private void MenuToggle(GameObject uiContainer)
        {
            uiContainer.SetActive(!uiContainer.activeInHierarchy);
            if (isGamePaused)
            {
                isGamePaused = false;
            }
            else
            {
                isGamePaused = true;
            }
            EventHandler.CallActiveGameUI(isGamePaused);
        }

        private void GamePausedToggle(bool toggleTo)
        {
            isGamePaused = toggleTo;
            Debug.Log("IsGamePause: " + isGamePaused);
        }

    }
}