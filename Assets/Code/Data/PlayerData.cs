namespace Project2020
{
    using System;
    using UnityEngine;

    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
    public class PlayerData : ScriptableObject, ISerializationCallbackReceiver
    {
        [Header("Properties")] // temp
        public LayerMask groundLayer;
        public float health;
        public float attackDamage;
        [NonSerialized] public float runTimeHealth;

        [Header("Movement Variables")]
        public float movementSpeed;
        public float rotateSpeed;
        public float backwardSpeed;

        [Header("Jump Mechanics")]
        //public bool canJump;
        public float jumpHeight;

        // During game time the health of the player data will be "runTimeHealth"
        // To prevent any overrides to the initial health the player start with.
        public void OnAfterDeserialize()
        {
            runTimeHealth = health;
        }

        public void OnBeforeSerialize() { }
    }
}