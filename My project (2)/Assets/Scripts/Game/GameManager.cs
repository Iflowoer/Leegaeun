using System;                               //Action을 사용하기 위해서
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] CircleObject;       //물체 프리팹을 가져옴
    public Transform genTransform;          //생성위치 설정
    public float timeCheck;                 //생성 시간 설정 변구 float
    public bool isGen;                      //생성체크 bool

    public int Point;       //점수    
    public int BestScore;   //최고점수

    public static event Action<int> OnPointChanged;         //점수가 변경 되었을 때 이벤트를 발생 시킨다.
    public static event Action<int> OnBestScoreChanged;     //최고 점수가 변경 되었을 때 이벤트를 발생 시킨다.


    public void GenObject()                 //생성 관련 변수값 변경 시켜주는 함수
    {
        isGen = false;                      //생성 완료 되엇으니 bool을 false 변경
        timeCheck = 1.0f;                   //생성 완료 후 1.0초로 시간 초기화
    }

    // Start is called before the first frame update
    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        GenObject();
        OnPointChanged?.Invoke(Point);
        OnBestScoreChanged?.Invoke(BestScore);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGen==false)
        {
            timeCheck -= Time.deltaTime;
            if(timeCheck<0.0f)
            {
                int RandNumber = UnityEngine.Random.Range(0, 2);                        //0~1의 랜덤 넘버 생성
                GameObject Temp = Instantiate(CircleObject[RandNumber]);    //프리팹 생성 후 Temp 오브젝트에 넣는다.
                Temp.transform.position = genTransform.position;            //고정 위치에 생성 시킨다.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)            //충돌한 물체의 인덱스 번호와 위치를 가져온다.
    {
        GameObject Temp = Instantiate(CircleObject[index]);         //생성된 과일 오브젝트를 Temp에 넣는다.
        Temp.transform.position = position;                         //Temp 오브젝트의 위치는 함수로 받아온 위치값
        Temp.GetComponent<CircleObject>().Used();                 //생성되었을때 사용되었다고 표시 해줘야함

        Point += (int)Mathf.Pow(index, 2) * 10;                     //index 의 2승으로 포인트 증가 POW 함수 활용
        OnPointChanged?.Invoke(Point);                              //포인트가 변경 되었을 때 이벤트에 변경 되었다고 알림
    }

    public void EndGame()                                           //게임 종료 되었을 때 함수
    {
        int BestScore = PlayerPrefs.GetInt("BestScore");            //기존에 저장된 점수를 불러온다.

        if(Point>BestScore)                                         //기존 포인트와 비교한다.
        {
            BestScore = Point;
            PlayerPrefs.SetInt("BestScore", BestScore);                 //포인트가 더 클 경우 저장한다.
            OnBestScoreChanged?.Invoke(BestScore);
        }

        //종료 시 해야 할일 나중에 추가
    }
}
