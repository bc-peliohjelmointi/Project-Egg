using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager : MonoBehaviour
    {

        public static bool hasUIOpen = false;


        // private void Awake()
        // {
        //     DontDestroyOnLoad(this);
        // }

        public static void ChangeCursorState(bool newState)
        {
            hasUIOpen = newState;
            Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = newState;
            GameObject
                .Find("PlayerArmature")
                .GetComponent<StarterAssets.ThirdPersonController>()
                .LockCameraPosition = newState;
        }

        // Method to close all ui
        public void CloseAllUI()
        {
            hasUIOpen = false;
            ChangeCursorState(false);
            InteractUI.ActivateKeyPadUI(false);
        }

        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadScene(int scene)
        {
            SceneManager.LoadScene(scene);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void Update()
        {
            if (hasUIOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
                {
                    CloseAllUI();
                }
            }
        }
    }
}
