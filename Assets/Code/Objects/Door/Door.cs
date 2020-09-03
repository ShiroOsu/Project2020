namespace Project2020
{
    using System.Collections;
    using UnityEngine;

    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator m_Animator = null;

        // Depending from which direction you open the door
        // change animation

        // testing animation
        // not sure how I want to trigger animations
        private void Open()
        {
            m_Animator.SetBool("Open", true);
        }

        private void Close()
        {
            m_Animator.SetBool("Open", false);
            Debug.Log("Closing Called");
        }

        private IEnumerator Closing(float time)
        {
            yield return new WaitForSeconds(time);
            Close();
        }

        public void Interact()
        {
            if (m_Animator.IsInTransition(0))
                return;

            Open();
            StartCoroutine(Closing(3f));
        }
    }
}