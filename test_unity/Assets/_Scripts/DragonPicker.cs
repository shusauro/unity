using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
using TMPro;

public class DragonPicker : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += GetLoadSave;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoadSave;
    public TextMeshProUGUI scoreGT;
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShiledRadius = 1.5f;
    public List<GameObject> shieldList;
    void Start()
    {
        if (YandexGame.SDKEnabled == true)
            GetLoadSave();
        shieldList = new List<GameObject> ();
        for (int i = 1; i < numEnergyShield + 1; i++)
        {
            GameObject eShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            eShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            eShieldGo.transform.localScale = new Vector3(i, i, i);
            shieldList.Add(eShieldGo);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragonEggDestroyed()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon Egg");
        foreach  (GameObject tDragonEgg in tDragonEggArray)
            Destroy(tDragonEgg);
        var shieldIndex = shieldList.Count - 1;
        GameObject tShieldGO = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGO);

        if (shieldList.Count == 0)
        {
            GameObject scoreGo = GameObject.Find("Score");
            scoreGT = scoreGo.GetComponent<TextMeshProUGUI>();
            UserSave(int.Parse(scoreGT.text));
            YandexGame.NewLeaderboardScores("TOPPlayerScore", int.Parse(scoreGT.text));
            SceneManager.LoadScene("MainMenuScene");
            GetLoadSave();
        }   
    }

    public void GetLoadSave()
    {
        Debug.Log(YandexGame.savesData.score);
    }

    public void UserSave(int currentScore)
    {
        YandexGame.savesData.score = currentScore;
        if (currentScore > YandexGame.savesData.bestScore)
            YandexGame.savesData.bestScore = currentScore;
        YandexGame.SaveProgress();
    }
}
