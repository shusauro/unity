using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public static float bottomY = -30f;
    public AudioSource audioSource;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        ParticleSystem ps = GetComponent<ParticleSystem>(); 
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();    
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            DragonPicker apScript = Camera.main.GetComponent<DragonPicker>();
            apScript.DragonEggDestroyed();
        }
    }
}
