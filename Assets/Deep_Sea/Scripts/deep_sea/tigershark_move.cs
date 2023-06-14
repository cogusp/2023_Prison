using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigershark_move : MonoBehaviour
{
    public float speed = 8f; //��� �̵� �ӵ�
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾ �±׸� �̿��� ã��
    }
    void Update()
    {
        Vector3 target = player.position;// �÷��̾��� ��ġ�� ��ǥ�� ����
        transform.LookAt(target);// �÷��̾ �ٶ�

        if (inwater.player_inwater)// player�� ���߿� ���� ���
        {

            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);// ���� ��ġ���� ��ǥ ��ġ�� ������ �ӵ��� �̵�

            if (player.transform.position.y <= 250f)
            {

                Destroy(gameObject);
            }

        }

    }
}
