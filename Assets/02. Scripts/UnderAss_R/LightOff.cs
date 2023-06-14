using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{//�� ������Ʈ�� ���� �÷��̾ ����ٴϰ� �ϱ�
    private GameObject player;
    private Vector3 TargetPos;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void FixedUpdate()
    {
        TargetPos = new Vector3(
            player.transform.position.x + 1,
            player.transform.position.y + 2,
            player.transform.position.z
            );
        this.transform.position = TargetPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))//�Ҳ���
        {
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("Light2"))//���� ������ ����
        {
            Transform t = other.gameObject.GetComponentInChildren<Transform>(true);
            t.GetChild(0).gameObject.SetActive(true);
        }
    }
}