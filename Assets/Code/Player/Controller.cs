namespace Project2020
{
    using UnityEngine;

    public class Controller : MonoBehaviour, IHealth
    {
        private Vector3 point1 = new Vector3(0f, 1f, 0.3f);
        private Vector3 point2 = new Vector3(0f, 0f, 0.3f);
        private Vector3 point3 = new Vector3(0f, 0f, 0.3f);

        // Move check for interactables into own script
        // OverlapSphere checking for colliders with interactable script 

        private bool m_InteractableNearby = false;

        private void Update()
        {
            if (!m_InteractableNearby)
            {
                // never resets bool when interactable found
                IsThereNearbyInteractable();
            }
            else
            {
                CheckForInteractables();
            }
        }

        private void IsThereNearbyInteractable()
        {
            //Debug.Log("Nearby Called");

            var colliders = Physics.OverlapSphere(transform.position, 3f, LayerMask.GetMask("Interactable"));

            foreach (var col in colliders)
            {
                if (!col.gameObject.GetComponent(typeof(IInteractable)))
                    continue;

                m_InteractableNearby = true;
                //else { m_InteractableNearby = false; }
            }
        }

        private void CheckForInteractables()
        {
            Debug.Log("Check Called");

            var interactables = Physics.CapsuleCastAll(transform.position + point1, transform.position + point2, 0.3f, Vector3.down, 1f,
                LayerMask.GetMask("Interactable"));

            foreach (var obj in interactables)
            {
                if (obj.transform.gameObject.GetComponent(typeof(IInteractable)))
                {
                    var interactable = obj.transform.gameObject.GetComponent(typeof(IInteractable)) as IInteractable;

                    // Show on UI open/F/interact/something
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        interactable.Interact();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void OnDrawGizmos()
        {
            var center = transform.position;

            Gizmos.DrawWireSphere(center + transform.forward, 0.4f);

            //Gizmos.DrawWireSphere(transform.position + a + point1, 0.3f);
        }

        public void RestoreHealth()
        {
        }

        public void TakeDamage(float foo)
        {
        }

        public void UpgradeHealth()
        {
        }
    }
}