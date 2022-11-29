using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool hasJumpBoots = false;
    public bool isReady = false;
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

    [SerializeField]
    private Image _cooldownBar;

    public float cooldown
    {
        get { return _cooldown; }
        set
        {
            if (value >= 0)
                _cooldown = value;
            else
                Debug.LogWarning("You cannot set cooldown smaller than 0");
        }
    }

    private float _cooldown;
    public float maxCooldown = 1.0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void startJumpBootsCooldown()
    {
        StartCoroutine(jumpBootsCooldown());
        StartCoroutine(hasJumpBootsWait());
    }

    IEnumerator jumpBootsCooldown()
    {
        cooldown = 0;
        _cooldownBar.fillAmount = cooldown;
        yield return new WaitForSeconds(4);
        isReady = true;
    }

    IEnumerator hasJumpBootsWait()
    {
        yield return new WaitForSeconds(0.5f);
        isReady = false;
    }

    private void Update()
    {
        if (cooldown >= maxCooldown) isReady = true;

        if (cooldown < maxCooldown && hasJumpBoots && !isReady)
        {
            cooldown += Time.deltaTime / 3.5f;
            _cooldownBar.fillAmount = cooldown / maxCooldown;
        }
    }
}
