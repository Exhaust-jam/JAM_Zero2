using System;
using UnityEngine;

namespace Plugins.ResourceManagment
{
    public class Resource
    {
        public static T Instantiate<T>(T resource, bool registered=false)
        {
            #if UNITY_EDITOR
            if (resource is not MonoBehaviour)
            {
                throw new InvalidCastException(nameof(resource));
            }
            #endif
            
            var monoBehaviour = resource as MonoBehaviour;
            var newResource = (IResource) GameObject.Instantiate(monoBehaviour);
            if (registered)
                ResourceManager.Register(newResource);
            return (T)newResource;
        }

        public static void Destroy(IResource resource)
        {
            resource.Dispose();
            GameObject.Destroy(resource as MonoBehaviour);
        }
    }
}