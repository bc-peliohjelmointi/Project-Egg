using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI;

namespace DoorCode
{
    public class KeyPad : MonoBehaviour
    {
        public string inputCode;

        [SerializeField]
        TextMeshProUGUI _screenText;

        [SerializeField]
        List<AudioClip> _audioClips = new List<AudioClip>();

        

        // Start is called before the first frame update
        void Start() { }

        // Update is called once per frame
        void Update() { }

        public void ButtonPress(int num)
        {
            if (inputCode.Length < 6)
            {
                inputCode += num.ToString();
                _screenText.text = inputCode;
            }

		    GetComponent<AudioSource>().PlayOneShot(_audioClips[0]);
        }

        public void ClearButtonPress()
        {
            inputCode = "";
            _screenText.text = inputCode;
        }

        public void EnterButtonPress()
        {
            if (inputCode == DoorCodeGenerator.fullCode)
            {
                DoorCodeGenerator.codeAccepted = true;
                GetComponent<AudioSource>().PlayOneShot(_audioClips[1]);
                SetKeyPadUIActive(false);
            }
            else
            {
                Debug.Log("Wrong Code");
                inputCode = "";
                _screenText.text = inputCode;
            }
        }

        public void SetKeyPadUIActive(bool value)
        {
            UIManager.ChangeCursorState(value);
            InteractUI.ActivateKeyPadUI(value);
        }
    }
}
