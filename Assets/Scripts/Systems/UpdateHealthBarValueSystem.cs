using System.Collections.Generic;
using Entitas;

namespace Assets.Scripts.Systems
{
    public class UpdateHealthBarValueSystem : ReactiveSystem<GameEntity>
    {
        public UpdateHealthBarValueSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public UpdateHealthBarValueSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHealthBar;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.healthBar.HealthBar.UpdateValues(gameEntity.health);
            }
        }
    }
}