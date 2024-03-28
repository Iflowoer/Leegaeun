using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCylinderMove : MonoBehaviour
{

    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오브젝트의 좌표 설정
        //Vector3 (X,Y,Z) 축을 의미 . new 는 클래스를 쓰기 위해 선언
        // X = X + 5 <- X += 5 (축약 표시)
        // Time.deltaTime 프레임 간격 시간 ex) 60fps 일경우 0.1초라는 수치를 반환
        gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;

        if(gameObject.transform.position.x<-12.0f)
        {
            gameObject.transform.position += new Vector3(24.0f, 0.0f, 0.0f);
        }
    }
}
