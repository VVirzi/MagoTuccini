using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        FinNivel.Instance.NextLevel.AddListener(NextLevel);
        HealthManager.Instance.OnDeath.AddListener(GameOver); //Lo meto al evento OnDeath del HealthManager y espera invocacion para llamar a la funcion Game Over
        FinNivel.Instance.Win.AddListener(GameWin); //Lo meto al evento DeathBoss del HealthBoss y espera invocacion para llamar a la funcion Game Win
        
    }

    private void GameOver() //Cambiar escena a Game Over
    {
        SceneManager.LoadScene(2);
        Debug.Log("Perdiste");
        CollecionableManager.Instance.monolitos = 0;
        CollecionableManager.Instance.collecionables = 0;
    }

    private void NextLevel()
    {
        if (CollecionableManager.Instance.collecionables == 1)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void GameWin() //Cambiar de escena a Win
    {
        if(CollecionableManager.Instance.collecionables == 2)
        {
            SceneManager.LoadScene(3);
            Debug.Log("Win");
        }

    }
   
}


