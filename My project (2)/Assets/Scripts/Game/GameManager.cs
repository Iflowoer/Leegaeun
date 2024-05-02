using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject CircleObject;         //물체 프리팹을 가져옴
    public Transform genTransform;          //생성위이 설정
    public float timeCheck;                 //생성 시간 설정 변구 float
    public bool isGen;                      //생성체크 bool

    public void GenObject()                 //생성 관련 변수값 변경 시켜주는 함수
    {
        isGen = false;                      //생성 완료 되엇으니 bool을 false 변경
        timeCheck = 1.0f;                   //생성 완료 후 1.0초로 시간 초기화
    }

    // Start is called before the first frame update
    void Start()
    {
        GenObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen==false)
        {
            timeCheck -= Time.deltaTime;
            if(timeCheck<0.0f)
            {
                GameObject Temp = Instantiate(CircleObject);
                Temp.transform.position = genTransform.position;
                isGen = true;
            }
        }
    }
}
