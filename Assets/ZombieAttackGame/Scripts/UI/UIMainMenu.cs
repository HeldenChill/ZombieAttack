using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI
{
    public class UIMainMenu : MonoBehaviour
    {
        public Action<bool> OnGameStart;
        public void OnStartButtonClick()
        {
            SetActive(false);
            OnGameStart?.Invoke(true);
        }

        public void OnOptionButtonClick()
        {
            UIManager.Inst.OpenUI(UIManager.TypeUI.UIOptionMenu);
        }

        public void OnExitButtonClick()
        {
            Debug.Log("Exit Clicked");
        }

        public void SetActive(bool p)
        {
            gameObject.SetActive(p);
        }
    }
}
