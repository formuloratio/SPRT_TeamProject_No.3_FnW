using UnityEngine;

namespace Features.Entities
{
    public abstract class InteractionObject : MonoBehaviour
    {
        protected GameObject obstacleFire;
        protected GameObject obstacleWater;

        protected int obstacleIndex { get; set; }
        protected int fireIndex { get { return 0; } }
        protected int waterIndex { get { return 1; } }

        protected bool isFire { get; set; }
        protected bool isWater { get; set; }
        protected int[] switchIndexArray;

        public virtual void GetObjectIndex() //오브젝트 순서에 따른 인덱스 추출
        {
            Transform parentTransform = this.transform;
            for (int i = 0; i < parentTransform.childCount; i++)
            {
                Transform childTransform = parentTransform.GetChild(i);

                if (childTransform.gameObject.activeSelf)
                {
                    //obstacleIndex = i;

                    if (childTransform.CompareTag("ObstacleFire"))
                    {
                        obstacleIndex = fireIndex;
                    }
                    else if (childTransform.CompareTag("ObstacleWater"))
                    {
                        obstacleIndex = waterIndex;
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (AudioManager.Instance == null) return;
            AudioManager.Instance.PlaySfx(AudioManager.Instance.deleteObjectSfx);
        }
    }
}