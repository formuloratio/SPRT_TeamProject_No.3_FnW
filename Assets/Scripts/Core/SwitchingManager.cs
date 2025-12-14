using UnityEngine;

public class SwitchingManager : MonoBehaviour
{
    private static SwitchingManager instance;
    public static SwitchingManager Instance
    { 
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwitchingManager>();

                if (instance == null)
                {
                    instance = new GameObject(nameof(SwitchingManager)).AddComponent<SwitchingManager>();
                }
            }

            return instance;
        }

    }

    public int[] switchTagCompare = new int[30];
    public bool isSwitching = false;

}
