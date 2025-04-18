using System;
using System.Linq;
using System.Reflection;
using Plugins.ResourceManagment;
using UnityEngine;
using Zenject;

namespace Plugins.GameInitialization
{
    public class Core
    {
        private Type[] _priorities = new[]
        {
            typeof(IGamePreLoadState), typeof(IGameOnLoadedState), typeof(IGameOnStartState),
            typeof(IGameOnExitedState)
        };
        public void Start(DiContainer container)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes().
                Where((x) => x.IsClass && typeof(IGameInitializationStates).IsAssignableFrom(x));

            foreach (var type in _priorities)
            {
                var result = types.Where((x) => type.IsAssignableFrom(x));
                if (!result.Any())
                {
                    continue;
                }
                foreach (var item in result)
                {
                    var method = item.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                    var instance = Activator.CreateInstance(item);
                    method[0].Invoke(instance, new  object[] { container });
                }
            }
        }

        public void Restart()
        {
            var restartables = GameObject.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID)
                .Where((x) => x is IRestartable)
                .Cast<IRestartable>();
            foreach (var item in restartables)
            {
                item.Restart();
            }
        }
    }
}