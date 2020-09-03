namespace Project2020
{
    using UnityEngine;

    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject m_Player = null;
        [SerializeField] private Camera m_PlayerCamera = null;
        [SerializeField] private Transform m_CameraBoom = null;
        [SerializeField] private CameraOptions m_CameraOptions = null;

        private float m_CameraSpeed;

        // Camera restraints 

        private void Awake()
        {
            m_CameraSpeed = m_CameraOptions.cameraSpeed;    
        }

        private void LateUpdate()
        {
            m_CameraBoom.position = m_Player.transform.position;

            UpdateCamera();
        }

        private void UpdateCamera()
        {
            // Free look camera if mouse button held down
            if (Input.GetMouseButton(0))
            {
                m_CameraBoom.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_CameraSpeed, Vector3.up);
                m_PlayerCamera.transform.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * m_CameraSpeed, Vector3.right);
            }
            else
            {
                // Free look camera was released
                if (Input.GetMouseButtonUp(0))
                {
                    // Options
                    // if (Never adjust): do not change camera angle
                    // else (Auto): Lerp camera angle to forward of character
                }
            }

            m_PlayerCamera.transform.position = m_CameraBoom.position - new Vector3(0f, -2f, 3f);
        }
    }
}