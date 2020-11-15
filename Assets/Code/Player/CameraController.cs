namespace Project2020
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour, PlayerControls.ICameraControlsActions
    {
        [SerializeField] private GameObject m_Player = null;
        [SerializeField] private Camera m_PlayerCamera = null;
        [SerializeField] private Transform m_CameraBoom = null;
        [SerializeField] private CameraOptions m_CameraOptions = null;
        private PlayerControls m_CameraController = null;

        private float m_CameraSpeed;
        private Quaternion m_CameraRotation;

        public void OnCamera(InputAction.CallbackContext context)
        {
            var vector2 = context.ReadValue<Vector2>().normalized;
            var mouseX = vector2.x * m_CameraSpeed;
            var mouseY = vector2.y * m_CameraSpeed;
            
            m_CameraRotation.x += mouseY;
            m_CameraRotation.y += mouseX;

            m_CameraBoom.rotation = Quaternion.Euler(m_CameraRotation.x, m_CameraRotation.y, m_CameraRotation.z);
        }

        private void Awake()
        {
            m_CameraController = new PlayerControls();
            m_CameraController.CameraControls.SetCallbacks(this);

            m_CameraSpeed = m_CameraOptions.cameraSpeed;
            m_CameraRotation = m_CameraBoom.transform.localRotation;
        }

        private void OnEnable()
        {
            m_CameraController.Enable();
        }

        private void OnDisable()
        {
            m_CameraController.Disable();
        }

        private void LateUpdate()
        {
            m_CameraBoom.position = m_Player.transform.position;

            UpdateCamera();
        }

        private void UpdateCamera()
        {
            // Free look camera if mouse button held down
            //if (Input.GetMouseButton(0))
            //{
            //    m_CameraBoom.rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_CameraSpeed, Vector3.up);
            //    m_PlayerCamera.transform.rotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * m_CameraSpeed, Vector3.right);
            //}
            //else
            //{
            //    // Free look camera was released
            //    if (Input.GetMouseButtonUp(0))
            //    {
            //        // Options
            //        // if (Never adjust): do not change camera angle
            //        // else (Auto): Lerp camera angle to forward of character
            //    }
            //}
        }
    }
}