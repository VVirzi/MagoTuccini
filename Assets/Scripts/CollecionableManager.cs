using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecionableManager : MonoBehaviour
{
    public static CollecionableManager Instance;

    public int collecionables;
    public int monolitos;
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

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        collecionables = 0;
        monolitos = 0;
    }

}
