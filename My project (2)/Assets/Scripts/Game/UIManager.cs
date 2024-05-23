using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;
    public Text bestscoretext;

    void OnEnable()
    {
        GameManager.OnPointChanged += UpdatePointText;                  //�̺�Ʈ ���
        GameManager.OnBestScoreChanged += UpdateBestScoreText;                  
    }

    private void OnDisable()
    {
        GameManager.OnPointChanged -= UpdatePointText;                  //�̺�Ʈ ����
        GameManager.OnBestScoreChanged -= UpdateBestScoreText;
    }

    void UpdatePointText(int newPoint)                                  //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        pointText.text = "Points : " + newPoint;                        //���� ǥ�� UI �� ����
    }

    void UpdateBestScoreText(int newBestScore)                          //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        pointText.text = "BestScore : " + newBestScore;                 //�ְ� ���� ǥ�� UI�� ����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
