using UnityEngine;

namespace Plugins.Popup
{
    public class PopupFactory : MonoBehaviour
    {
        [SerializeField] private Popup _popup;

        private static Popup _references;

        private void Awake()
        {
            _references = _popup;
        }

        public static void Make(Vector3 position, Sprite sprite)
        {
            var newPopup = Instantiate(_references, position, Quaternion.identity);
            newPopup.Show(position, sprite);
        }
    }
}