using StarterAssets;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

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
                    UIManager.Instance.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        UIManager.Instance.ChangeCursorState(true);
                        hit.collider.GetComponent<DoorCode.KeyPad>().SetKeyPadUIActive(true);
                    }
                    break;
                case "Jumpboots":
                    UIManager.Instance.ActivateInfoText(true);
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
                    UIManager.Instance.ActivateInfoText(true);
                    if (_input.interact)
                    {
                        door = hit.collider.gameObject;
                        openandclose = door.GetComponent<Animator>();
                        StartCoroutine(openingandclosing());
                    }

                    break;

                default:
                    UIManager.Instance.ActivateInfoText(false);
                    break;
            }
        }
    }

    IEnumerator openingandclosing()

    {

        if (open == false)
        {
            openandclose.Play("Opening");
            UIManager.Instance.ActivateInfoText(false);
            yield return new WaitForSeconds(0.5f);
            open = true;
        }
        else if (open == true)
        {
            openandclose.Play("Closing");
            UIManager.Instance.ActivateInfoText(false);
            yield return new WaitForSeconds(0.5f);
            open = false;
        }
        yield return new WaitForSeconds(0.5f);
    }
}