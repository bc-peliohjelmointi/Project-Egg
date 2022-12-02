using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class InteractUI : UIManager
    {
        public GameObject keyPadUI;
        private static GameObject staticKeyPadUI;

        public GameObject interactInfoText;

        private static GameObject staticInteractInfoText;

        public static void ActivateInfoText(bool value)
        {
            staticInteractInfoText.SetActive(value);
        }

        public static void ActivateKeyPadUI(bool value)
        {
            staticKeyPadUI.SetActive(value);
        }

        private void Start()
        {
            staticKeyPadUI = keyPadUI;
            staticInteractInfoText = interactInfoText;
        }
    }
}
