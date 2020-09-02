namespace Project2020.Objects
{
    using Interactable;
    using UnityEngine;

    public class Door : MonoBehaviour, IInteractable
    {

        // test

        [SerializeField] private Animator m_Animator = null;

        private void Update()
        {
            // this could be done in the Controller of the Character actually
            // SphereCast forward direction getComponent<IInteractable>?.Interact(); or something
            // and only keep opening/closing in the door script

            Collider[] colliders = Physics.OverlapSphere(transform.position, 1f, LayerMask.GetMask("Player"));

            foreach (var col in colliders)
            {
                if (!col)
                    continue;

                if (!col.gameObject.GetComponent<Controller.Controller>())
                    continue;

                if (col.gameObject.GetComponent<Controller.Controller>())
                {
                    // if player is facing the interactable
                    // show the interactable key
                    // press / hold, depending on interactable
                    Open();
                }
            }
        }

        // testing animation
        // not sure how I want to trigger animations
        private void Open()
        {
            m_Animator.SetBool("Open", true);
            m_Animator.SetBool("Close", false);
        }

        private void Close()
        {
            m_Animator.SetBool("Close", true);
            m_Animator.SetBool("Open", false);
        }

        public void Interact()
        {
            Open();
        }
    }
}