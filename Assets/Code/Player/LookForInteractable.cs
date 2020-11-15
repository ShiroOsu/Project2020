#undef DRAWGIZMOS

namespace Project2020
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class LookForInteractable : MonoBehaviour, PlayerControls.IInteractionActions
    {
        [SerializeField] private InteractableData m_IData = null;
        [SerializeField] private GameObject m_InteractableText = null;
        private PlayerControls m_PlayerControls;
        private IInteractable m_Interactable;
        private LayerMask m_InteractableLayer;

        private Vector3 m_Point1;
        private Vector3 m_Point2;
        private readonly Vector3 m_PointOffset = new Vector3(0f, 1f, 0f);

        private void Awake()
        {
            m_PlayerControls = new PlayerControls();
            m_PlayerControls.Interaction.SetCallbacks(this);

            if (!m_IData)
            {
                m_IData = ScriptableObject.CreateInstance<InteractableData>();
            }

            m_InteractableLayer = m_IData.interactLayer;
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (m_Interactable == null)
                return;

            m_Interactable.Interact();
            
            if (!m_Interactable.IsInAnimation())
            {
                m_InteractableText.SetActive(false);
            }
        }

        private void Update()
        {
            if (IsThereNearbyInteractable())
            {
                SweepForInteraction();
            } else { m_InteractableText.SetActive(false); }
        }

        private bool IsThereNearbyInteractable()
        {
            var objWithInteract = Physics.OverlapSphere(transform.position, 3f, m_InteractableLayer);

            foreach (var obj in objWithInteract)
            {
                if (!obj.gameObject.GetComponent(typeof(IInteractable)))
                    continue;

                return true;
            }
            return false;
        }

        private IInteractable SweepForInteraction()
        {
            UpdateCapsulePoints();

            var interactables = Physics.CapsuleCastAll(m_Point1, m_Point2, 0.6f, Vector3.down, 1f, m_InteractableLayer);

            foreach (var hit in interactables)
            {
                if (m_Interactable != null)
                { 
                    // only active while close to object, and remove it after interaction
                    // so only set it to true once 
                    m_InteractableText.SetActive(true);
                }

                return m_Interactable = hit.transform.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;
            }
            return null;
        }

        private void UpdateCapsulePoints()
        {
            m_Point1 = transform.position + transform.forward;
            m_Point2 = transform.position + m_PointOffset + transform.forward;
        }

        private void OnEnable()
        {
            m_PlayerControls.Enable();
        }

        private void OnDisable()
        {
            m_PlayerControls.Disable();
        }

        private void OnDrawGizmos()
        {
            var center = transform.position;
            var radius = 0.4f;

            //Testing for CapsuleCasting
            Gizmos.DrawWireSphere(center + transform.forward, radius);
            Gizmos.DrawWireSphere(center + (new Vector3(0f, 1f, 0f)) + transform.forward, radius);
        }
    }
}