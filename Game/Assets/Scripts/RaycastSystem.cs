using StarterAssets;
using System.Collections;
using UnityEngine;

public class RaycastSystem : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public GameObject bedroomToTunnelDoor;
    private Animator openandcloseBedroom;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        openandcloseBedroom = bedroomToTunnelDoor.GetComponent<Animator>();
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
                    GameManager.Instance.interactInfoText.SetActive(true);
                    if (_input.interact)
                    {
                        GameManager.Instance.ChangeCursorState(true);
                        hit.collider.GetComponent<DoorCode.KeyPad>().SetKeyPadUIActive();
                    }
                    break;
                
                case "Door":
                    GameManager.Instance.interactInfoText.SetActive(true);
                    if (_input.interact)

                    {
                        if (open == true)
                        {
                            StartCoroutine(openingBedroomToTunnel());
                        }
                        else
                        {
                            StartCoroutine(closingBedroomToTunnel());
                        }
                    }
                    break;


                default:
                    GameManager.Instance.interactInfoText.SetActive(false);
                    break;
            }

        }
    }
    IEnumerator openingBedroomToTunnel()
    {
        openandcloseBedroom.Play("Opening");
        open = true;
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator closingBedroomToTunnel()
    {
        openandcloseBedroom.Play("Closing");
        open = false;
        yield return new WaitForSeconds(0.5f);
    }
}
