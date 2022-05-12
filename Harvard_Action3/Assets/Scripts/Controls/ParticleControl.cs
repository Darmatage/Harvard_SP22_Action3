using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Control
{
    public class ParticleControl : MonoBehaviour
    {
        [SerializeField] int startingCoreParticles = 8;
        [SerializeField] GameObject coreParticlePrefab = null;
        [SerializeField] GameObject AdditionalParticlePrefab = null;

        private List<GameObject> particleList;

        private bool isDoubled = false;

        private bool activateDouble = false;

        private void OnEnable()
        {
            EventHandler.AddParticleEvent += AddNewParticle;
            EventHandler.DoubleSizeEvent += ActivateDoubleEvent;
            EventHandler.HalfSizeEvent += HalfParticle;
        }

        private void OnDisable()
        {
            EventHandler.AddParticleEvent -= AddNewParticle;
            EventHandler.DoubleSizeEvent -= ActivateDoubleEvent;
            EventHandler.HalfSizeEvent -= HalfParticle;
        }

        private void Start()
        {
            particleList = new List<GameObject>();
            CoreParticleSetup();
        }

        public bool GetIsDouble()
        {
            return isDoubled;
        }

        public void SetIsDouble(bool state)
        {
            isDoubled = state;
        }

        private void CoreParticleSetup()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < startingCoreParticles; i++)
            {
                var coreParticle = Instantiate(coreParticlePrefab, transform);
                coreParticle.name = String.Format("CoreParticle_{0}", particleList.Count);
                particleList.Add(coreParticle);
            }
        }

        private void AddNewParticle()
        {
            var additionalParticle = Instantiate(AdditionalParticlePrefab, transform);
            additionalParticle.name = String.Format("AdditionalParticle_{0}", particleList.Count);
            particleList.Add(additionalParticle);

            // foreach (var item in particleList)
            // {
            //     Debug.Log(item);
            // }
        }

        private void ActivateDoubleEvent()
        {
            if(!activateDouble)
            {
                activateDouble = true;
                StartCoroutine(ExampleCoroutine());
                
            }

        }

        private IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            DoubleParticle();
        }

        private void DoubleParticle()
        {
            if(!isDoubled)
            {
                for (int i = 0; i < startingCoreParticles; i++) 
                {
                    var additionalParticle = Instantiate(AdditionalParticlePrefab, transform);
                    additionalParticle.name = String.Format("AdditionalParticle_{0}", particleList.Count);
                    particleList.Add(additionalParticle);
                }
                isDoubled = true;
            }
        }

        private void HalfParticle()
        {
            if(isDoubled)
            {
                for (int i = 0; i < startingCoreParticles; i++) 
                {
                    //Debug.Log(particleList.Count);
                    var lastParticle = GameObject.Find(particleList[particleList.Count - 1].name);
                    Debug.Log(lastParticle);
                    if(lastParticle)
                    {
                        Destroy(lastParticle);
                        particleList.RemoveAt(particleList.Count - 1);
                    }
                }
                isDoubled = false;
                activateDouble = false;
            }
        }

    }
}

