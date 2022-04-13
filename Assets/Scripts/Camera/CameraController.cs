using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }

    PlayerController playerTarget;
    CinemachineVirtualCamera virtualCamera;
    // Start is called before the first frame update

    private void Awake()
    {

    }
    void Start()
    {
        SetVCFollowToPlayer(playerTarget);
        if (SceneManager.GetActiveScene().name == "Overworld")
            virtualCamera.m_Lens.OrthographicSize = 8f;
        else
            virtualCamera.m_Lens.OrthographicSize = 5f;
    }

    public void SetVCFollowToPlayer(PlayerController playerToFind)
    {
        playerToFind = FindPlayerInNewScene(playerToFind);

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = playerToFind.transform;
    }

    public PlayerController FindPlayerInNewScene(PlayerController playerToFind)
    {
        while (playerToFind == null)
        {
            playerToFind = FindObjectOfType<PlayerController>();
        }

        return playerToFind;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
