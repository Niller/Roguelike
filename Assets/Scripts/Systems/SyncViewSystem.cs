using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class SyncViewSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public SyncViewSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.SyncView);
        }
        public void Execute()
        {
            foreach (var entity in _group.GetEntities())
            {
                //TODO [Alexander Borisov] Use different systems?
                var position = entity.position;
                var view = entity.view;

                if (position != null)
                {
                    view.Value.transform.position = new Vector3(position.Value.x, 0, position.Value.y);
                }

                var rotation = entity.rotation;
                if (rotation != null)
                {
                    view.Value.transform.rotation = Quaternion.Euler(0, rotation.Value, 0);
                }
            }
        }
    }
}