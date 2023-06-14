using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class footStep : MonoBehaviour
{
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private double velocity;

    public AudioClip[] footClip;
    private AudioSource footSource;
    int x, y;

    void Start()
    {
        footSource = GetComponent<AudioSource>();
        previousPosition = transform.position; //�ʱ�ȭ      
    }

    void Update()
    {
        //�̵����� �Ǵ�
        currentPosition = transform.position; //�� �����Ӹ��� currentPosition�� ���� Position�� �ʱ�ȭ ���ش�
        var distance = Vector3.Distance(previousPosition, currentPosition);
        velocity = distance / Time.deltaTime; //�� �� �� �� ����� �ӷ±��ϱ�
        previousPosition = currentPosition;

        if(velocity >= 14)
        {
            StartCoroutine(stepSound());
        }
        else
        {
            footSource.Stop();
        }

    }

    IEnumerator stepSound() {
        x = Random.Range(0, footClip.Length);
        y = Random.Range(0, footClip.Length);
        footSource.clip = footClip[x];
        footSource.Play();
        yield return new WaitForSeconds(1.5f);
        footSource.clip = footClip[y];
        footSource.Play();
    }
}