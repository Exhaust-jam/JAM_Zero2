using UnityEngine;

namespace Plugins.PlayerController
{
    public class FPSConstruct : MonoBehaviour
    {
        [field: SerializeField] public CharacterController Controller { get; private set; }
        [field: SerializeField] public Transform Model { get; private set; }
        [field: SerializeField] public Transform Head { get; private set; }
    }
}