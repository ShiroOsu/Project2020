namespace Project2020
{
    using UnityEngine;

    public class LookForInteractable : MonoBehaviour
    {
        [SerializeField] private InteractableData m_IData = null;
        private LayerMask m_InteractableLayer;

        //private Vector3 point1 = new Vector3(0f, 1f, 0.3f);
        //private Vector3 point2 = new Vector3(0f, 0f, 0.3f);

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
            var interactables = Physics.CapsuleCastAll(transform.position, transform.position, 0.3f, Vector3.down, 1f, m_InteractableLayer);

            foreach (var hit in interactables)
            {
                var interactable = hit.transform.gameObject.GetComponent(typeof(IInteractable));

                if (!interactable)
                    return;

                var toInteract = interactable as IInteractable;

                // Show on UI open/F/interact/something
                if (Input.GetKeyDown(KeyCode.F))
                {
                    toInteract.Interact();
                }
            }
        }

        private void OnDrawGizmos()
        {
            // Testing for correct CapsuleCasting

            var center = transform.position;

            Gizmos.DrawWireSphere(center + transform.forward, 0.4f);

            Gizmos.DrawWireSphere(center + (new Vector3(0f, 1f, 0f)) + transform.forward, 0.4f);
        }
    }
}