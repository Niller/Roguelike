using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    public class ApplicationManager : MonoBehaviour
    {
        private Entitas.Systems _systems;

        private void Awake()
        {
            var contexts = new Contexts();
            _systems = new Entitas.Systems()
                .Add(new CreateViewSystem(contexts.game))
                .Add(new SyncViewSystem(contexts))
                .Add(new InputSystem(contexts))
                .Add(new ArenaStartupSystem(contexts))
                .Add(new MovementSystem(contexts))
                .Add(new RotationSystem(contexts));
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }
    }
}
