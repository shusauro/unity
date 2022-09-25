using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System.Security.Cryptography;

public class CubeSpawn : MonoBehaviour
{
    public GameObject cubeBlack;
    public GameObject cubeWhite;

    private void Start()
    {
       
    }

    public void GenerateObj(string inputField)
    {
        var count = int.Parse(inputField);
        for (int i = 0; i < count; i++)
        {
            GameObject cube;
            if (i % 2 == 0)
                cube = cubeBlack;
            else
                cube = cubeWhite;
            Instantiate(cube, new Vector3(-9+(i%17)*1.1f, 0+(i/17)*1.1f,  + (i/289) * 1.1f), cube.transform.rotation);
        }
    }
}
