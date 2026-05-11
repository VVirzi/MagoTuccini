using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text MyscoreText;

    public void Update()
    {
        MyscoreText.text = CollecionableManager.Instance.monolitos.ToString();
    }


    
    
}
