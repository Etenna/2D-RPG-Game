using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerController : MonoBehaviour
{

    [SerializeField] int villagerID;
    [SerializeField] string villagerName;
    [SerializeField] bool hasQuests;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetVillagerName()
    {
        return villagerName;
    }
}
