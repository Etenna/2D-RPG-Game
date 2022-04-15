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
        SetVCFollowToPlayer();
        if (SceneManager.GetActiveScene().name == "Overworld")
            virtualCamera.m_Lens.OrthographicSize = 8f;
        else
            virtualCamera.m_Lens.OrthographicSize = 5f;
    }

    public void SetVCFollowToPlayer()
    {
        FindPlayerInNewScene();

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = playerTarget.transform;
    }

    public void FindPlayerInNewScene()
    {
        while (playerTarget == null)
        {
            playerTarget = FindObjectOfType<PlayerController>();
        }
    }
    private void OnEnable()
    {
    }
    private void OnDisable()
    {
    }

}
