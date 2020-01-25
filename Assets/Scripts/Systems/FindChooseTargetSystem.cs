using System;
using System.Linq;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class FindChooseTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _hasTargetGroup;
        private readonly GameContext _gameContext;

        public FindChooseTargetSystem(Contexts contexts)
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

                GameEntity target = null;
                var minSqrDist = Single.MaxValue;
                //TODO Use KDTree 
                foreach (var possibleTarget in possibleTargets)
                {
                    var sqrDist = Vector2.SqrMagnitude(possibleTarget.position.Value - entity.position.Value);
                    if (!(sqrDist < minSqrDist))
                    {
                        continue;
                    }

                    minSqrDist = sqrDist;
                    target = possibleTarget;
                }

                entity.ReplaceTarget(target);
            }
        }
    }
}