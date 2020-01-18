using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SyncModelPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public SyncModelPositionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.SyncModelPosition);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                if (entity.hasPosition && entity.hasView)
                {
                    var viewPosition = entity.view.Value.transform.localPosition;
                    entity.position.Value = new Vector2(viewPosition.x, viewPosition.z);
                }
            }
        }
    }
}