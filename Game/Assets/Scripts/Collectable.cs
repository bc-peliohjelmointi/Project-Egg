using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public static Collectable Instance;
    public float jumpMultiplier = 1.0f;
    public float minJumpMultiplier;
    public float maxJumpMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        switch (this.tag)
        {
            case "Jumpboots":
                // other.GetComponent<ThirdPersonController>().hasJetpack = true;
                jumpMultiplier = Random.Range(minJumpMultiplier, maxJumpMultiplier);
                Destroy(gameObject);
                break;
        }
    }

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

    // Update is called once per frame
    void Update() { }
}
