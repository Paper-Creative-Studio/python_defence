using UnityEngine;

namespace PythonDefence.Building
{
    [System.Serializable]
    public class BuildingStage
    {
        public int[] nextStageCost;
        public Collider2D[] colliders;
        public Sprite sprite;

    }
}