using Assets.Scripts.Configs.Arena;
using Client.Configs;
using Client.Configs.View;
using Entitas;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Systems
{
    public class ArenaStartupSystem : IInitializeSystem
    {
        private readonly GameContext _context;
        private GameObject _mapInstance;

        public ArenaStartupSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Initialize()
        {
            var playerPos = GenerateMap(0);
            CreatePlayer(playerPos);
            CreateCamera(playerPos);
        }

        private void CreateCamera(Vector2 pos)
        {
            var entity = _context.CreateEntity();
            entity.AddCamera(Camera.main);
        }

        private Vector2 GenerateMap(int index)
        {
            var arenaConfig = ConfigsManager.Instance.ArenaConfig;
            var viewConfig = ConfigsManager.Instance.ViewConfig;
            var cellSize = arenaConfig.СellSize;
            var arena = arenaConfig.Arenas[index];

            var playerPos = Vector2.zero;

            if (!viewConfig.GetValue(ViewType.Map, out var prefab))
            {
                return playerPos;
            }

            _mapInstance = Object.Instantiate(prefab);
            var currentScale = _mapInstance.transform.localScale;
            var sizeX = currentScale.x * cellSize * arena.Size.x;
            var sizeY = currentScale.z * cellSize * arena.Size.y;
            _mapInstance.transform.localScale = new Vector3(sizeX, currentScale.y, sizeY);
            _mapInstance.transform.position = new Vector3(-cellSize/2f, 0, -cellSize/2f);

            var arenaEntity = _context.CreateEntity();
            var rectSize = new Vector2(arena.Size.x * cellSize, arena.Size.y * cellSize);
            arenaEntity.AddArena(arena, new Rect(-rectSize/2f - new Vector2(cellSize/2f, cellSize/2f), rectSize), cellSize);

            
            for (var i = 0; i < arena.Cells.Length; i++)
            {
                var cell = arena.Cells[i];
                var position = new Vector2Int(i % arena.Size.x, i / arena.Size.x);
                var pos = new Vector2(
                    position.x * cellSize - (arena.Size.x * arenaConfig.СellSize) / 2f,
                    position.y * cellSize - (arena.Size.y * arenaConfig.СellSize) / 2f);

                if (cell.Type == ArenaCellType.PlayerSpawn)
                {
                    playerPos = pos;
                }

                if (cell.Type == ArenaCellType.EnemySpawn)
                {
                    CreateEnemy(pos);
                }

                if (cell.Type != ArenaCellType.Obstacle)
                {
                    continue;
                }

                var obstacle = _context.CreateEntity();
                
                obstacle.AddPosition(pos);
                obstacle.AddViewSource(ViewType.Obstacle);
                obstacle.AddViewParent(_mapInstance.transform);
            }

            _mapInstance.GetComponent<NavMeshSurface>().BuildNavMesh();

            return playerPos;
        }

        private void CreateEnemy(Vector2 pos)
        {
            var enemy = _context.CreateEntity();
            enemy.AddViewSource(ViewType.MeleeEnemy);
            enemy.AddPosition(pos);
            enemy.AddRotation(0);
            enemy.isSyncModelPosition = true;
            //enemy.AddMovement(2f, false);
            enemy.AddFraction(1, 0);
            enemy.AddTarget(null);
            enemy.isMoveToTarget = true;
        }

        private void CreatePlayer(Vector2 pos)
        {
            var player = _context.CreateEntity();
            player.AddViewSource(ViewType.Player);
            player.AddPosition(pos);
            player.AddRotation(0);
            player.isSyncModelPosition = true;
            player.isSyncViewRotation = true;
            player.AddMovement(2f, false);
            player.AddDirection(Vector2.zero);
            player.isPlayer = true;
            player.AddFraction(0, 1);
        }
    }
}