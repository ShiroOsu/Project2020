namespace Project2020
{

    using UnityEngine;

    [CreateAssetMenu(fileName = "InteractableData", menuName = "ScriptableObjects/InteractableData")]
    public class InteractableData : ScriptableObject
    {
        public LayerMask interactLayer;
    }
}