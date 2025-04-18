using System.Collections.Generic;
using UnityEngine;

namespace Plugins.ResourceManagment
{
    public class ResourceManager
    {
        private static List<IResource> _resources = new List<IResource>();

        public static void Init()
        {
            foreach (var resource in _resources)
            {
                resource.Init();
            }
        }

        public static void Register(IResource resource)
        {
            _resources.Add(resource);
        }

        public static void UnRegister(IResource resource)
        {
            _resources.Remove(resource);
        }

        public static void Clear()
        {
            foreach (var resource in _resources)
            {
                resource.Dispose();
            }
            _resources.Clear();
        }
    }
}