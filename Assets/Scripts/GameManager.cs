using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;

namespace ColorSwitch
{
    public class GameManager : MonoBehaviour
    {
        public int score;
        public TextMeshProUGUI text;

        #region Singleton
        public static GameManager Instance = null;
        // Use this for initialization
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

        }
        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        void Update()
        {
            text.text = "" + score;
        }

        public void ResetGame()
        {
            score = 0;
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}