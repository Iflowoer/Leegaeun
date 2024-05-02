using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenColor : MonoBehaviour
{
    private Renderer rendererr;                      //�������� ���� 
    // Start is called before the first frame update
    void Start()
    {
        rendererr = GetComponent<Renderer>();        //������Ʈ�� �����´�.
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))         //�����̽��� ������ �� 
        {
            Color color = new Color(Random.value, Random.value, Random.value);      //���� ���� �����´�.

            rendererr.material.DOColor(color, 1f)                    //���������� 1�� �Ŀ� ����.
                .SetEase(Ease.InOutQuad);

            rendererr.material.DOPlay();                             //���� Ʈ���� �Ѳ����� ���� ��Ų��.
        }
    }
}
