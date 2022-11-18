using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DoorCode
{
    public class KeyPad : MonoBehaviour
    {
        public string inputCode;

        [SerializeField]
        TextMeshProUGUI _screenText;

        

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
                Debug.Log("Correct Code");
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
            UIManager.Instance.ChangeCursorState(value);
            UIManager.Instance.keyPadUI.SetActive(value);
        }
    }
}
