using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Control
{
    public class PlayerShatterControl : MonoBehaviour
    {
        [SerializeField] GameObject solidContainer = null;
        [SerializeField] GameObject particleContainer = null;
        [SerializeField] Transform playerTransform;
        [SerializeField] ParticleSystem playerDeathParticleSystem;

        private bool isPlayerDead = false;

        private void OnEnable()
        {
            EventHandler.PlayerDeathEvent += DeathSequence;
        }

        private void OnDisable()
        {
            EventHandler.PlayerDeathEvent -= DeathSequence;
        }

        private void Update() 
        {
            if(!isPlayerDead) return;
            playerTransform.rotation = Quaternion.identity;
        }

        private void DeathSequence()
        {
            isPlayerDead = true;
            solidContainer.SetActive(false);
            particleContainer.SetActive(false);
            //StartCoroutine(BreakPause());
            StartCoroutine(RestartLevel());
        }
        IEnumerator BreakPause()
        {
            yield return new WaitForSeconds(1.0f);
            EventHandler.CallParticleBreakEvent();
        }

        IEnumerator RestartLevel()
        {
            playerDeathParticleSystem.Play();
            yield return new WaitForSeconds(2.0f);
            playerDeathParticleSystem.Pause();
            Debug.Log("You are dead!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
