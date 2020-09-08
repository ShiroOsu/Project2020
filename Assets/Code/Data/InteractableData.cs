using UnityEngine;

[CreateAssetMenu(fileName = "InteractableData", menuName = "ScriptableObjects/InteractableData")]
public class InteractableData : ScriptableObject
{
    public LayerMask interactLayer;
}