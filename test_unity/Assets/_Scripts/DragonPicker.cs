using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShiledRadius = 1.5f;
    public List<GameObject> shieldList;
    void Start()
    {
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
            SceneManager.LoadScene("MainMenuScene");
        }   
    }
}
