using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class LoadScene1 : MonoBehaviour {
       public int primeInt = 1;         // This integer drives game progress!
       public Text IntroText;
       public Text GoalText;
       public GameObject TextDisplay;
       public GameObject ArtBG1;
       public GameObject skipIntroButton;
       public GameObject NextScene1Button;
       public GameObject nextButton;
      //public GameHandler gameHandler;
      //public AudioSource audioSource;
       private bool allowSpace = true;

void Start(){         // initial visibility settings
       TextDisplay.SetActive(false);
       ArtBG1.SetActive(true);
       skipIntroButton.SetActive(true);
       NextScene1Button.SetActive(false);
       nextButton.SetActive(true);
       Debug.Log("Start Program");
  }

void Update(){         // use spacebar as Next button
       if (allowSpace == true){
               if (Input.GetKeyDown("space")){
                      talking();
                      Debug.Log("space");
               }
       }
  }

//Story Units:
public void talking(){         // main story function. Players hit next to progress to next int
       primeInt = primeInt + 1;
       if (primeInt == 1){
               // AudioSource.Play();
       }
       else if (primeInt == 2){
         Debug.Log("Prime Int = 2");
               TextDisplay.SetActive(true);
               IntroText.text = "The Glass Dragon is the spirit of the studio. A being of light, heat, and color, it resides in the furnace, just beyond the reach of man. ";
               GoalText.text = "";
       }
      else if (primeInt == 3){
        Debug.Log("PrimeInt = 3");
                IntroText.text = "All glass desires to join the Dragon, but much of it is destined instead to become Art. ";
                GoalText.text = "";
       }
      else if (primeInt == 4){
                IntroText.text = "All glass desires to join the Dragon, but much of it is destined instead to become Art. ";
                GoalText.text = "";
       }
      else if (primeInt == 5){
                IntroText.text = "It is the lost, discarded, broken glass - sacrificed to Art - that join the Dragon. ";
                GoalText.text = "";
       }
      else if (primeInt == 6){
                IntroText.text = "You are one such piece - a simple marble, a beginner’s practice. ";
                GoalText.text = "";
       }
      else if (primeInt == 7){
                IntroText.text = "Learn what it means to be glass, explore the studio, and pick up beautiful offerings of color on your way to reach the Dragon! ";
                GoalText.text = "";
                primeInt = primeInt + 1;
      }
      else if (primeInt == 8){
                skipIntroButton.SetActive(false);
                NextScene1Button.SetActive(true);
                nextButton.SetActive(false);
                IntroText.text = "";
                GoalText.text = "Level 1: Hot, glass melts, drips, becomes malleable. When it cools it hardens into a marble, which rolls and jumps. But if hot glass gets too cold, it shatters! ";
      }

}
  public void SkipIntroFunct(){
    primeInt = 7;
  }
}

