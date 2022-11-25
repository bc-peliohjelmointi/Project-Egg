using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private RectMask2D _JumpBootsCooldownMask;
    public GameObject keyPadUI;
    public GameObject interactInfoText;
    public bool hasUIOpen = false;
    float originalSize;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void ChangeCursorState(bool newState)
    {
        hasUIOpen = newState;
        Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = newState;
        GameObject
            .Find("PlayerArmature")
            .GetComponent<StarterAssets.ThirdPersonController>()
            .LockCameraPosition = newState;
    }

    public void ActivateInfoText(bool value)
    {
        interactInfoText.SetActive(value);
    }

    // Method to close all ui
    public void CloseAllUI()
    {
        hasUIOpen = false;
        ChangeCursorState(false);
        keyPadUI.SetActive(false);
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

    private void Start()
    {
        originalSize = _JumpBootsCooldownMask.rectTransform.rect.width;
        UpdateJumpBootsCooldown(4.0f);
    }

    public void UpdateJumpBootsCooldown(float cooldown)
    {
        _JumpBootsCooldownMask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * cooldown);
    }
}
