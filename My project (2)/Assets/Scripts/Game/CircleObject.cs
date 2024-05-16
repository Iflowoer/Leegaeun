using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;         //마우스 드래그 판단
    public bool isUsed;         //사용 완료 체크
    Rigidbody2D rigidbody2D;    //2D 강체 선언

    public int index;           //과일 번호 설정

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();          //오브젝트의 강체에 접근
        isUsed = false;                                     //시작할때 사용이 안되었다고 입력
        rigidbody2D.simulated = false;                      //물리 행동이 처음에는 동작하지 않게 설정
    }

    // Start is called before the first frame update
    void Start()
    {
        /*isUsed = false;                                 //시작할때 사용이 안되었다고 입력
        rigidbody2D = GetComponent<Rigidbody2D>();      //오브젝트의 강체에 접근
        rigidbody2D.simulated = false;                  //물리 행동이 처음에는 동작하지 않게 설정*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)
            return;                 //사용이 완료된 오브젝트는 업데이트 문을 그냥 돌려 보낸다. (마우스 input 적용을 막기 위해)

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //화면 스크린에서 유니티 신스 공간의 좌표를 가져온다

            float leftBorder = -5.0f + transform.localScale.x / 2f;     //반지름 만큼 이동 제한
            float rightBorder = 5.0f-transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;       //마우스 위치가 이동 제한 한곳 이상, 이하로 가면 값을 조절해서 가둔다
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                             //오브젝트 y 축 값 고정
            mousePos.z = 0;                                             //오브젝트 z 축 값 고정씩
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);          //이 오브젝트를 마우스 위치로 리니어하게 0.2 값만큼씩 이동시켜 따라간다
        }

        if (Input.GetMouseButtonDown(0)) Drag();            //마우스버튼이 눌렸을때 Drag 함수 실행
        if (Input.GetMouseButtonUp(0)) Drop();              //마우스버튼이 올라갈때 Drag 함수 실행
    }

    void Drag()                     //드래그 할 때 상태값 함수
    {
        isDrag = true;                     //드래그 중이다 t
        rigidbody2D.simulated = false;      //물리 시뮬 안함 f
    }

    void Drop()                             //드랍 할 때 상태 값 함수
    {
        isDrag = false;                     //드래그 중이다 f
        isUsed = true;                      //사용 완료 되었다. t
        rigidbody2D.simulated = true;       //물리 시뮬레이션 사용함 t

        GameObject temp = GameObject.FindWithTag("GameManager");                    //GameManager의 젠오브젝트 함수 호출
        if(temp!=null)
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }

    public void Used()
    {
        isDrag = false;                     //드래그 중이다 f
        isUsed = true;                      //사용 완료 되었다. t
        rigidbody2D.simulated = true;       //물리 시뮬레이션 사용함 t
    }

    public void OnCollisionEnter2D(Collision2D collision)                           //해당 오브젝트가 충돌 했을 때 OnCollisionEnter2D
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag=="Fruit")                                       //충돌이 같은 과일일 경우
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //충돌한 물체에서 같은 Class를 받아온다.

            if(temp.index==index)                                                   //충돌 인덱스와 내 인덱스가 같다.
            {
                if(gameObject.GetInstanceID()>collision.gameObject.GetInstanceID())     //2개 합쳐서 1개를 만들기 위해서 ID 검사 후 큰것만 동작
                {
                    //GameManager에서 합친 오브젝트를 생성
                    GameObject tempGameManager = GameObject.FindWithTag("GameManager");         //Scene에서 GameManager Tag 가지고 있는 오브젝트를 가져온다
                    if(tempGameManager !=null)                                                  //해당 오브젝트가 있을 경우
                    {
                        tempGameManager.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }

                    Destroy(temp.gameObject);                                       //충돌한 물체 제거
                    Destroy(gameObject);                                            //자신도 제거
                }
            }
        }
    }
}
