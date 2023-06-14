using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// bpm�� json ���Ϸ� �����ϴ� ��ũ��Ʈ 

[System.Serializable]
public class BpmData
{
    public List<string> bpm = new List<string>();   // bpm�� ���� List
}

public static class BpmSave
{
    private static string SavePath => Application.dataPath + "/saves/"; // json ���� ���� ���

    public static void Save(BpmData bpmData, string saveFileName)   // bpm �����Ϳ� ���� �̸� ����
    {
        if(!Directory.Exists(SavePath))     // ���� ��ΰ� �������� ������
        {
            Directory.CreateDirectory(SavePath);    // ���� ��� ����
        }
        
        string saveJson = JsonUtility.ToJson(bpmData, true);    // bpm List json �������� ��ȯ

        string saveFilePath = SavePath + saveFileName + ".json";    // ���� ���� ��� ����

        File.WriteAllText(saveFilePath, saveJson);              // json ������ ���Ͽ� ����
        Debug.Log("Save Success: " + saveFilePath);             // ���������� �۵��Ǿ����� Ȯ��
    }
}
