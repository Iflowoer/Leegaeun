using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExRay : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))                 //GetMouseButton(1) 오른쪽 버튼 마우스가 눌렸을 때
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray를 정의하고 카메라의 마우스 위치에서 Ray를 쏜다.
                    
            RaycastHit hit;                         //Ray를 쏘고 충돌할 물체의 값을 Hit넣기 위한 정의

            if(Physics.Raycast(cast, out hit))      //충돌후의 값이 hit 있을 경우
            {
                Debug.Log(hit.collider.gameObject.name);    //충돌한 오브젝트의 이름을 받아온다.
                Debug.DrawLine(cast.origin, hit.point,Color.red, 2.0f);

                if(hit.collider.gameObject.tag=="Taget")
                {
                    Destroy(hit.collider.gameObject);
                    Point += 1;
                }
            }
            else
            {
                Point = 0;
            }

            UIText.text = Point.ToString();
        }
    }
}
