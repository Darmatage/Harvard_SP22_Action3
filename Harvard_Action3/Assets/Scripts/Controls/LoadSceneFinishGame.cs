using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadSceneFinishGame : MonoBehaviour
{
        [SerializeField] TextMeshProUGUI textField;
        private VolumeSingleton volumeSingleton;

        private void Awake() 
        {
            volumeSingleton = GameObject.FindWithTag(Tags.VOLUME_STATE_PERSISTS_TAG).GetComponent<VolumeSingleton>();
        }

        private void Start() 
        {
            RefreshUI();
        }

        private void RefreshUI()
        {
            textField.text = String.Format("Congrates! You have collected {0} Frits for the Great Glass Dragon!", volumeSingleton.GetTokenTotals());
        }
}
