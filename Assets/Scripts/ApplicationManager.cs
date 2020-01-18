using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts
{
    public class ApplicationManager : MonoBehaviour
    {
        private Entitas.Systems _systems;

        private void Awake()
        {
            var contexts = new Contexts();
            _systems = new Entitas.Systems()
                .Add(new SyncModelPositionSystem(contexts))
                .Add(new CreateViewSystem(contexts.game))
                .Add(new InputSystem(contexts))
                .Add(new ArenaStartupSystem(contexts))
                .Add(new MovementSystem(contexts))
                .Add(new RotationSystem(contexts))
                .Add(new SyncViewPositionSystem(contexts))
                .Add(new SyncViewRotationSystem(contexts));
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }
    }
}