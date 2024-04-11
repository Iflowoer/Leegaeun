using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenTarget : MonoBehaviour
{

    public GameObject ItemBox;
    public float checkTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;
        if (checkTime >= 1.0f)
        {
            checkTime = 0.0f;
            GameObject temp = Instantiate(ItemBox);
            temp.transform.position = new Vector3(-4.0f, -4.0f , 0.0f);
            int RandomNumberX = Random.Range(0, 8);
            int RandomNumberY = Random.Range(0, 8);
            temp.transform.position += new Vector3(RandomNumberX, RandomNumberY, 0.0f);

            Destroy(temp, 2.0f);
        }
    }
}
