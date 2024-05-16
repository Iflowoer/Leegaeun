using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;         //���콺 �巡�� �Ǵ�
    public bool isUsed;         //��� �Ϸ� üũ
    Rigidbody2D rigidbody2D;    //2D ��ü ����

    public int index;           //���� ��ȣ ����

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();          //������Ʈ�� ��ü�� ����
        isUsed = false;                                     //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D.simulated = false;                      //���� �ൿ�� ó������ �������� �ʰ� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        /*isUsed = false;                                 //�����Ҷ� ����� �ȵǾ��ٰ� �Է�
        rigidbody2D = GetComponent<Rigidbody2D>();      //������Ʈ�� ��ü�� ����
        rigidbody2D.simulated = false;                  //���� �ൿ�� ó������ �������� �ʰ� ����*/
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

        GameObject temp = GameObject.FindWithTag("GameManager");                    //GameManager�� ��������Ʈ �Լ� ȣ��
        if(temp!=null)
        {
            temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }

    public void Used()
    {
        isDrag = false;                     //�巡�� ���̴� f
        isUsed = true;                      //��� �Ϸ� �Ǿ���. t
        rigidbody2D.simulated = true;       //���� �ùķ��̼� ����� t
    }

    public void OnCollisionEnter2D(Collision2D collision)                           //�ش� ������Ʈ�� �浹 ���� �� OnCollisionEnter2D
    {
        if (index >= 7)
            return;

        if(collision.gameObject.tag=="Fruit")                                       //�浹�� ���� ������ ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //�浹�� ��ü���� ���� Class�� �޾ƿ´�.

            if(temp.index==index)                                                   //�浹 �ε����� �� �ε����� ����.
            {
                if(gameObject.GetInstanceID()>collision.gameObject.GetInstanceID())     //2�� ���ļ� 1���� ����� ���ؼ� ID �˻� �� ū�͸� ����
                {
                    //GameManager���� ��ģ ������Ʈ�� ����
                    GameObject tempGameManager = GameObject.FindWithTag("GameManager");         //Scene���� GameManager Tag ������ �ִ� ������Ʈ�� �����´�
                    if(tempGameManager !=null)                                                  //�ش� ������Ʈ�� ���� ���
                    {
                        tempGameManager.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);
                    }

                    Destroy(temp.gameObject);                                       //�浹�� ��ü ����
                    Destroy(gameObject);                                            //�ڽŵ� ����
                }
            }
        }
    }
}