// Using Jason's code exactly as suggested - doesn't seem to work either?
// using UnityEngine;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// using UnityEngine.Audio;
//
// public class LoadScene1 : MonoBehaviour {
//        public int primeInt = 1;         // This integer drives game progress!
//     //   public Text Char1name;
//        public Text Char1speech; // Intro Text
// //       public Text Char2name;
//        public Text Char2speech; // Goal Text
//       //public Text Char3name;
//       //public Text Char3speech;
//        public GameObject DialogueDisplay; //Text BG
//       // public GameObject ArtChar1;
//       //public GameObject ArtChar2;
//        public GameObject ArtBG1; //studio
//        public GameObject Choice1a; // Skip Intro
//     //   public GameObject Choice1b;
//        public GameObject NextScene1Button; // Play Level 1
//     //   public GameObject NextScene2Button;
//        public GameObject nextButton; // Next
//       //public GameHandler gameHandler;
//       //public AudioSource audioSource;
//        private bool allowSpace = true;
//
// void Start(){         // initial visibility settings
//        DialogueDisplay.SetActive(false);
//   //     ArtChar1.SetActive(false);
//        ArtBG1.SetActive(true);
//        Choice1a.SetActive(true);
//   //     Choice1b.SetActive(false);
//        NextScene1Button.SetActive(false);
//   //     NextScene2Button.SetActive(false);
//        nextButton.SetActive(true);
//   }
//
// void Update(){         // use spacebar as Next button
//        if (allowSpace == true){
//                if (Input.GetKeyDown("space")){
//                       talking();
//                }
//        }
//   }
//
// //Story Units:
// public void talking(){         // main story function. Players hit next to progress to next int
//        primeInt = primeInt + 1;
//        if (primeInt == 1){
//                // AudioSource.Play();
//        }
//        else if (primeInt == 2){
//                //ArtChar1.SetActive(true);
//                DialogueDisplay.SetActive(true);
//               // Char1name.text = "Jeda";
//                Char1speech.text = "Wakey wakey, human.";
//               // Char2name.text = "";
//                Char2speech.text = "";
//        }
//       else if (primeInt ==3){
//           //     Char1name.text = "";
//                Char1speech.text = "";
//             //   Char2name.text = "You";
//                Char2speech.text = "Wuh..? What happened?";
//                //gameHandler.AddPlayerStat(1);
//        }
//       else if (primeInt == 4){
//           //     Char1name.text = "Jeda";
//                Char1speech.text = "I know I did not hit you that hard.";
//           //     Char2name.text = "";
//                Char2speech.text = "";
//        }
//       else if (primeInt == 5){
//           //     Char1name.text = "";
//                Char1speech.text = "";
//           //     Char2name.text = "You";
//                Char2speech.text = "Hit me? Why?";
//                //gameHandler.AddPlayerStat(1);
//        }
//       else if (primeInt == 6){
//           //     Char1name.text = "Jeda";
//                Char1speech.text = "I am searching for a fugitive. Ragu Fahn.";
//           //     Char2name.text = "";
//                Char2speech.text = "";
//        }
//       else if (primeInt ==7){
//           //     Char1name.text = "";
//                Char1speech.text = "";
//           //     Char2name.text = "You";
//                Char2speech.text = "Why do you think I know anything?";
//        }
//       else if (primeInt == 8){
//           //     Char1name.text = "Jeda";
//                Char1speech.text = "Do not play the stupid. You will take me to him.";
//           //     Char2name.text = "";
//                Char2speech.text = "";
//                // Turn off "Next" button, turn on "Choice" buttons
//                nextButton.SetActive(false);
//                allowSpace = false;
//                Choice1a.SetActive(true); // function Choice1aFunct()
//         //       Choice1b.SetActive(true); // function Choice1bFunct()
//        }
// // ENCOUNTER AFTER CHOICE #1
//       else if (primeInt == 100){
//       //         Char1name.text = "Jeda";
//                Char1speech.text = "Then you are no use to me, and must be silenced.";
//       //         Char2name.text = "";
//                Char2speech.text = "";
//        }
//       else if (primeInt == 101){
//     //           Char1name.text = "Jeda";
//                Char1speech.text = "Come back here! Do not think you can hide from me!";
//       //         Char2name.text = "";
//                Char2speech.text = "";
//                nextButton.SetActive(false);
//                allowSpace = false;
//                NextScene1Button.SetActive(true);
//        }
//
//       else if (primeInt == 200){
//       //         Char1name.text = "Jeda";
//                Char1speech.text = "Do not think you can fool me, human. Where will we find him?";
//       //         Char2name.text = "";
//                Char2speech.text = "";
//        }
//       else if (primeInt == 201){
//       //         Char1name.text = "";
//                Char1speech.text = "";
//       //         Char2name.text = "You";
//                Char2speech.text = "Ragu hangs out in a rough part of town. I'll take you now.";
//                nextButton.SetActive(false);
//                allowSpace = false;
//       //         NextScene2Button.SetActive(true);
//        }
//     }
//
// // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and switch scenes)
//        public void Choice1aFunct(){
//       //         Char1name.text = "";
//                Char1speech.text = "";
//       //         Char2name.text = "You";
//                Char2speech.text = "I don't know what you're talking about!";
//                primeInt = 99;
//                Choice1a.SetActive(false);
//       //         Choice1b.SetActive(false);
//                nextButton.SetActive(true);
//                allowSpace = true;
//        }
//        // public void Choice1bFunct(){
//        //         Char1name.text = "";
//        //         Char1speech.text = "";
//        //         Char2name.text = "You";
//        //         Char2speech.text = "Sure, anything you want... just lay off the club.";
//        //         primeInt = 199;
//        //         Choice1a.SetActive(false);
//        //         Choice1b.SetActive(false);
//        //         nextButton.SetActive(true);
//        //         allowSpace = true;
//        // }
//
//        public void SceneChange1(){
//               SceneManager.LoadScene("Scene2a");
//        }
//        public void SceneChange2(){
//                SceneManager.LoadScene("Scene2b");
//        }
// }
