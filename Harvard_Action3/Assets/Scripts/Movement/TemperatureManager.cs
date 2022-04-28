using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureManager : MonoBehaviour
{
    // playerHeat
    public int startHeat = 100;
    public int Heat = 100;

    //public GameObject deathEffect;
    public Image HeatBar;
    public Color HeatColor = new Color(0.3f, 0.8f, 0.3f);
    public Color unHeatColor = new Color(0.8f, 0.3f, 0.3f);

    //temporary time variables:
    public float timeToDamage = 5f;
    private float theTimer;
    public int damageAmt = 10;

	// connect to oxygenThruster:
	//public Oxygen_thruster OxyThrust;

    private void Start()
    {
        // Heat = startHeat;
        theTimer = timeToDamage;
    }

    // void FixedUpdate()
    // {
    //     Debug.Log("At top of fixed update");
	// 	// if (Input.GetKeyDown(KeyCode.E))
	// 	// {
	// 		 // timeToDamage = .05f;
	// 	// }
	// 	// if (Input.GetKeyUp(KeyCode.E))
	// 	// {
	// 		// timeToDamage = 5f;
	// 	// }
	// 	// theTimer = timeToDamage;

    //     theTimer -= Time.deltaTime;

    //     if (theTimer <= 0)
    //     {
    //         TakeDamage(damageAmt);
    //         theTimer = timeToDamage;
    //     }
    // }

    public void adjustHeat(int amount) {
        Heat += amount;
    }

    // public void SetColor(Color newColor)
    // {
    //     HeatBar.GetComponent<Image>().color = newColor;
    // }

    // public void TakeDamage(int amount)
    // {
    //     Heat -= amount;
    //     // HeatBar.fillAmount = Heat / startHeat;
    // }

    // public void FilterOverTime (int filterAmount, int duration)
    // {
    //     StartCoroutine(FilterOverTimeCoroutine(filterAmount, duration));
    // }
    //
    // public void SpendOverTime(int spendAmount, int duration)
    // {
    //     StartCoroutine(SpendOverTimeCoroutine(spendAmount, duration));
    // }



    public void Die()
    {
		Heat = 0;
        Debug.Log("You Died");

    }

	// reset
	public void setHeatLevel100()
	{
		Debug.Log("Temperature replenished!");
		Heat = startHeat;
		// return Ox;
	}

    // IEnumerator FilterOverTimeCoroutine(float filterAmount, float duration)
    // {
    //     float amountFiltered = 0;
    //     float filterPerLoop = filterAmount / duration;
    //     while (amountFiltered < filterAmount)
    //     {
    //         Ox += filterPerLoop;
    //         amountFiltered += filterPerLoop;
    //         yield return new WaitForSeconds(1f);
    //     }
    // }

    // IEnumerator SpendOverTimeCoroutine(float spendAmount, float duration)
    // {
    //     float amountSpent = 0;
    //     float spendPerLoop = spendAmount / duration;
    //     while (amountSpent < spendAmount)
    //     {
    //         Ox += spendPerLoop;
    //         Debug.Log(Ox.ToString());
    //         amountSpent += spendPerLoop;
    //         yield return new WaitForSeconds(1f);
    //     }
    // }


}
