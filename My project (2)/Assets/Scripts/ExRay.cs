using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExRay : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))                 //GetMouseButton(1) ������ ��ư ���콺�� ������ ��
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);   //Ray�� �����ϰ� ī�޶��� ���콺 ��ġ���� Ray�� ���.
                    
            RaycastHit hit;                         //Ray�� ��� �浹�� ��ü�� ���� Hit�ֱ� ���� ����

            if(Physics.Raycast(cast, out hit))      //�浹���� ���� hit ���� ���
            {
                Debug.Log(hit.collider.gameObject.name);    //�浹�� ������Ʈ�� �̸��� �޾ƿ´�.
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
