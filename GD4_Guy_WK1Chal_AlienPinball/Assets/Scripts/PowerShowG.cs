using JetBrains.Annotations;
using System;
using TMPro;
using UnityEngine;

public class PowerGShow : MonoBehaviour
{
    // public TextMeshPro tmpText;
    public TextMeshProUGUI tmpText;
    public int PowerShow;
    public float PowerG;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PowerShow = Mathf.RoundToInt(PowerG);
        tmpText.text = "Power: " + PowerShow   ;

    }
}
