using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))            //1번 키보드를 눌렀을 때
        {
            SoundManager.instance.PlaySound("BGM");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))           //2번 키보드를 눌렀을 때
        {
            SoundManager.instance.PlaySound("SFX");
        }
    }
}
