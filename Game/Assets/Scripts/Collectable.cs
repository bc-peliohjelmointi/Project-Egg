using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (this.tag)
        {
            case "Jumpboots":
                // other.GetComponent<ThirdPersonController>().hasJetpack = true;
                GameManager.Instance.hasJumpBoots = true;
                GameManager.Instance.jumpMultiplier = Random.Range(GameManager.Instance.minJumpMultiplier, GameManager.Instance.maxJumpMultiplier);

                Destroy(gameObject);
                break;
        }
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
