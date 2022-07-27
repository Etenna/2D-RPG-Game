using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetEquippedText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI equippedText;
    // Start is called before the first frame update
    void Start()
    {
        equippedText=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
