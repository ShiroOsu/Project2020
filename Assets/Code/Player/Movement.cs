﻿namespace Project2020
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Movement : MonoBehaviour, PlayerControls.IGameplayActions
    {
        [SerializeField] private PlayerData m_PlayerData = null;
        [SerializeField] private Strings m_StringData = null;
        [SerializeField] private Animator m_Animator = null;
        private PlayerControls m_PlayerControls = null;

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
            m_PlayerControls = new PlayerControls();
            m_PlayerControls.Gameplay.SetCallbacks(this);

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

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();

            m_ForwardVector.z = direction.y;
            m_DirectionVector.x = direction.x;

            if (m_ForwardVector.z < 0f)
            {
                m_MovementSpeed = m_BackwardSpeed;
            } 
        }

        public void OnRunning(InputAction.CallbackContext context)
        {
            if (m_ForwardVector.z < 0f)
                return;

            if (context.action.triggered)
            {
                m_MovementSpeed = m_PlayerData.movementSpeed * 1.5f;
            }
            else
            {
                m_MovementSpeed = m_PlayerData.movementSpeed;
            }
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!m_IsOnGround)
                return;

            if (m_CurrentState.fullPathHash != locomotionState)
                return;

            m_RigidBody.AddForce(Vector3.up * m_JumpHeight, ForceMode.VelocityChange);
            m_Animator.SetBool(m_StringData.jump, true);
        }

        private void OnEnable()
        {
            m_PlayerControls.Enable();
        }

        private void OnDisable()
        {
            m_PlayerControls.Disable();
        }

        private void UpdateCurrentAnimationState()
        {
            m_CurrentState = m_Animator.GetCurrentAnimatorStateInfo(0);
        }

        private void Update()
        {
            UpdateCurrentAnimationState();
            GroundCheck();

            // Run the correct animation based on direction and speed
            m_Animator.SetFloat(m_StringData.direction, m_DirectionVector.x);
            m_Animator.SetFloat(m_StringData.speed, m_ForwardVector.z * m_MovementSpeed);

            // When jumping adjust the collider and set jump boolean to false (hard random)
            if (m_CurrentState.fullPathHash == jumpState && !m_Animator.IsInTransition(0))
                CancelJumpState();
        }

        private void FixedUpdate()
        {
            UpdatePosition();
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
                Vector3.down, Quaternion.identity, 1f, m_PlayerData.groundLayer);
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