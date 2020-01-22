using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class MoveToTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public MoveToTargetSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.MoveToTarget);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (!entity.hasTarget || entity.target.Value == null)
                {
                    continue;
                }

                if (!entity.hasNavMeshAgent)
                {
                    continue;
                }

                var target = entity.target.Value.position.Value;
                entity.navMeshAgent.Agent.SetDestination(new Vector3(target.x, 0, target.y));
                Debug.Log(target);
            }
        }
    }
}