using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class InteractSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForColliders();
    }

    void CheckForColliders()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 6, Color.red);
        if (Physics.Raycast(ray, out hit, 6f))
        {
            switch (hit.collider.tag)
            {
                case "Keypad":
                    UIManager.Instance.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        hit.collider.GetComponent<DoorCode.KeyPad>().SetKeyPadUIActive(true);
                    }
                    break;
                default:
                    UIManager.Instance.ActivateInfoText(false);
                    break;
            }

        }
    }
}