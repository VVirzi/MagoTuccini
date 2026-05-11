using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar : MonoBehaviour
{
    public HealthManager vida;
    public Image img;

    // Update is called once per frame
    void Update()
    {
       // vida.health = Mathf.Clamp(vida.health, 0, vida.initialHealth);
       // img.fillAmount = vida.health / vida.initialHealth;
    }
}
