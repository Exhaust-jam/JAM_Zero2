using System.Collections.Generic;
using UnityEngine;

namespace Plugins.FX.Sound
{
    public class UnitSoundsStorage : MonoBehaviour
    {
        [SerializeField] private List<UnitSound> unitSounds;
        
        private Dictionary<Sound, UnitSound> _sounds = new Dictionary<Sound, UnitSound>();

        private void Awake()
        {
            foreach (var sn in unitSounds)
            {
                _sounds[sn.sound] = sn;
            }
        }

        public void Play(Sound sound)
        {
            var source = _sounds[sound];
            if (source.needWait)
            {
                if (!_sounds[sound].audioSource.isPlaying)
                {
                    if (_sounds[sound].audioSource.enabled == false) return;
                    _sounds[sound].audioSource.Play();
                }
            }
            else
            {
                _sounds[sound].audioSource.Stop();
                _sounds[sound].audioSource.Play();
            }
        }

        public void Stop(Sound sound)
        {
            _sounds[sound].audioSource.Stop();
        }
    }
}