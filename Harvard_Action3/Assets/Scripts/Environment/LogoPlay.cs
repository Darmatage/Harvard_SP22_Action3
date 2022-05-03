using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPlay : MonoBehaviour
{
    public int primeInt = 1;
    // public GameObject Logo;
    public GameObject LetterG;
    public GameObject Lettera;
    public GameObject Letterf1a;
    public GameObject Letterf1b;
    public GameObject Letterf2a;
    public GameObject Letterf2b;
    public GameObject Lettere;
    public GameObject letterr;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Logo");
    }

    // Update is called once per frame
    void Update()
    {
      primeInt = primeInt +1;
      if (primeInt == 1){
        GameObject LetterG;
        Debug.Log("Letter G");
      }
      else if (primeInt == 2){
        GameObject Lettera;
        Debug.Log("Letter a");
      }
      else if (primeInt == 3){
        GameObject Letterf1a;
        Debug.Log("Letter f1a");
      }
      else if (primeInt == 4){
        GameObject Letterf1b;
        Debug.Log("Letter f1b");
      }
      else if (primeInt == 5){
        GameObject Letterf2a;
        Debug.Log("Letter f2a");
      }
      else if (primeInt == 6){
        GameObject Letterf2b;
        Debug.Log("Letter f2b");
      }
      else if (primeInt == 7){
        GameObject Lettere;
        Debug.Log("Letter e");
      }
      else if (primeInt == 8){
        GameObject Letterr;
        Debug.Log("Letter r");
      }
    }
}
