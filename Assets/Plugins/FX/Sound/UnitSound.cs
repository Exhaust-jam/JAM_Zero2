using System;
using UnityEngine;

namespace Plugins.FX.Sound
{
    [Serializable]
    public class UnitSound
    {
        public bool needWait;
        public AudioSource audioSource;
        public Sound sound;
    }
}