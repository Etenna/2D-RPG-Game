using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClampPlayerInTilemap : MonoBehaviour
{
    [SerializeField] Tilemap backgroundTilemap;
    [SerializeField] PlayerController playerToClamp;
    [SerializeField] float clampOffset = 0;


    Vector3 bottomLeftEdge;
    Vector3 topRightEdge;
    private void Awake()
    {
        backgroundTilemap.CompressBounds();
    }
    // Start is called before the first frame update
    void Start()
    {
        bottomLeftEdge = backgroundTilemap.localBounds.min + new Vector3(clampOffset, clampOffset, 0);
        topRightEdge = backgroundTilemap.localBounds.max + new Vector3(-clampOffset, -clampOffset, 0);

        
    }
    // Update is called once per frame
    void Update()
    {
        FindPlayerInNewScene();
        HoldPlayerInMap();
    }

    private void FindPlayerInNewScene()
    {
        while (playerToClamp == null)
        {
            playerToClamp = FindObjectOfType<PlayerController>();
        }
    }

    private void HoldPlayerInMap()
    {
        playerToClamp.transform.position = new Vector3(
            Mathf.Clamp(playerToClamp.transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(playerToClamp.transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            Mathf.Clamp(playerToClamp.transform.position.z, bottomLeftEdge.z, topRightEdge.z)
            );
    }
}
