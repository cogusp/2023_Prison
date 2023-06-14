using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BabyDoll : MonoBehaviour
{
    /*
    public float rotSpeed = 2f;
    public float movementSpeed = 400f;

    private AudioSource audioSource;
    public AudioClip DroppingDoll;

    public Transform player;
    private Animator animator;

    
    public bool[] isEventCalled = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vavoid = Vector3.zero;
        Vector3 direction = player.position + vavoid - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
            rotSpeed * Time.deltaTime);
        Vector3 forward = transform.forward;

        //animator.SetBool("Head_Move", true);


        if (FTU.Instance.BPMEvent == 1 && !isEventCalled[0])
        {
            Debug.Log("이동");
            isEventCalled[0] = true;
            transform.position += forward * movementSpeed * Time.deltaTime;
        }
        else if (FTU.Instance.BPMEvent == 2 && !isEventCalled[1])
        {
            Debug.Log("이동");
            isEventCalled[1] = true;
            transform.position += forward * movementSpeed * Time.deltaTime;
        }
        else if (FTU.Instance.BPMEvent == 3 && !isEventCalled[2])
        {
            Debug.Log("이동");
            isEventCalled[2] = true;
            transform.position += forward * movementSpeed * Time.deltaTime;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("ground"))
        {
            audioSource.Play();
            movementSpeed = 0;
            rotSpeed = 0;
        }
    }*/

    public float rotSpeed = 2f;
    public float movementSpeed = 400f;

    private AudioSource audioSource;
    public AudioClip DroppingDoll;

    public Transform player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 vavoid = Vector3.zero;
        Vector3 direction = player.position + vavoid - this.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
        Vector3 forward = transform.forward;

        //animator.SetBool("Head_Move", true);


        if (Input.GetKeyDown("h"))
        {
            transform.position += forward * movementSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("ground"))
        {
            audioSource.Play();
            movementSpeed = 0;
            rotSpeed = 0;
        }

    }
}