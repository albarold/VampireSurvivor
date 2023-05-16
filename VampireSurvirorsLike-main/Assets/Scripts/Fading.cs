using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{

    public float Timer=2;
    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer < 0)
        {
            Destroy(gameObject);
        }
        Timer -= Time.deltaTime;
     
        Color colo = gameObject.GetComponent<SpriteRenderer>().color;
        colo.a = Timer / cooldown;
        gameObject.GetComponent<SpriteRenderer>().color = colo;
    }
}
