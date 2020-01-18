using Assets.Scripts.Configs.Arena;
using Client.Configs;
using Client.Configs.View;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class ArenaStartupSystem : IInitializeSystem
    {
        private readonly GameContext _context;
        public ArenaStartupSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Initialize()
        {
            GenerateMap(0);
            CreatePlayer();
        }

        private void GenerateMap(int index)
        {
            var arenaConfig = ConfigsManager.Instance.ArenaConfig;
            var viewConfig = ConfigsManager.Instance.ViewConfig;
            var cellSize = arenaConfig.СellSize;
            var arena = arenaConfig.Arenas[index];

            if (!viewConfig.GetValue(ViewType.Map, out var prefab))
            {
                return;
            }

            var instance = Object.Instantiate(prefab);
            var currentScale = instance.transform.localScale;
            var sizeX = currentScale.x * cellSize * arena.Size.x;
            var sizeY = currentScale.z * cellSize * arena.Size.y;
            instance.transform.localScale = new Vector3(sizeX, currentScale.y, sizeY);
            instance.transform.position = new Vector3(-cellSize/2f, 0, -cellSize/2f);

            for (var i = 0; i < arena.Cells.Length; i++)
            {
                var cell = arena.Cells[i];
                if (cell.Type != ArenaCellType.Obstacle)
                {
                    continue;
                }

                var obstacle = _context.CreateEntity();
                var position = new Vector2Int(i % arena.Size.y, i / arena.Size.x);
                obstacle.AddPosition(new Vector2(
                    position.x * cellSize - (arena.Size.x * arenaConfig.СellSize) / 2f, 
                    position.y * cellSize - (arena.Size.y * arenaConfig.СellSize) / 2f));
                obstacle.AddViewSource(ViewType.Obstacle);
            }
        }

        private void CreatePlayer()
        {
            var player = _context.CreateEntity();
            player.AddViewSource(ViewType.Player);
            player.AddPosition(Vector2.zero);
            player.AddRotation(0);
            player.isSyncView = true;
            player.AddMovement(0.07f, false);
            player.AddDirection(Vector2.zero);
            player.isPlayer = true;
        }
    }
}