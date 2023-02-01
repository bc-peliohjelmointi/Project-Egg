using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class FinalMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject finalMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            finalMessage.SetActive(true);
            UIManager.ChangeCursorState(true);
        }
    }
}
