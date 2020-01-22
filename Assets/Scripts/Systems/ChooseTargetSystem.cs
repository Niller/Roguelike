using System.Linq;
using Entitas;

namespace Assets.Scripts.Systems
{
    public class ChooseTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _hasTargetGroup;
        private readonly GameContext _gameContext;

        public ChooseTargetSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _hasTargetGroup = contexts.game.GetGroup(GameMatcher.Target);
        }

        public void Execute()
        {
            foreach (var entity in _hasTargetGroup.GetEntities())
            {
                var enemyFraction = entity.fraction.EnemyFraction;
                var possibleTargets = _gameContext.GetEntitiesWithFraction(enemyFraction);

                if (possibleTargets.Count > 0)
                {
                    entity.target.Value = possibleTargets.First();
                }
            }
        }
    }
}