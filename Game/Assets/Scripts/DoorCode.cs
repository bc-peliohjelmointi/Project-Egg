using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DoorCode : MonoBehaviour
{
    public string fullCode;
    public string firstPartCode,
        secondPartCode,
        thirdPartCode;

    [SerializeField]
    TextMeshPro _firstPartCodeText;

    [SerializeField]
    TextMeshPro _secondPartCodeText;

    [SerializeField]
    TextMeshPro _thirdPartCodeText;

    // Start is called before the first frame update
    void Start()
    {
        GenerateCode();
        _firstPartCodeText.text = firstPartCode;
        _secondPartCodeText.text = secondPartCode;
        _thirdPartCodeText.text = thirdPartCode;
        
    }

    // Update is called once per frame
    void Update() { }

    void GenerateCode()
    {
        int code = UnityEngine.Random.Range(100000, 999999);
        // Split fullCode to 3 parts and all have 2 digits
        firstPartCode = Convert.ToString(code / 10000);
        secondPartCode = Convert.ToString((code % 10000) / 100);
        thirdPartCode = Convert.ToString(code % 100);
        fullCode = firstPartCode + secondPartCode + thirdPartCode;
    }
}
