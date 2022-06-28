using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIRestartMenu : MonoBehaviour
    {
        [SerializeField]
        TMP_Text score;
        public void OnRestartButtonClick()
        {
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SetActive(bool p)
        {
            gameObject.SetActive(p);
        }

        public void SetScore(int score)
        {
            this.score.text = "Score: " + score;
        }
    }
}