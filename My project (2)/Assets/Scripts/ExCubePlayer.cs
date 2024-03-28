using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExCubePlayer : MonoBehaviour
{
    
    public Text TextUI = null;          //텍스트 ui
    public int Count = 0;               //마우스 클릭 카운터
    public float Power = 100;           //물리 힘 수치

    public int Point = 0;               //점수 수치
    public float checkTime = 0.0f;      //시간 체크 표시

    public Rigidbody m_Rigidbody;       //오브젝트의 강체

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;            //시간을 누적해서 쌓는다.
        if (checkTime >= 1.0f)                  //1초마다 어떤 행동을 한다.
        {
            Point += 1;                         //1초마다 점수 1점을 올린다.
            checkTime = 0.0f;                   //시간을 초기화 한다.
        }

    
        if (Input.GetKeyDown(KeyCode.Space)) //스페이스를 누를 때 //마우스 왼쪽 입력이 되었을 때 조건 GetMouseButtonDown
        {
            Power = Random.Range(100, 200);                 //100 ~ 200 사이의 값의 힘을 준다.
            m_Rigidbody.AddForce(transform.up * Power);     //Y축으로 설정한 힘을 준다.
        }

        TextUI.text = Point.ToString();

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        Point = 0;
        gameObject.transform.position = Vector3.zero;
    }
}
