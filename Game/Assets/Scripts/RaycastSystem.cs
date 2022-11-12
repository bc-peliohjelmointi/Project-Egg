using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            CheckForColliders();
        }
    }

    void CheckForColliders()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        // Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.tag == "Keypad")
            {
                GameManager.Instance.ChangeCursorState(true);
                hit.collider.GetComponent<DoorCode.KeyPad>().SetKeyPadUIActive();
            }
        }
    }
}
