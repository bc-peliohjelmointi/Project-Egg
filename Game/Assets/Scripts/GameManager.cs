using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool hasJumpBoots = false;
    public float jumpMultiplier
    {
        get { return _jumpMultiplier; }
        set
        {
            if (value >= 1)
                _jumpMultiplier = value;
            else
                Debug.LogWarning("You cannot set jumpMultiplayer smaller than 1");
        }
    }

    [SerializeField]
    private float _jumpMultiplier = 1.0f;
    public float minJumpMultiplier;
    public float maxJumpMultiplier;

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
        Cursor.lockState = newState ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = newState;
        GameObject.Find("PlayerArmature").GetComponent<StarterAssets.ThirdPersonController>().LockCameraPosition = newState;

    }

    public void startJumpBootsCooldown()
    {
        StartCoroutine(jumpBootsCooldown());
        StartCoroutine(hasJumpBootsWait());
    }

    IEnumerator jumpBootsCooldown()
    {
        yield return new WaitForSeconds(4);
        hasJumpBoots = true;
    }

    IEnumerator hasJumpBootsWait()
    {
        yield return new WaitForSeconds(0.5f);
        hasJumpBoots = false;
    }

}
