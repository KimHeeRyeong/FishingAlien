using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class btSc : MonoBehaviour
{
    public struct jsonInfo
    {        
        public int _i;
        public int _i2;
    }

    int count = 1;
    jsonInfo[] jAry;
    // Start is called before the first frame update
    void Start()
    {
        jAry = new jsonInfo[5];
        for (int i = 0; i < 5; i++) {
            jAry[i]._i = new int();
            jAry[i]._i2 = new int();
        }

    }

    // Update is called once per frame
    float rad = 90;
    void Update()
    {
        if (rad > 0)
        {
            rad -= 1;

            float f = Mathf.Sin(Mathf.Deg2Rad * (90-rad));
            Debug.Log(f);
            this.transform.position -= new Vector3(0, f * 10, 0);
        }
    }
    public void click()
    {
        byte[] data;
        string jsonData;
        FileStream fileStream = new FileStream(string.Format("{0}:{1}.json", Application.dataPath, "testJson"), FileMode.OpenOrCreate);


        data = new byte[fileStream.Length];
        fileStream.Read(data, 0, data.Length);

        jsonData = Encoding.UTF8.GetString(data);

        if (fileStream.Length > 0)
        {
            jAry = JsonUtility.FromJson<jsonInfo[]>(jsonData);
        }

        jAry[count]._i = count;
        jAry[count]._i2 = count * 10;
        string ss = JsonUtility.ToJson(jAry);
        count++;
        data = Encoding.UTF8.GetBytes(ss);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();



    }
}
