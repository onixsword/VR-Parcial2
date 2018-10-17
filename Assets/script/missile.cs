using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class missile : MonoBehaviour {

    [SerializeField] private missileScript data;
    [SerializeField] private GameObject ExplotionTemplate;
    private TrailRenderer trail;

    private void Awake()
    {
        if(data.TimeToDie > 0) trail = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
        StartCoroutine(destroySelf());
    }

    /*public missileScript Data
    {
        set
        {
            data = value;

            trail.material = data.Particles.material;
            trail.endColor = data.Particles.endColor;
            trail.startColor = data.Particles.startColor;
            trail.colorGradient = data.Particles.colorGradient;
            trail.widthCurve = data.Particles.widthCurve;
            trail.time = data.Particles.time;


            StartCoroutine(destroySelf());
        }
    }*/

    private void Update()
    {
        transform.Translate(transform.forward * data.Speed * Time.deltaTime);
    }

    public void instantiate(missileScript data, Vector3 position, Quaternion rotation)
    {
        this.data = data;
        StartCoroutine(destroySelf());
        transform.position = position;
        transform.rotation = rotation;
        
    }

    public void instantiate(Vector3 position, Quaternion rotation)
    {
        transform.position = position;
        transform.rotation = rotation;
        StartCoroutine(destroySelf());
    }

    /*Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }*/

    private IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(data.TimeToDie);
        //if(data.DoesExplode)
        //    GameObject.Instantiate(ExplotionTemplate, transform.position, transform.rotation).GetComponent<explotion>().Data = data.Explotion;
        if(data.DoesExplode) GameObject.Instantiate(ExplotionTemplate, transform.position, transform.rotation);
        GameObject.Destroy(gameObject);
    }


}
