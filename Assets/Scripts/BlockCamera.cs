using UnityEngine;
using Cinemachine;

public class BlockCamera : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    public Transform characterTransform;
    private void Start()
    {   

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlockCam"))
        {
            // Disable camera movement
            virtualCamera.m_Follow = null;
        }
        Debug.Log("collider blockCam");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BlockCam"))
        {
            // Enable camera movement
            virtualCamera.m_Follow = characterTransform;
        }
    }
}