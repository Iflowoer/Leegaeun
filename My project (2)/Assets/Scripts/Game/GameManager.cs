using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] CircleObject;       //��ü �������� ������
    public Transform genTransform;          //�������� ����
    public float timeCheck;                 //���� �ð� ���� ���� float
    public bool isGen;                      //����üũ bool

    public void GenObject()                 //���� ���� ������ ���� �����ִ� �Լ�
    {
        isGen = false;                      //���� �Ϸ� �Ǿ����� bool�� false ����
        timeCheck = 1.0f;                   //���� �Ϸ� �� 1.0�ʷ� �ð� �ʱ�ȭ
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
                int RandNumber = Random.Range(0, 2);                        //0~1�� ���� �ѹ� ����
                GameObject Temp = Instantiate(CircleObject[RandNumber]);    //������ ���� �� Temp ������Ʈ�� �ִ´�.
                Temp.transform.position = genTransform.position;            //���� ��ġ�� ���� ��Ų��.
                isGen = true;
            }
        }
    }

    public void MergeObject(int index, Vector3 position)            //�浹�� ��ü�� �ε��� ��ȣ�� ��ġ�� �����´�.
    {
        GameObject Temp = Instantiate(CircleObject[index]);         //������ ���� ������Ʈ�� Temp�� �ִ´�.
        Temp.transform.position = position;                         //Temp ������Ʈ�� ��ġ�� �Լ��� �޾ƿ� ��ġ��
        Temp.GetComponent<CircleObject>().Used();                 //�����Ǿ����� ���Ǿ��ٰ� ǥ�� �������
    }
}
