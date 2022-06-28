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
    }
}
