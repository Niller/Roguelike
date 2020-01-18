using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SyncViewPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public SyncViewPositionSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.SyncViewPosition);
        }

        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                var position = entity.position;
                var view = entity.view;

                if (position != null)
                {
                    view.Value.transform.position = new Vector3(position.Value.x, 0, position.Value.y);
                }
            }
        }
    }
}