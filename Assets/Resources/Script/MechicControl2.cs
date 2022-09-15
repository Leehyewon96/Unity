using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MechicControl2 : MonoBehaviour
{
    public float runSpeed = 6.0f;
    public float rotationSpeed = 360.0f;

    Animator animator;
    NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}

/*
 1.미로구성
2.임의의 위치에 아이템 생성
3. 플레이어가 충돌하면 아이템 획득
4. 적 플레이어가 먼저 충돌하면 적 아이템 획득
5. 적과 플레이어가 충돌하면 플레이어 데미지 hp or 목숨개수로 처리
6. 플레이어가 적을 공격하면 적은 일정시간 스턴 상태에 들어간다.

-선택
7-1. 플레이어 머리위에 생성된 아이템 방향을 알리는 화살표 표시
7-2. 우측 상단에 미니맵으로 생성된 아이템 위치를 표시
 */

/*
 게임시작할때
 미로를 5초동안 보여준다음 시작위치 시점으로 가기
 */
