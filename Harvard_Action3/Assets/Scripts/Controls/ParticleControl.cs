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

        private void OnEnable()
        {
            EventHandler.AddParticleEvent += AddNewParticle;
        }

        private void OnDisable()
        {
            EventHandler.AddParticleEvent -= AddNewParticle;
        }

        private void Start()
        {
            particleList = new List<GameObject>();
            CoreParticleSetup();
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

    }
}

