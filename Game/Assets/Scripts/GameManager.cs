using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool hasJumpBoots = false;
    public bool isReady = true;
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
    private Slider _cooldownBar;
    public float cooldown;
    public float maxCooldown = 10.0f;



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
        _cooldownBar.value = cooldown;        
        yield return new WaitForSeconds(4);
        isReady = true;
    }

    IEnumerator hasJumpBootsWait()
    {
        yield return new WaitForSeconds(0.5f);
        isReady = false;
    }

    private void Start()
    {
        _cooldownBar.maxValue = maxCooldown;
        // _cooldownBar.value = maxCooldown;
    }

    private void Update()
    {
        if (cooldown < maxCooldown && hasJumpBoots && !isReady)
        {
            cooldown += Time.deltaTime * 2.21f;
            _cooldownBar.value = cooldown;
        }
    }

}
