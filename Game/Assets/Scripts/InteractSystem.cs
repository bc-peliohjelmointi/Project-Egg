using StarterAssets;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UI;
using DoorCode;

public class InteractSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private Animator openandclose;
    private GameObject door;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        open = false;
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
                            openandclose = door.GetComponent<Animator>();
                            StartCoroutine(openingandclosing());
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

    IEnumerator openingandclosing()
    {
        if (open == false)
        {
            openandclose.Play("Opening");
            InteractUI.ActivateInfoText(false);
            yield return new WaitForSeconds(0.5f);
            open = true;
        }
        else if (open == true)
        {
            openandclose.Play("Closing");
            InteractUI.ActivateInfoText(false);
            yield return new WaitForSeconds(0.5f);
            open = false;
        }
        yield return new WaitForSeconds(0.5f);
    }
}
