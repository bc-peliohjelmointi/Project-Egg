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

    // Start is called before the first frame update
    void Start() { }

    public void startJumpBootsCooldown()
    {
        jumpMultiplier = 1.0f;
        StartCoroutine(jumpBootsCooldown());
    }

    IEnumerator jumpBootsCooldown()
    {
        yield return new WaitForSeconds(4);
        jumpMultiplier = Random.Range(minJumpMultiplier, maxJumpMultiplier);
    }

    // Update is called once per frame
    void Update() { }
}
