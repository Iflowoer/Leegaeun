using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;         //���콺 �巡�� �Ǵ�
    public bool isUsed;         //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;    //2D ��ü ����

    // Start is called before the first frame update
    void Start()
    {
        isUsed = false;                 //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D = GetComponent<Rigidbody2D>();      //������Ʈ�� ��ü�� ����
        rigidbody2D.simulated = false;                  //���� �ൿ�� ó������ �������� �ʰ� ����
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed)
            return;                 //����� �Ϸ�� ������Ʈ�� ������Ʈ ���� �׳� ���� ������. (���콺 input ������ ���� ����)

        if(isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //ȭ�� ��ũ������ ����Ƽ �Ž� ������ ��ǥ�� �����´�

            float leftBorder = -5.0f + transform.localScale.x / 2f;     //������ ��ŭ �̵� ����
            float rightBorder = 5.0f-transform.localScale.x / 2f;

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;       //���콺 ��ġ�� �̵� ���� �Ѱ� �̻�, ���Ϸ� ���� ���� �����ؼ� ���д�
            if (mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;                                             //������Ʈ y �� �� ����
            mousePos.z = 0;                                             //������Ʈ z �� �� ������
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);          //�� ������Ʈ�� ���콺 ��ġ�� ���Ͼ��ϰ� 0.2 ����ŭ�� �̵����� ���󰣴�
        }

        if (Input.GetMouseButtonDown(0)) Drag();            //���콺��ư�� �������� Drag �Լ� ����
        if (Input.GetMouseButtonUp(0)) Drop();              //���콺��ư�� �ö󰥶� Drag �Լ� ����
    }

    void Drag()                     //�巡�� �� �� ���°� �Լ�
    {
        isDrag = true;                     //�巡�� ���̴� t
        rigidbody2D.simulated = false;      //���� �ù� ���� f
    }

    void Drop()                             //��� �� �� ���� �� �Լ�
    {
        isDrag = false;                     //�巡�� ���̴� f
        isUsed = true;                      //��� �Ϸ� �Ǿ���. t
        rigidbody2D.simulated = true;       //���� �ùķ��̼� ����� t

        GameObject temp = GameObject.FindWithTag("GameManager");
        if(temp!=null)
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }
}
