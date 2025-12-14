using UnityEngine;

namespace Features.Entities.Interaction.Sample
{
    public class ReactiveObstacle2 : Obstacle2, IReactiveObject
    {
        [SerializeField]private ActionType actionType;
        public ActionType ActionType => actionType;

        [SerializeField]private ReactiveType reactiveType;
        public ReactiveType ReactiveType => reactiveType;

        public void Activate()
        {
            if (this.reactiveType == ReactiveType.Vanishing)
            {
                Destroy(this.gameObject);
            }
        }
        public void Deactivate() { }
    }
}