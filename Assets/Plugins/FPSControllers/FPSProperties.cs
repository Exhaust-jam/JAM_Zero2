using Plugins.HealthSystem;
using UnityEngine;

namespace Plugins.PlayerController
{
    public class FPSProperties : UnitProperties
    {
        public float CurrentSpeed {get; set;}
        [field: SerializeField] public FPSConstruct Construct { get; set; }
        [Header("Head")]
        [field: SerializeField] public Transform Head { get; set; }
        [field: SerializeField] public float HeadShakeForce { get; set; }
        [field: SerializeField] public float HeadShakedDownDeltaLimit { get; set; }
        [Header("Jump settings")]
        [field: SerializeField] public float MoveDirectionDecrease { get; set; }
        [field: SerializeField] public float MinGravityOnGround { get; set; }
        [field: SerializeField] public float JumpForce { get; set; }
        [field: SerializeField] public float RotationSpeed { get; set; }
        [Header("Run Settings")]
        [field: SerializeField] public float RunSpeed { get; set; }
        [field: SerializeField] public float Duration { get; set; }
        [field: SerializeField] public float Endurance { get; set; }
        [field: SerializeField] public float EnduranceWaste { get; set; }
        [Header("Crouch settings")]
        [field: SerializeField] public float CrouchSpeed { get; set; }
        [field: SerializeField] public float CrouchScale { get; set; }
        
    }
}