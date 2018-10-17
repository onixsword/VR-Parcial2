using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "explotionData", menuName = "Scriptables/explotionData", order = 1)]

public class ExplotionScript : ScriptableObject {

    [SerializeField] private float timeTillFade;
    [SerializeField] private ParticleSystem particles;

    public ParticleSystem Particles
    {
        get
        {
            return particles;
        }
    }

    public float TimeTillFade
    {
        get
        {
            return timeTillFade;
        }
    }
}
