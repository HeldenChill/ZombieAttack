using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Inst;
        
        [SerializeField]
        private UIGamePlay uiGameplay;
        [SerializeField]
        private UIMainMenu uiMainmenu;
        [SerializeField]
        private UIOptionMenu uiOptionmenu;

        public enum TypeUI
        {
            UIGamePlay = 0,
            UIMainMenu = 1,
            UIOptionMenu = 2
        }
        private void Awake()
        {
            if(Inst == null)
            {
                Inst = this;                
                return;
            }
            Destroy(gameObject);
        }

        private void OnEnable()
        {
            uiMainmenu.OnGameStart += OnGameStart;
        }

        public void OpenUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    uiGameplay.SetActive(true);
                    break;
                case TypeUI.UIMainMenu:
                    uiMainmenu.SetActive(true);
                    break;
                case TypeUI.UIOptionMenu:
                    uiOptionmenu.SetActive(true);
                    break;
            }
        }

        public void CloseUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    uiGameplay.SetActive(false);
                    break;
                case TypeUI.UIMainMenu:
                    uiMainmenu.SetActive(false);
                    break;
                case TypeUI.UIOptionMenu:
                    uiOptionmenu.SetActive(false);
                    break;
            }
        }
        private void OnGameStart(bool p)
        {
            GameManager.Inst.GameStarted = p;
        }

        private void OnDisable()
        {
            uiMainmenu.OnGameStart -= OnGameStart;
        }
    }
}