using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGenItem : MonoBehaviour
{

    public GemaObject ItemBox;
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
            int RandomNumber X= Random.Range(0, 8);
            int RandomNumber Y= Random.Range(0, 8);
            temp.transform.position += new Vector3(RandomNumber, RandomNumber, 0.0f);

            Destroy(temp, 2.0f);
        }
    }
}
