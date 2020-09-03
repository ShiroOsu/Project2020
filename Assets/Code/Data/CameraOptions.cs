namespace Project2020
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "CameraOptions", menuName = "ScriptableObjects/CameraOptions")]
    public class CameraOptions : ScriptableObject
    {
        public float cameraSpeed;

        // Camera options
        public bool _auto = false;
        public bool neverAdjust = true;

    }
}