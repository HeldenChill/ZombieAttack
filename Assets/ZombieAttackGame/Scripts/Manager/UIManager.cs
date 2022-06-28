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
        [SerializeField]
        private UIInformation uIInformation;

        public UIGamePlay UiGameplay { get => uiGameplay;}
        public UIMainMenu UiMainmenu { get => uiMainmenu;}
        public UIOptionMenu UiOptionmenu { get => uiOptionmenu;}
        public UIInformation UIInformation { get => uIInformation;}

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
            UiMainmenu.OnGameStart += OnGameStart;
        }

        public void OpenUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    UiGameplay.SetActive(true);
                    break;
                case TypeUI.UIMainMenu:
                    UiMainmenu.SetActive(true);
                    break;
                case TypeUI.UIOptionMenu:
                    UiOptionmenu.SetActive(true);
                    break;
            }
        }

        public void CloseUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    UiGameplay.SetActive(false);
                    break;
                case TypeUI.UIMainMenu:
                    UiMainmenu.SetActive(false);
                    break;
                case TypeUI.UIOptionMenu:
                    UiOptionmenu.SetActive(false);
                    break;
            }
        }
        private void OnGameStart(bool p)
        {
            GameManager.Inst.GameStarted = p;
        }

        private void OnDisable()
        {
            UiMainmenu.OnGameStart -= OnGameStart;
        }
    }
}