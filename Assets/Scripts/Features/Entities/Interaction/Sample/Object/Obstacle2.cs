using UnityEngine;
using Utils;

namespace Features.Entities.Interaction.Sample
{
    public class Obstacle2 : MonoBehaviour, IElementObject
    {
        [SerializeField] protected ElementType elementType;
        public ElementType ElementType
        {
            get => elementType;
            set => elementType = value;
        }
        [SerializeField] protected ObstacleType obstacleType;
        public ObstacleType ObstacleType
        {
            get => obstacleType;
            set => obstacleType = value;
        }
    }

    public enum ObstacleType
    {
        Vanishing, Passing
    }
}