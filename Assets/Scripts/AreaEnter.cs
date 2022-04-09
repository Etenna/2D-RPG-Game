using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] string transitionAreaName;
    // Start is called before the first frame update
    void Start()
    {
        if(transitionAreaName == PlayerController.instance.transitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}