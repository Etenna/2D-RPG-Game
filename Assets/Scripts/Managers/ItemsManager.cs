using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{

    [SerializeField] ItemData itemData;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemData.ItemImage;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

}
