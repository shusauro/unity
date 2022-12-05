using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    // Start is called before the first frame update
    void Start()
    {
        CheckSDK();

    }

    // Update is called once per frame
    public void CheckSDK()
    {
        Debug.Log(YandexGame.SDKEnabled);
        if (YandexGame.SDKEnabled)
            if (YandexGame.auth == false)
                YandexGame.AuthDialog();
            else
                Debug.Log("user authorized");
    }
}
