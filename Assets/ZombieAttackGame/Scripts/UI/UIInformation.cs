using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class UIInformation : MonoBehaviour
    {
        [SerializeField]
        TMP_Text wave;
        [SerializeField]
        TMP_Text kill;
        [SerializeField]
        TMP_Text banner;
        [SerializeField]
        TMP_Text timer;

        float timeCounter = 3f;
        bool isStartWaveScene = false;
        public enum TypeInfo
        {
            Wave = 0,
            Kill = 1
        }

        public void SetData(TypeInfo type, int data)
        {
            switch (type)
            {
                case TypeInfo.Wave:
                    wave.text = "Wave: " + data;
                    break;
                case TypeInfo.Kill:
                    kill.text = "Kill: " + data;
                    break;
            }
        }

        public void StartWave()
        {
            isStartWaveScene = true;
            timeCounter = 3;
        }

        private void Update()
        {
            
            if (isStartWaveScene)
            {
                timer.text = "" + Mathf.Ceil(timeCounter); //TODO:Can optimize: when the value change, not every update
                timeCounter -= Time.deltaTime;
                if (timeCounter <= -1f && timeCounter > -2.5f)
                {
                    timer.gameObject.SetActive(false);
                    banner.gameObject.SetActive(true);
                    LevelManager.Inst.EnemyGenerator.IsStartSpawn = true;
                }
                else if(timeCounter <= -2.5f)
                {
                    banner.gameObject.SetActive(false);                   
                    isStartWaveScene = false;                  
                }
            }
        }
    }
}
