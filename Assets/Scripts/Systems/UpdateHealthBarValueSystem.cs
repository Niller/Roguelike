using System;
using System.Collections.Generic;
using Assets.Scripts.Gui;
using Client.Configs;
using Client.Configs.View;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;

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
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                if (!gameEntity.hasHealthBar)
                {
                    if (ConfigsManager.Instance.ViewConfig.GetValue(ViewType.HealthBar, out var gameObject))
                    {
                        var healthBar = Object.Instantiate(gameObject, HudManager.Instance.transform).GetComponent<HealthBarController>();
                        gameEntity.AddHealthBar(healthBar);
                    }
                    else
                    {
                        continue;
                    }

                }

                gameEntity.healthBar.HealthBar.UpdateValues(gameEntity.health);
            }
        }
    }
}