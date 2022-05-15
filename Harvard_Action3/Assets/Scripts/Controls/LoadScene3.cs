using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LoadScene3 : MonoBehaviour {
       public int primeInt = 1;         // This integer drives game progress!
       public Text IntroText;
       public Text levelTitle;
//       public Text GoalText;
       public GameObject TextDisplay;
       public GameObject ArtBG1;
//       public GameObject skipIntroButton;
       public GameObject NextScene1Button;
//       public GameObject nextButton;
      //public GameHandler gameHandler;
      //public AudioSource audioSource;
       private bool allowSpace = true;

void Start(){         // initial visibility settings
       // TextDisplay.SetActive(false);
       ArtBG1.SetActive(true);
       TextDisplay.SetActive(true);
       levelTitle.text = "Level 3:";
       IntroText.text = " • Hot glass can be blown into a bubble, floating, lighter than air. \n \n" + " • You can soar to great heights, but a bubble is fragile and shatters easily! ";
//       skipIntroButton.SetActive(true);
       NextScene1Button.SetActive(true);
//       nextButton.SetActive(true);
       Debug.Log("Start Program");
  }

void Update(){         // use spacebar as Next button
       if (allowSpace == true){
               if (Input.GetKeyDown("space")){
                      SceneChange3();
                      Debug.Log("space");
               }
       }
  }

//Story Units:
// public void talking(){         // main story function. Players hit next to progress to next int
//        primeInt = primeInt + 1;
//        if (primeInt == 1){
//                // AudioSource.Play();
//        }
//        else if (primeInt == 2){
//          Debug.Log("Prime Int = 2");
//                TextDisplay.SetActive(true);
//                IntroText.text = "The Glass Dragon is the spirit of the studio. A being of light, heat, and color, it resides in the furnace, just beyond the reach of man. ";
//                GoalText.text = "";
//        }
//       else if (primeInt == 3){
//         Debug.Log("PrimeInt = 3");
//                 IntroText.text = "All glass desires to join the Dragon, but much of it is destined instead to become Art. ";
//                 GoalText.text = "";
//        }
//       else if (primeInt == 4){
//                 IntroText.text = "All glass desires to join the Dragon, but much of it is destined instead to become Art. ";
//                 GoalText.text = "";
//        }
//       else if (primeInt == 5){
//                 IntroText.text = "It is the lost, discarded, broken glass - sacrificed to Art - that join the Dragon. ";
//                 GoalText.text = "";
//        }
//       else if (primeInt == 6){
//                 IntroText.text = "You are one such piece - a simple marble, a beginner’s practice. ";
//                 GoalText.text = "";
//        }
//       else if (primeInt == 7){
//                 IntroText.text = "Learn what it means to be glass, explore the studio, and pick up beautiful offerings of color on your way to reach the Dragon! ";
//                 GoalText.text = "";
//       }
//       else if (primeInt == 8){
//                 skipIntroButton.SetActive(false);
//                 NextScene1Button.SetActive(true);
//                 nextButton.SetActive(false);
//                 IntroText.text = "";
//                 GoalText.text = "Level 1: Hot, glass melts, drips, becomes malleable. When it cools it hardens into a marble, which rolls and jumps. But if hot glass gets too cold, it shatters! ";
//       }
//
//}
    public void SceneChange3(){
       SceneManager.LoadScene("Scene_3_Level3");
      }
}
