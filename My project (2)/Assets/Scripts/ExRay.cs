using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExRay : MonoBehaviour
{
    public Text UIText;
    public int Point;
    public float checkEndTime = 30.0f;

    // Update is called once per frame
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if(checkEndTime<=0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultScene");
        }

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
                    if (Point >= 10) DoChangeScene();
                }
            }
            else
            {
                Point = 0;
            }

            UIText.text = Point.ToString();
        }
    }

    void DoChangeScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}
