using System;
using UnityEngine;

namespace Assets.Scripts.Configs.Arena
{
    [Serializable]
    public class ArenaData
    {
        public Vector2Int Size;
        public ArenaCell[] Cells;
    }
}
