using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class Manager_Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Juego()
    {
        SceneManager.LoadScene(1);
        CollecionableManager.Instance.monolitos = 0;
        CollecionableManager.Instance.collecionables = 0;
    }
    public void JugarOtraVez()
    {
        CollecionableManager.Instance.monolitos = 0;
        CollecionableManager.Instance.collecionables = 0;
        SceneManager.LoadScene(1);
    }
    public void VolverAlMenu()
    {
        CollecionableManager.Instance.monolitos = 0;
        CollecionableManager.Instance.collecionables = 0;
        SceneManager.LoadScene(0);
    }
    public void Salir()
    {
        Application.Quit();
        #if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#endif

    }
}
