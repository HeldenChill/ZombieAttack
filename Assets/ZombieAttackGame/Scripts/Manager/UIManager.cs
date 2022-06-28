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
        [SerializeField]
        private UIRestartMenu uIRestartMenu;

        public UIGamePlay UIGameplay { get => uiGameplay;}
        public UIMainMenu UIMainmenu { get => uiMainmenu;}
        public UIOptionMenu UIOptionmenu { get => uiOptionmenu;}
        public UIInformation UIInformation { get => uIInformation;}
        public UIRestartMenu UIRestartMenu { get => uIRestartMenu;}

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
            UIMainmenu.OnGameStart += OnGameStart;
        }

        public void OpenUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    UIGameplay.SetActive(true);
                    break;
                case TypeUI.UIMainMenu:
                    UIMainmenu.SetActive(true);
                    break;
                case TypeUI.UIOptionMenu:
                    UIOptionmenu.SetActive(true);
                    break;
            }
        }

        public void CloseUI(TypeUI type)
        {
            switch (type)
            {
                case TypeUI.UIGamePlay:
                    UIGameplay.SetActive(false);
                    break;
                case TypeUI.UIMainMenu:
                    UIMainmenu.SetActive(false);
                    break;
                case TypeUI.UIOptionMenu:
                    UIOptionmenu.SetActive(false);
                    break;
            }
        }
        private void OnGameStart(bool p)
        {
            GameManager.Inst.GameStarted = p;
            UIInformation.StartWave();
        }

        private void OnDisable()
        {
            UIMainmenu.OnGameStart -= OnGameStart;
        }
    }
}