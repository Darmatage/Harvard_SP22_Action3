using System.Collections;
using System.Collections.Generic;
using Game.Enums;
//using Game.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.UI
{
    public class ShowHideUI : MonoBehaviour
    {
        [SerializeField] GameObject uiInventroyContainer = null;
        [SerializeField] GameObject uiCraftingContainer = null;
        [SerializeField] GameObject uiPauseContainer = null;
        [SerializeField] GameObject uiGameOverContainer = null;

        private bool isGamePaused = false;

        // private void OnEnable()
        // {
        //     EventHandler.InventoryActionEvent += InventoryToggle;
        //     EventHandler.EscapeActionEvent += EscapeToggle;
        //     EventHandler.CraftingActionEvent += CraftingToggle;
        //     EventHandler.DialogueActionEvent += DialogueToggle;
        //     EventHandler.CloseAllUIActionEvent += CloseAllUI;
        //     EventHandler.GameOverActionEvent += GameOverUI;
        //     EventHandler.ActiveGameUI += GamePausedToggle;
        // }

        // private void OnDisable()
        // {
        //     EventHandler.InventoryActionEvent -= InventoryToggle;
        //     EventHandler.EscapeActionEvent -= EscapeToggle;
        //     EventHandler.CraftingActionEvent -= CraftingToggle;
        //     EventHandler.DialogueActionEvent -= DialogueToggle;
        //     EventHandler.CloseAllUIActionEvent -= CloseAllUI;
        //     EventHandler.GameOverActionEvent -= GameOverUI;
        //     EventHandler.ActiveGameUI -= GamePausedToggle;
        // }

        // private void Start()
        // {
        //     uiDialogueContainer.ForceInit();
        //     uiInventroyContainer.SetActive(false);
        //     uiCraftingContainer.SetActive(false);
        //     uiPauseContainer.SetActive(false);
        //     uiGameOverContainer.SetActive(false);
        //     uiDialogueContainer.value.SetActive(false);
        // }

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

        public void OpenInventoryHUDButton()
        {
            MenuToggle(uiInventroyContainer);
        }

        public void ClosePauseUI()
        {
            MenuToggle(uiPauseContainer);
        }

        public void ExitGameUI()
        {
            isGamePaused = false;
            Debug.Log("Exit Game");
        }

        private void GameOverUI()
        {
            MenuToggle(uiGameOverContainer);
            Debug.Log("Game Over");
        }

        private void InventoryToggle()
        {
            MenuToggle(uiInventroyContainer);
            Debug.Log("Inventory toggle");
        }


        private void CraftingToggle()
        {
            MenuToggle(uiCraftingContainer);
            Debug.Log("Crafting toggle");
        }

        private void EscapeToggle()
        {
            if (!uiGameOverContainer.activeSelf)
            {
                if(isGamePaused)
                {
                    uiInventroyContainer.SetActive(false);
                    uiCraftingContainer.SetActive(false);
                    uiPauseContainer.SetActive(false);
                    isGamePaused = false;
                }
                else 
                {
                    Debug.Log("Open Pause UI");
                    uiPauseContainer.SetActive(true);
                    isGamePaused = true;
                }
                //EventHandler.CallActiveGameUI(isGamePaused);
                Debug.Log("Escape toggle");

                }
        }

        private void CloseAllUI()
        {
            uiInventroyContainer.SetActive(false);
            uiCraftingContainer.SetActive(false);
            uiPauseContainer.SetActive(false);
            isGamePaused = false;
            //EventHandler.CallActiveGameUI(isGamePaused);
        }

        private void MenuToggle(GameObject uiContainer)
        {
            uiContainer.SetActive(!uiContainer.activeInHierarchy);
            if(isGamePaused && uiCraftingContainer.activeSelf)
            {
                uiCraftingContainer.SetActive(false);
                isGamePaused = true;
            }
            else if (isGamePaused && !uiCraftingContainer.activeSelf)
            {
                isGamePaused = false;
            }
            else
            {
                isGamePaused = true;
            }
            //EventHandler.CallActiveGameUI(isGamePaused);
        }

        private void GamePausedToggle(bool toggleTo)
        {
            isGamePaused = toggleTo;
            Debug.Log("IsGamePause: " + isGamePaused);
        }

    }
}