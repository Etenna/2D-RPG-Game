using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClampPlayerInTilemap : MonoBehaviour
{
    [SerializeField] Tilemap backgroundTilemap;
    [SerializeField] GameObject playerToClamp;

    Vector3 bottomLeftEdge;
    Vector3 topRightEdge;
    private void Awake()
    {
        backgroundTilemap.CompressBounds();
    }
    // Start is called before the first frame update
    void Start()
    {
        bottomLeftEdge = backgroundTilemap.localBounds.min;
        topRightEdge = backgroundTilemap.localBounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        HoldPlayerInMap();
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
