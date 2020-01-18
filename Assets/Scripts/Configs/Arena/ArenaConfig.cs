using UnityEngine;

namespace Assets.Scripts.Configs.Arena
{
    [CreateAssetMenu]
    public class ArenaConfig : ScriptableObject
    {
        public float СellSize;

        public ArenaData[] Arenas;
    }
}