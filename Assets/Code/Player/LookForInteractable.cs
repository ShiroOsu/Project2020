#undef DRAWGIZMOS

namespace PlayerControls
{
    using UnityEngine;

    public class LookForInteractable : MonoBehaviour
    {
        [SerializeField] private InteractableData m_IData = null;

        //[SerializeField] private GameObject m_InteractionText = null;
        private LayerMask m_InteractableLayer;

        private Vector3 m_Point1;
        private Vector3 m_Point2;
        private readonly Vector3 m_PointOffset = new Vector3(0f, 1f, 0f);

        private void Awake()
        {
            if (!m_IData)
            {
                m_IData = ScriptableObject.CreateInstance<InteractableData>();
            }

            m_InteractableLayer = m_IData.interactLayer;
        }

        private void Update()
        {
            if (IsThereNearbyInteractable())
            {
                SweepForInteraction();
            }
            else
            {
                // Temp
                ShowInteractionOnUI(false);
            }
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

        private void SweepForInteraction()
        {
            UpdateCapsulePoints();

            var interactables = Physics.CapsuleCastAll(m_Point1, m_Point2, 0.6f, Vector3.down, 1f, m_InteractableLayer);

            foreach (var hit in interactables)
            {
                var interactable = hit.transform.gameObject.GetComponent(typeof(IInteractable));

                if (interactable)
                {
                    // Move this to interact object
                    ShowInteractionOnUI(true);
                }

                var interactObj = interactable as IInteractable;

                Debug.Log(interactObj);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    interactObj.Interact();
                }
            }
        }

        private void UpdateCapsulePoints()
        {
            m_Point1 = transform.position + transform.forward;
            m_Point2 = transform.position + m_PointOffset + transform.forward;
        }

        private void ShowInteractionOnUI(bool active)
        {
            //m_InteractionText.SetActive(active);
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