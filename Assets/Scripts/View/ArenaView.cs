using UnityEngine;

namespace Assets.Scripts.View
{
    public class ArenaView : MonoBehaviour
    {
        public Transform[] HorizontalWalls;
        public Transform[] VerticalWalls;
        public float WallThickness;

        [ContextMenu("Update walls")]
        private void Start()
        {
            /*
            foreach (var wall in HorizontalWalls)
            {
                wall.localScale = new Vector3(transform.localScale.x / WallThickness, wall.localScale.y, wall.localScale.z);
            }

            foreach (var wall in VerticalWalls)
            {
                wall.localScale = new Vector3(wall.localScale.x, wall.localScale.y, transform.localScale.z / WallThickness);
            }
            */
        }
    }
}
