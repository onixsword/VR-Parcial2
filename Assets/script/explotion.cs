using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class explotion : MonoBehaviour {
    
    [SerializeField] private ExplotionScript data;
    private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(Destroy());
    }

    /*public ExplotionScript Data
    {
        set
        {
            data = value;
            //ps = data.Particles;
            StartCoroutine(Destroy());
        }
    }*/

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(data.TimeTillFade);
        GameObject.Destroy(this.gameObject);
    }
}
