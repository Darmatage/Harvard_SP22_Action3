using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      private GameObject player;
      private TemperatureManager temperatureManager;
      public static int playerHeat = 100;
      public int StartPlayerHeat = 100;
      public GameObject textHeat;
      public GameObject heatBar;
      public static int gotTokens = 0;
      public GameObject tokensText;

      public bool isDefending = false;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;

      void Start()
      {
            player = GameObject.FindWithTag("Player");
            playerHeat = player.GetComponent<TemperatureManager>().Heat;
            temperatureManager = player.GetComponent<TemperatureManager>();

            sceneName = SceneManager.GetActiveScene().name;
            //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
                  playerHeat = StartPlayerHeat;
            //}

            if(SceneManager.GetActiveScene().name == "Scene_1_Level1")
            {
                  gotTokens = 0;
            }

            updateStatsDisplay();


      }

      public void playerGetTokens(int newTokens){
            Debug.Log("playerGetTokens = " + gotTokens + " " + newTokens);
            gotTokens += newTokens;
            updateStatsDisplay();
      }

      public void playerGetHit(int damage){

           if (isDefending == false){
                  playerHeat -= damage;
                  if (playerHeat >=0){
                        updateStatsDisplay();
                  }
                  player.GetComponent<PlayerHurt>().playerHit();
            }

           if (playerHeat >= StartPlayerHeat){
                  playerHeat = StartPlayerHeat;
            }

           if (playerHeat <= 0){
                  playerHeat = 0;
                  playerDies();
            }
      }

      public void updateStatsDisplay(){
            Text textHeatTemp = textHeat.GetComponent<Text>();
            textHeatTemp.text = "HEAT: " + temperatureManager.Heat; //.ToString();

            Text tokensTextTemp = tokensText.GetComponent<Text>();
            tokensTextTemp.text = "FRIT: " + gotTokens;

            Image heatBarTemp = heatBar.GetComponent<Image>();
            heatBarTemp.fillAmount = temperatureManager.Heat/100;
            // Debug.Log("heat level is " + temperatureManager.Heat);
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            Debug.Log("You are dead!");
            //StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      // public void StartGame() {
      //       Debug.Log("Start Game?");
      //       SceneManager.LoadScene("Scene_1_Level1");
      // }

      public void RestartGame() {
            SceneManager.LoadScene("Scene_1_Level1");
            playerHeat = StartPlayerHeat;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public int GetTotalTokens()
      {
            return gotTokens;
      }

      // public void Credits() {
      //       SceneManager.LoadScene("Credits");
      // }
}
