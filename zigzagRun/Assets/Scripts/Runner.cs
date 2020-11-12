using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{

    public float margin;

    Vector3 direction;

    private void Start()
    {
        direction = Vector3.forward;
    }

    private void Update()
    {
        // 원터치 입력
        // 입력을 어디서 받을지는 고민
        if(Input.GetMouseButtonDown(0))
        {
            Turn();
        }

    }

    // 그라운드 체크
    private void FixedUpdate()
    {
        GroundCheck();
    }

    // 회전
    private void Turn()
    {
        direction = direction == Vector3.forward ? Vector3.right : Vector3.forward;
        Quaternion newRot = Quaternion.LookRotation(direction);
        transform.rotation = newRot;
    }

    private void GroundCheck()
    {

        float dist = 1f;
        Vector3 origin = transform.position + Vector3.up * 0.5f;
        Vector3 fOrigin = origin + transform.forward * margin;
        Vector3 lOrigin = origin - transform.right * margin;
        Vector3 rOrigin = origin + transform.right * margin;
        RaycastHit front, left, right;

        bool fHit = Physics.Raycast(fOrigin, -Vector3.up, out front, dist);
        bool lHit = Physics.Raycast(lOrigin, -Vector3.up, out left, dist);
        bool rHit = Physics.Raycast(rOrigin, -Vector3.up, out right, dist);

        DrawGroundRay(fOrigin, fHit ? Color.green : Color.red);
        DrawGroundRay(lOrigin, lHit ? Color.green : Color.red);
        DrawGroundRay(rOrigin, rHit ? Color.green : Color.red);

        if (!fHit && !lHit && !rHit)
        {
            // 패배
            // 패배하면 패배 플로우
        }
        else if (lHit || rHit || fHit)
        {
            // 반 걸침
            // 애니메이션 블랜드
        }
        else if (lHit && rHit && fHit)
        {
            // 정상
            // 애니메이션 블랜드 제거
        }
    }

    private void DrawGroundRay(Vector3 origin, Color color)
    {
        Debug.DrawRay(origin, -Vector3.up, color);
    }




    /*


    시작할 때 블럭 컬러랑 배경 달라
     
    블럭을 종류별로 만들어서 프리팹으로 가지고 있음

    생성 된 블럭은 큐에 집어 넣고 이미 지나간 블럭은 소멸시킴

    캐릭터는 포워드로 직진함
    90도로 방향만 전환 가능

    블럭에는 코인이 있는 블럭도 존재

    코인을 모으면 스토어에서 캐릭터 뽑기 및 장착 가

    무한으로 진행하고 실시간으로 미터기 증가
    시간에 따라 이동속도 증가

    패배하면 종료 플로우  
     

    #블럭 설치
    각 블럭은 우측 방향 좌측 방향 블럭으로 나눠짐
    헤더와 테일을 가지고 있음

    테일은 헤더에 연결 됨



     
     */


}
