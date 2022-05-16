using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TemperatureManager : MonoBehaviour
{
    public const float MARBLE_MIN_HEAT = 0f;
    public const float MARBLE_MAX_HEAT = 50f;
    public const float MALLEABLE_STATE_MIN_HEAT = 51f;
    public const float MALLEABLE_STATE_MAX_HEAT = 100f;

    // playerHeat
    public float startHeat = 30f;
    public float Heat = 30f;

    public bool isHeatingUp;

    //public GameObject deathEffect;
    public Image HeatBar;
    public Color HeatColor = new Color(0.3f, 0.8f, 0.3f);
    public Color unHeatColor = new Color(0.8f, 0.3f, 0.3f);

    //temporary time variables:
    public float timeToDamage = 5f;
    private float theTimer;
    public float damageAmt = 10f;

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

    public float GetHeatLevel()
    {
        return Heat;
    }

    public float GetPercentage()
    {
        return 100 * GetFraction();
    }

    public float GetFraction()
    {
        return Heat / MALLEABLE_STATE_MAX_HEAT;
    }
}
