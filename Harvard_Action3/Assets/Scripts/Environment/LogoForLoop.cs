using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoForLoop : MonoBehaviour
{
  public GameObject LetterG;
  public GameObject Lettera;
  public GameObject Letterf1a;
  public GameObject Letterf1b;
  public GameObject Letterf2a;
  public GameObject Letterf2b;
  public GameObject Lettere;
  public GameObject Letterr;

  // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Logo");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gaffer = {LetterG, Lettera, Letterf1a, Letterf1b, Letterf2a, Letterf2b, Lettere, Letterr};
        foreach (GameObject i in gaffer){
          Debug.Log(i);
          ParticleSystem ps = GetComponent<ParticleSystem>();
          ps.Play();
          Debug.Log(ps.isEmitting);
        }
    }
}
