namespace Project2020
{
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private LayerMask m_GroundLayer = 0;
        [SerializeField] private PlayerData m_PlayerData = null;
        [SerializeField] private Strings m_StringData = null;
        [SerializeField] private Animator m_Animator = null;

        private float m_MovementSpeed;
        private float m_BackwardSpeed;
        private float m_RotateSpeed;
        private float m_JumpHeight;
        private Vector3 m_ForwardVector;
        private Vector3 m_DirectionVector;
        private Transform m_PlayerTransform;
        private CapsuleCollider m_Collider;
        private Rigidbody m_RigidBody;
        private Vector3 m_OrgColliderCenterVector;
        private float m_OrgColliderHeight;
        private Vector3 m_BoxExtents = new Vector3(0.5f, 0.5f, 0.5f);

        private bool m_IsOnGround = false;

        //private readonly int idleState = Animator.StringToHash("Base Layer.Idle");
        private readonly int locomotionState = Animator.StringToHash("Base Layer.Locomotion");
        private readonly int jumpState = Animator.StringToHash("Base Layer.Jump");
        //private readonly int restState = Animator.StringToHash("Base Layer.Rest");
        private AnimatorStateInfo m_CurrentState;

        private void Awake()
        {
            if (!m_PlayerData)
            {
                m_PlayerData = ScriptableObject.CreateInstance<PlayerData>();
            }

            if (!m_StringData)
            {
                m_StringData = ScriptableObject.CreateInstance<Strings>();
            }

            m_Collider = GetComponent<CapsuleCollider>();
            m_RigidBody = GetComponent<Rigidbody>();
            m_PlayerTransform = GetComponent<Transform>();
            
            m_OrgColliderHeight = m_Collider.height;
            m_OrgColliderCenterVector = m_Collider.center;
            
            m_MovementSpeed = m_PlayerData.movementSpeed;
            m_JumpHeight = m_PlayerData.jumpHeight;
            m_BackwardSpeed = m_PlayerData.backwardSpeed;
            m_RotateSpeed = m_PlayerData.rotateSpeed;
        }

        private void UpdateCurrentAnimationState()
        {
            m_CurrentState = m_Animator.GetCurrentAnimatorStateInfo(0);
        }


        private void Update()
        {
            UpdateCurrentAnimationState();
            GroundCheck();
            HandleInputs();
        }

        private void FixedUpdate()
        {
            UpdatePosition();

            // Run the correct animation based on direction and speed
            m_Animator.SetFloat(m_StringData.direction, m_DirectionVector.x);
            m_Animator.SetFloat(m_StringData.speed, m_ForwardVector.z * m_MovementSpeed);

            if (m_CurrentState.fullPathHash == jumpState && !m_Animator.IsInTransition(0))
                CancelJumpState();
        }

        private void HandleInputs()
        {
            m_DirectionVector.x = Input.GetAxisRaw(m_PlayerData.Horizontal);
            m_ForwardVector.z = Input.GetAxisRaw(m_PlayerData.Vertical);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (m_IsOnGround && !m_Animator.IsInTransition(0))
                {
                    Jump();
                }
            }
            
            if (m_ForwardVector.z < 0f)
            {
                m_MovementSpeed = m_BackwardSpeed;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                m_MovementSpeed = m_PlayerData.movementSpeed;
            }

            if (!m_IsOnGround)
                return;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                m_MovementSpeed = m_PlayerData.movementSpeed * 1.5f;
            }
        }

        private void UpdatePosition()
        {
            Vector3 rotateDirection = new Vector3(0f, m_DirectionVector.x, 0f);

            // Rotate player (keyboard turning)
            m_PlayerTransform.Rotate(rotateDirection * m_RotateSpeed, Space.Self);

            // Forward Direction
            Vector3 direction = m_PlayerTransform.rotation * m_ForwardVector;

            // Move player
            m_PlayerTransform.position += direction.normalized * m_MovementSpeed * Time.fixedDeltaTime;
        }

        private bool GroundCheck()
        {
            return m_IsOnGround = Physics.BoxCast(m_PlayerTransform.position + (new Vector3(0f, 1.5f, 0f)), m_BoxExtents,
                Vector3.down, Quaternion.identity, 1f, m_GroundLayer);
        }

        private void Jump()
        {
            if (m_CurrentState.fullPathHash != locomotionState)
                return;

            m_RigidBody.AddForce(Vector3.up * m_JumpHeight, ForceMode.VelocityChange);
            m_Animator.SetBool(m_StringData.jump, true);
        }

        private void CancelJumpState()
        {
            float jumpHeight = m_Animator.GetFloat(m_StringData.jumpHeight);
            float curvesHeight = 0.5f;

            Ray ray = new Ray(m_PlayerTransform.position + Vector3.up, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.distance > curvesHeight)
                {
                    m_Collider.height = m_OrgColliderHeight - jumpHeight;
                    float adjustCollider = m_OrgColliderCenterVector.y + jumpHeight;
                    m_Collider.center = new Vector3(0f, adjustCollider, 0f);
                }
                else
                {
                    ResetCollider();
                }
            }
            m_Animator.SetBool(m_StringData.jump, false);
        }

        private void ResetCollider()
        {
            m_Collider.height = m_OrgColliderHeight;
            m_Collider.center = m_OrgColliderCenterVector;
        }
    }
}