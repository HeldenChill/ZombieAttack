using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIOptionMenu : MonoBehaviour
    {
        public void OnBackButtonClick()
        {
            SetActive(false);
        }
        public void SetActive(bool p)
        {
            gameObject.SetActive(p);
        }
    }
}