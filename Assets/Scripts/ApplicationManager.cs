using Assets.Scripts.Systems;
using UnityEngine;

namespace Assets.Scripts
{
    public class ApplicationManager : MonoBehaviour
    {
        private Entitas.Systems _systems;

        private void Start()
        {
            var contexts = new Contexts();
            _systems = new Entitas.Systems()
                .Add(new SyncModelPositionSystem(contexts))
                .Add(new CreateViewSystem(contexts.game))
                .Add(new InputSystem(contexts))
                .Add(new ArenaStartupSystem(contexts))
                .Add(new MovementSystem(contexts))
                .Add(new RotationSystem(contexts))
                .Add(new CameraControlSystem(contexts))
                .Add(new SyncViewPositionSystem(contexts))
                .Add(new SyncViewRotationSystem(contexts))
                .Add(new ChooseTargetSystem(contexts))
                .Add(new MoveToTargetSystem(contexts))
                .Add(new UpdateHealthBarValueSystem(contexts.game))
                .Add(new UpdateHealthBarPositionSystem(contexts));
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
        }
    }
}