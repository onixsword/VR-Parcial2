using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "missileData", menuName = "Scriptables/missileData", order = 1)]

public class missileScript : ScriptableObject {

    [SerializeField] private float speed;
    [SerializeField] private float timeToDie;
    [SerializeField] private TrailRenderer particles;
    [SerializeField] private bool doesExplode;
    [SerializeField] private ExplotionScript explotion;

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float TimeToDie
    {
        get
        {
            return timeToDie;
        }
    }

    public TrailRenderer Particles
    {
        get
        {
            return particles;
        }
    }

    public bool DoesExplode
    {
        get
        {
            return doesExplode;
        }
    }

    public ExplotionScript Explotion
    {
        get
        {
            return explotion;
        }
    }
}
