using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ADReward : MonoBehaviour
{
    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.CloseVideoEvent -= Rewarded;
    // Start is called before the first frame update
    void Rewarded()
    {
        Debug.Log("reward achived");
    }

    // Update is called once per frame
    public void OpenAd()
    {
        YandexGame.RewVideoShow(Random.Range(0, 2));
    }
}
