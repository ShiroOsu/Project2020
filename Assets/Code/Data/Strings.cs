namespace Project2020
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "StringData", menuName = "ScriptableObjects/StringData")]
    public class Strings : ScriptableObject
    {
        public string direction = "Direction";
        public string speed = "Speed";
        public string jump = "Jump";
        public string jumpHeight = "Jump Height";
        public string gravityControl = "Gravity Control";
    }
}