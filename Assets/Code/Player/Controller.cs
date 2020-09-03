namespace Project2020
{
    using UnityEngine;

    public class Controller : MonoBehaviour, IHealth
    {
        private void Update()
        {
            CheckForInteractables();
        }

        private void CheckForInteractables()
        {
            // Capsule collider, vector3.down
            // 
            var interactables = Physics.SphereCastAll(transform.position + new Vector3(0f, 1f, 0f), 0.5f, transform.forward, 1f, LayerMask.GetMask("Interactable"));

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