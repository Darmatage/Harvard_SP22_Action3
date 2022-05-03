using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureManager : MonoBehaviour
{
    public const int MARBLE_MIN_HEAT = 0;
    public const int MARBLE_MAX_HEAT = 30;
    public const int HOT_STATE_MIN_HEAT = 31;
    public const int HOT_STATE_MAX_HEAT = 100;

    // playerHeat
    public int startHeat = 30;
    public int Heat = 30;

    public bool isHeatingUp;

    //public GameObject deathEffect;
    public Image HeatBar;
    public Color HeatColor = new Color(0.3f, 0.8f, 0.3f);
    public Color unHeatColor = new Color(0.8f, 0.3f, 0.3f);

    //temporary time variables:
    public float timeToDamage = 5f;
    private float theTimer;
    public int damageAmt = 10;

    private void Start()
    {
        Heat = startHeat;
        theTimer = timeToDamage;
    }

    public void adjustHeat(int amount) {
        Heat += amount;
    }

    public void Die()
    {
		Heat = 0;
        Debug.Log("You Died");

    }
}
