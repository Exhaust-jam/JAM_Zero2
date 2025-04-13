using Plugins.Ability;
using Plugins.CharacteristicsSystem;
using Plugins.RigidbodyMovement;
using UnityEngine;

namespace Plugins.Player
{
    public class PlayerInit : MonoBehaviour
    {
        [SerializeField] private CrosshairUnitCapture _crosshairUnitCapture;
        [SerializeField] private CrosshairRenderer _crosshairRenderer;
        public void Init(IInput input, Unit unit)
        {
            var controllables = unit.Controllables;
            foreach (var comp in controllables)
            {
                comp.SetInput(input);
                if (comp is HeadLook look)
                {
                    Camera.main.transform.parent = look.Head;
                    Camera.main.transform.localPosition = Vector3.zero;
                }
            }
            _crosshairUnitCapture.Init(input, _crosshairRenderer);

        }
    }
}