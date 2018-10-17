using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class HandController : MonoBehaviour {

    Rigidbody rb;
    Hand hand;

    [Header("Missile Detector")]
    [SerializeField, Range(0f, 300f)] private float forceLimit;
    [SerializeField] CapsuleHand capsule;

    /*[Header("Iteration")]
    [SerializeField] Transform loopMissileParent;
    [SerializeField] int numberOfInstances;
    private List<GameObject> missiles;*/

    [Header("Missile Spawn")]
    [SerializeField] GameObject missileTemplate;
    [SerializeField] private List<GameObject> missileData;
    private int actualData = 0;

    private void Awake()
    {
        //missiles = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
        hand = capsule.GetLeapHand();
    }

    /*private void Start()
    {
        for (int i = 0; i < numberOfInstances; i++)
        {
            GameObject missileTemp = (GameObject) Instantiate(missileTemplate, loopMissileParent);
            missiles.Add(missileTemp);
            missileTemp.SetActive(false);
        }
    }*/

    private void Update()
    {
        if (capsule)
        {
            if (hand == null)
            {
                hand = capsule.GetLeapHand();
            }
            else
            {
                if (hand.PalmVelocity.ToVector3().z >= forceLimit)
                {
                    /*foreach(GameObject shoot in missiles)
                    {
                        if(!shoot.activeInHierarchy)
                        {
                            shoot.SetActive(true);
                            shoot.GetComponent<missile>().instantiate(missileData[actualData], hand.PalmPosition.ToVector3(),
                                hand.Rotation.ToQuaternion());
                            break;
                        }
                    }*/
                    GameObject.Instantiate(missileData[actualData], hand.PalmPosition.ToVector3(),
                                hand.Rotation.ToQuaternion());
                }

                transform.position = hand.PalmPosition.ToVector3();
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        actualData = int.Parse(other.transform.tag);
        Debug.Log(other.name);
    }
}
