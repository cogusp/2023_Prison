using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class lockerOpen : MonoBehaviour
{
    //�繰�� ���� �ӵ��� ���� �Ҹ� ������ ����Ǵ� script
    //���� �ӵ�(�Ҹ� ũ��)�� ������ ��� ���ε��.
    private bool isTriggered = false;
    private bool isTriggered2 = false;
    private float GaugeTimer;
    
    private float Gauge = 0.3f;

    public GameObject ob;//������ hit�� ����ؼ� ��� object�� �����ߴµ�, ���ŷο��� �׽�Ʈ������ ������ �繰�� ���� ���Ƿ� ������.

    public AudioClip doorSound;
    private AudioSource audioSource;

    //Angular Velocity, ��α� ����
    Quaternion previousRotation; //�� �������� �����̼� ��
    Vector3 angularVelocity; //���ӵ��� ������ ����
    Vector3 speed;

    public bool DoorEventTrue = false;

    public Vector3 GetPedestrianAngularVelocity()//�� �ӵ��� ���ϴ� �Լ�
    {
        Quaternion deltaRotation = ob.transform.rotation * Quaternion.Inverse(previousRotation);

        previousRotation = ob.transform.rotation;

        deltaRotation.ToAngleAxis(out var angle, out var axis);

        //�������� �������� ��ȯ
        angle *= Mathf.Deg2Rad;

        angularVelocity = (1.0f / Time.deltaTime) * angle * axis;

        //���ӵ� ��ȯ
        return angularVelocity;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = doorSound;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        isTriggered = Input.GetMouseButton(0);//�� ���� ���ؼ� �ӽ÷� ���
        isTriggered2 = Input.GetMouseButton(1);//���� �ݱ� ���ؼ� �ӽ÷� ���
        //audioSource.Play();

        if (isTriggered || isTriggered2)
        {
            speed = GetPedestrianAngularVelocity();
            Gauge += Time.deltaTime * speed.magnitude; //���ӵ��� �� ����(����) ũ��
            if(Gauge > 0.7)
            {
                //���ε��� �Ҹ�, �ִϸ��̼� ����
                DoorEventTrue = true;
                Gauge = 0.3f;
            }
        }
        else
        {
            Gauge = 0.3f;
        }

        if (isTriggered)
        {
            GaugeTimer = -1 * Time.deltaTime * 20;//���⿡ �� ���ϱ�
            audioSource.volume = Gauge;
            if (ob.transform.eulerAngles.y >= 170) ob.transform.Rotate(0, GaugeTimer, 0);
            //Debug.Log("ob.transform.rotation.y = " + ob.transform.rotation.y);
            //Debug.Log("ob.transform.eulerAngles.y = " + ob.transform.eulerAngles.y);
        }
        else if (isTriggered2)
        {
            GaugeTimer = Time.deltaTime * 20;//���⿡ �� ���ϱ�
            ob.transform.Rotate(0, GaugeTimer, 0);
            Debug.Log("Close");
            audioSource.volume = Gauge;
            
            if (ob.transform.eulerAngles.y >= 270f) ob.transform.rotation = Quaternion.Euler(0, 270, 0);
            
            //Debug.Log("ob.transform.eulerAngles.y = " + ob.transform.eulerAngles.y);
        }
        else
        {
            GaugeTimer = 0;
        }
    }
}
