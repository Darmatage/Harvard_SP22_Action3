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
            SceneManager.LoadScene("LoadScene1");
        }

        public void RestartLevel() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGameButtonUI()
        {
            SceneManager.LoadScene("Scene_0_MainMenu");
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
