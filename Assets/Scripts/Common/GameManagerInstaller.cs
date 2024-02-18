using UnityEngine;
using Zenject;

namespace CannonScene
{
    public class GameManagerInstaller : MonoInstaller<GameManagerInstaller>
    {
        [SerializeField] private MonoBehaviour[] _allIListenersMono;
        public override void InstallBindings()
        {
            foreach (var monoBehaviour in _allIListenersMono)
            {
                var massComp = monoBehaviour.GetComponents<MonoBehaviour>();

                foreach (var comp in massComp)
                {
                    if (comp is IGameListener listener)
                        Container.BindInterfacesTo(listener.GetType()).FromInstance(listener).AsCached();
                }
            }
        }

    }
}


