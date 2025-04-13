using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.Popup
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;
        [SerializeField] private float _transitionDelta;
        [SerializeField] private float _startUpDelta;

        private Transform _camera;

        private void Awake()
        {
            _camera = Camera.main.transform;
        }

        public void Show(Vector3 position, Sprite img)
        {
            _canvas.transform.position = position + Vector3.up * _startUpDelta;
            _image.sprite = img;
            _canvas.enabled = true;
            StartCoroutine(ShowRoutine());
        }

        private IEnumerator ShowRoutine()
        {
            var start = 0f;
            var endPos = _canvas.transform.position + Vector3.up * _transitionDelta; 
            while (start <= _duration)
            {
                _canvas.transform.position = Vector3.Lerp(_canvas.transform.position, endPos, start/_transitionDelta);
                start += Time.deltaTime;
                _canvas.transform.LookAt(_camera);
                yield return null;
            }
            Destroy(gameObject);
        }
    }
}