using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public bool isOff = false;
    public bool isWork = false;

    // 스위치 인덱스랑 같아야 함 20 ~ 29 사이 지정
    public int tripIndex = 20;

    void Update()
    {
        RemoveTrip();

        if (!isOff)
        {
            if (!isWork)
            {
                isWork = true;
                StartCoroutine(WaitInstantiate());
            }
        }
    }

    public void RemoveTrip()
    {
        if (SwitchingManager.Instance.isSwitching == true && SwitchingManager.Instance.switchTagCompare[tripIndex] == 1)
        {
            isOff = true;
            Debug.Log("트립 제거");
        }
    }

    void SpawnArrow()
    {
        Transform newTrans = this.transform;
        Vector3 spawnPosition = newTrans.position;
        Quaternion newRotation = Quaternion.Euler(0, 0, 90);

        Instantiate(arrowPrefab, spawnPosition, newRotation);

        isWork = false;
    }

    IEnumerator WaitInstantiate()
    {
        yield return new WaitForSeconds(3.0f);
        SpawnArrow();
    }
}
