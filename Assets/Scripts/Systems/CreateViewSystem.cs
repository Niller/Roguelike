using System.Collections.Generic;
using Client.Configs;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class CreateViewSystem : ReactiveSystem<GameEntity>
    {
        public CreateViewSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public CreateViewSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ViewSource);
        }

        protected override bool Filter(GameEntity entity)
        {
            return !entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var viewSource = entity.viewSource;
                var viewType = viewSource.ViewType;
                Debug.Log($"Try create view {viewType} for entity {entity}");

                if (!ConfigsManager.Instance.ViewConfig.GetValue(viewType, out var prefab))
                {
                    Debug.LogError($"Unable to find view for type {viewType}");
                    continue;
                }

                var instance = Object.Instantiate(prefab);

                if (entity.hasPosition)
                {
                    instance.transform.position = new Vector3(entity.position.Value.x, 0, entity.position.Value.y);
                }

                if (entity.hasRotation)
                {
                    instance.transform.rotation = Quaternion.Euler(0, entity.rotation.Value, 0);
                }

                entity.AddView(instance);
            }
        }
    }
}