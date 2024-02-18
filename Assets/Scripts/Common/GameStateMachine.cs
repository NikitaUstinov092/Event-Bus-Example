using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Common
{
    public enum StateGame
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
    }
    public class GameStateMachine : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public StateGame State
        {
            get { return state; }
        }

        private StateGame state;

        [Inject]
        private readonly DiContainer _container;

        private void Awake()
        {
            Init();
        }
        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            UpdateGameListener();
        }
        
        private void FixedUpdate()
        {
            FixedUpdateGameListener();
        }

        private void OnDisable()
        {
            Disable();
        }
 
        [Button]
        public void Init()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IInitListener>>())
            {
                listener.OnInit();
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IStartListener>>())
            {
                listener.StartGame();
            }
            state = StateGame.PLAYING;
        }

        private void Disable()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IDisableListener>>())
            {
                listener.Disable();
            }
            state = StateGame.OFF;
        }

        private void UpdateGameListener()
        {
            if (state != StateGame.PLAYING)
                return;

            foreach (var listener in _container.Resolve<IEnumerable<IUpdateListener>>())
            {
                listener.Update();
            }
        }
        
        private void FixedUpdateGameListener()
        {
            if (state != StateGame.PLAYING)
                return;

            foreach (var listener in _container.Resolve<IEnumerable<IFixedUpdateListener>>())
            {
                listener.FixedUpdate();
            }
        }

        [Button]
        public void Pause()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IPausedListener>>())
            {
                listener.Pause();
            }
            state = StateGame.PAUSED;
        }
       
        [Button]
        public void UnPause()
        {
            foreach (var listener in _container.Resolve<IEnumerable<IUnPausedListener>>())
            {
                listener.UnPause();
            }
            state = StateGame.PLAYING;
        }
    }
}