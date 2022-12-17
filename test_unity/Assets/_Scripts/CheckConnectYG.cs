using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class CheckConnectYG : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += CheckSDK;
    private void OnDisable() => YandexGame.GetDataEvent -= CheckSDK;
    private TextMeshProUGUI bestScore;
    // Start is called before the first frame update
    void Start()
    {
        CheckSDK();

    }

    // Update is called once per frame
    public void CheckSDK()
    {
        Debug.Log(YandexGame.SDKEnabled);
        if (YandexGame.auth == false)
        {
            Debug.Log("user is not authorized");
            YandexGame.AuthDialog();
        }
        else
        {
            Debug.Log("user authorized");
        }
        YandexGame.RewVideoShow(0);
        GameObject scoreBO = GameObject.Find("BestScore");
        bestScore = scoreBO.GetComponent<TextMeshProUGUI>();
        bestScore.text = "Best score: " + YandexGame.savesData.bestScore.ToString();

        if ((YandexGame.savesData.achivmnent)[0] == null & GameObject.Find("AchvmentsList"))
            Debug.Log("asdfasdfasdf");
        else
        {
            foreach(string achivment in YandexGame.savesData.achivmnent)
                GameObject.Find("AchvmentsList").GetComponent<TextMeshProUGUI>().text += achivment + '\n';

        }



    }
}
