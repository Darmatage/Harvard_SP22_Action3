using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    public class MenuSwitcherUI : MonoBehaviour
    {
        [SerializeField] GameObject entryPoint;

        private void Start() 
        {
            SwitchTo(entryPoint);
        }
        public void SwitchTo(GameObject toDisplay)
        {
            if(toDisplay.transform.parent != transform) return;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(child.gameObject == toDisplay);
            }
        }

        public void StartGame() {
            Debug.Log("Start Game?");
            SceneManager.LoadScene("Scene_1_Level1");
        }

        public void ExitGameButtonUI()
        {
            //savingWrapper.value.ExitGame(0, 0.5f);
            Debug.Log("Exit Game");
        }


        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

    }
}
