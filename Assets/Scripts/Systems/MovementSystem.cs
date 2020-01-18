using Entitas;

namespace Assets.Scripts.Systems
{
    public class MovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MovementSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.Movement);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (!entity.movement.Move)
                {
                    continue;
                }

                if (entity.hasDirection)
                {
                    var offset = entity.direction.Value * entity.movement.Speed;
                    entity.position.Value += offset;
                }

            }
        }
    }
}