using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Player;

public class CameraController : MonoBehaviour
{
    PlayerController playerTarget;
    CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update
    void Start()
    {
        while (playerTarget == null)
        {
            playerTarget=FindObjectOfType<PlayerController>();
        }
        virtualCamera=GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow=playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
