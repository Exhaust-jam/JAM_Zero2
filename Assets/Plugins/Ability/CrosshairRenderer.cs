using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Ability
{
    public class CrosshairRenderer : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private RectTransform _outline;
        [SerializeField] private Vector2 _scaleSize;

        public void Draw(Vector3 screenPosition)
        {
            if (screenPosition.z > 0) 
            {
                _outline.gameObject.SetActive(true);
                _outline.position = screenPosition;

                float scale = Mathf.Clamp(1 / screenPosition.z * 100, _scaleSize.x, _scaleSize.y);
                _outline.localScale = Vector3.one * scale;
            }
            else
            {
                _outline.gameObject.SetActive(false);
            }
        }

        public void Clear()
        {
            _outline.gameObject.SetActive(false);
        }
    }
}