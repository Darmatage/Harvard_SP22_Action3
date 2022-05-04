using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPlay : MonoBehaviour
{
    public int primeInt = 1;
    // public GameObject Logo;
  //  public bool particlePlaying;
    public bool isEmitting;
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

      if (primeInt == 1){
        GameObject LetterG;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        // particlePlaying = true;
        // ps.(Stop);
        // particlePlaying = false;
        Debug.Log("Letter G");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 2){
        GameObject Lettera;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter a");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 3){
        GameObject Letterf1a;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter f1a");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 4){
        GameObject Letterf1b;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter f1b");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 5){
        GameObject Letterf2a;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter f2a");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 6){
        GameObject Letterf2b;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter f2b");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 7){
        GameObject Lettere;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter e");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
      else if (primeInt == 8){
        GameObject Letterr;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.Play();
        Debug.Log("Letter r");
        if (isEmitting == false){
                primeInt = primeInt +1;
                Debug.Log("int update");
        }
      }
    }
}
