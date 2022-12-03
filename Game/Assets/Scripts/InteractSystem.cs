using StarterAssets;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UI;
using DoorCode;

public class InteractSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private Animator _doorAnimator;
    private GameObject door;
    public float rayLength = 2f;

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
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            switch (hit.collider.tag)
            {
                case "Keypad":
                    InteractUI.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        UIManager.ChangeCursorState(true);
                        hit.collider.GetComponent<DoorCode.KeyPad>().SetKeyPadUIActive(true);
                    }
                    break;
                case "Jumpboots":
                    InteractUI.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        GameManager.Instance.hasJumpBoots = true;
                        GameManager.Instance.jumpMultiplier = Random.Range(
                            GameManager.Instance.minJumpMultiplier,
                            GameManager.Instance.maxJumpMultiplier
                        );

                        Destroy(hit.collider.gameObject);
                    }
                    break;

                case "Door":
                    InteractUI.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        if (DoorCodeGenerator.codeAccepted)
                        {
                            door = hit.collider.gameObject;
                            _doorAnimator = door.GetComponent<Animator>();
                            if (_doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Closing"))
                            {
                                _doorAnimator.SetTrigger("Open");
                                _doorAnimator.ResetTrigger("Close");
                            }
                            else if (_doorAnimator.GetCurrentAnimatorStateInfo(0).IsName("Opening"))
                            {
                                _doorAnimator.SetTrigger("Close");
                                _doorAnimator.ResetTrigger("Open");
                            }
                        }
                        else
                        {
                            GameManager.Instance.closedText.SetActive(true);
                        }
                    }

                    break;

                default:
                    InteractUI.ActivateInfoText(false);
                    GameManager.Instance.closedText.SetActive(false);
                    break;
            }
        }
    }
}
