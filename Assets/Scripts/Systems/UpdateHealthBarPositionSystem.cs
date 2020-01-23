using Entitas;

namespace Assets.Scripts.Systems
{
    public class UpdateHealthBarPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public UpdateHealthBarPositionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.HealthBar);
        }

        public void Execute()
        {
            foreach (var gameEntity in _group.GetEntities())
            {
                gameEntity.healthBar.HealthBar.UpdatePosition(gameEntity.view.Value.transform);
            }            
        }
    }
}