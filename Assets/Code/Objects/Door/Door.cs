namespace Project2020
{
    using System.Collections;
    using UnityEngine;

    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Animator m_Animator = null;
        [SerializeField] private GameObject m_Player = null;

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
        }
        private IEnumerator Closing(float time)
        {
            yield return new WaitForSeconds(time);
            Close();
        }

        private void OpenBackwards()
        {
            m_Animator.SetBool("OpenBackwards", true);
        }

        private void CloseBackwards()
        {
            m_Animator.SetBool("OpenBackwards", false);
        }

        private IEnumerator ClosingBackwards(float time)
        {
            yield return new WaitForSeconds(time);
            CloseBackwards();
        }

        public void Interact()
        {
            if (m_Animator.IsInTransition(0))
                return;

            if (m_Player)
            {
                if (m_Player.transform.forward.z < 0f)
                {
                    OpenBackwards();
                    StartCoroutine(ClosingBackwards(3f));
                }
                else
                {
                    Open();
                    StartCoroutine(Closing(3f));
                }
            }
        }

        public bool IsInAnimation()
        {
            return m_Animator.IsInTransition(0);
        }
    }
}