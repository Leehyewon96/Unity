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
 1.�̷α���
2.������ ��ġ�� ������ ����
3. �÷��̾ �浹�ϸ� ������ ȹ��
4. �� �÷��̾ ���� �浹�ϸ� �� ������ ȹ��
5. ���� �÷��̾ �浹�ϸ� �÷��̾� ������ hp or ��������� ó��
6. �÷��̾ ���� �����ϸ� ���� �����ð� ���� ���¿� ����.

-����
7-1. �÷��̾� �Ӹ����� ������ ������ ������ �˸��� ȭ��ǥ ǥ��
7-2. ���� ��ܿ� �̴ϸ����� ������ ������ ��ġ�� ǥ��
 */

/*
 ���ӽ����Ҷ�
 �̷θ� 5�ʵ��� �����ش��� ������ġ �������� ����
 */
