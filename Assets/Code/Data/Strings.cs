namespace Project2020
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "StringData", menuName = "ScriptableObjects/StringData")]
    public class Strings : ScriptableObject
    {
        public string direction = "Direction";
        public string speed = "Speed";
        public string horizontal = "Horizontal";
        public string vertical = "Vertical";
        public string jump = "Jump";
        public string jumpHeight = "JumpHeight";
    }
}