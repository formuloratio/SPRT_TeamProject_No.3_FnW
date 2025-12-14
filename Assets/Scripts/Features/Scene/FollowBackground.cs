using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBackground : MonoBehaviour
{
    public Transform targetNum1;
    public Transform targetNum2;

    // 배경의 초기 x 위치를 저장할 변수
    private float startPosX;

    // targetNum의 초기 x 위치를 저장할 변수
    private float targetStartPosX;

    private const float ParallaxFactor = 0.2f;

    void Start()
    {
        if (targetNum1 == null || targetNum2 == null)
            return;

        // 배경의 초기 위치 저장
        startPosX = transform.position.x + ((targetNum1.position.x + targetNum1.position.x) / 2) / 3;

        // 타겟 초기 위치는 2 개체 위치의 중간값
        targetStartPosX = (targetNum1.position.x + targetNum1.position.x) / 2;
    }

    void Update()
    {
        if (targetNum1 == null || targetNum2 == null)
            return;

        // targetNum이 초기 위치로부터 얼마나 이동했는지 계산
        float travelX1 = targetNum1.position.x - targetStartPosX;
        float travelX2 = targetNum2.position.x - targetStartPosX;

        // 평균 이동 거리에 1/5 (0.2) 패럴랙스 계수를 적용
        float distance = ((travelX1 + travelX2) / 2) * ParallaxFactor;

        // 배경의 새로운 x 위치 = 배경의 초기 위치 + (축소된 이동 거리)
        float newPosX = startPosX + distance;

        transform.position = new Vector3(
            newPosX,
            transform.position.y, // y와 z 위치는 유지
            transform.position.z
        );
    }
}