using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 심박수 UI 표시 및 json 파일 저장 스크립트

public class BpmManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI BPM_TextMeshPro;     //  심박수 UI
    private FTU _firebaseToUnity;
    public string FirebaseManagerName = "FTUManager";

    private double currentBPM = 0;      //  현재 심박수
    private float timer = 0;

    BpmData bpmData = new BpmData();    // json 파일로 저장할 데이터 객체
    private string fileName;    // json 파일명

    void Start()
    {
        _firebaseToUnity = GameObject.Find(FirebaseManagerName).GetComponent<FTU>();
        fileName = "test";      // json 파일명

        BPM_TextMeshPro.text = "--";      // 첫 시작 시 심박수 UI
    }
    
    // Update is called once per frame
    void Update()
    {
        currentBPM = Double.Parse(_firebaseToUnity.GetBpmValues(0));    // 현재 심박수 저장

        
        timer += Time.deltaTime;

        if (timer > 1)  // 1초에 한번씩 심박수 표시 및 저장하기 위함
        {
            timer = 0;
            Debug.Log("출력");
            if(currentBPM != 0.0)
            {
                BPM_TextMeshPro.text = currentBPM.ToString();       // UI에 심박수 표시

                bpmData.bpm.Add(currentBPM.ToString());     // bpm 리스트에 데이터베이스에서 가져온 심박수 저장

                BpmSave.Save(bpmData, fileName);            // json 파일에 심박수 저장
            }
                
            else
            {
                Debug.Log("0으로 측정 중. 이전 값을 출력합니다");
            }

        }

    }
}
