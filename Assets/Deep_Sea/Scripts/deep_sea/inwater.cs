using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inwater : MonoBehaviour
{
    public static bool player_inwater = false;
    private Rigidbody player_rb;
    private AudioSource audioSource;
    public AudioClip audioClipsea; //�ٴ� �ĵ� �Ҹ�
    public AudioClip audioClipbpm;
    public Animation bpmeffect;
    public Transform player;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player_rb = player.GetComponent<Rigidbody>();
        audioSource.clip = audioClipsea;
        audioSource.Play();
    }

    void Update()
    {

        if (player.position.y <= 387.2f) // water surface�� �� ���
        {

            player_inwater = true; // �÷��̾ ���ӿ� �ִ� �ɷ� �Ǵ�

        }
        else
        {
            player_inwater = false; // �÷��̾ ���ӿ��� ���� �ɷ� �Ǵ�
        }

        if (player_inwater)
        {
            player_rb.drag = 0.6f; //palyer�� �ٴٿ� �� ��� �߷� 0.6
            audioSource.clip = audioClipbpm;
            audioSource.loop = false;

            if (Input.GetKeyDown("h")) // Ư�� �ɹڼ��� �ٴٸ� ���
            {
                bpmeffect.Play(); // ȭ�� ������ �ִϸ��̼�

                audioSource.Play();
            }

        }


    }

}
