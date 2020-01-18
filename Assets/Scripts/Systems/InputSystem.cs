using Entitas;
using TouchControlsKit;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class InputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public InputSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.Player);
        }

        public void Execute()
        {
            var direction = TCKInput.GetAxis("Joystick");
            var active = direction != Vector2.zero;

            foreach (var entity in _group.GetEntities())
            {
                if (active)
                {
                    entity.direction.Value = direction.normalized;
                    entity.movement.Move = true;
                    continue;
                }

                entity.movement.Move = false;
            }
        }
    }
}
