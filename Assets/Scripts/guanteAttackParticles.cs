using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guanteAttackParticles : MonoBehaviour
{
    public ParticleSystem particulasAtaque;
    
    public void ActivarAtaque()
    {
        particulasAtaque.Play();
    }
}
