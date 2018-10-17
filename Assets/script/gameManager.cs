using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class gameManager : MonoBehaviour {

    public static gameManager instance;
    [SerializeField] CapsuleHand capsule;

    private void Awake()
    {
        instance = this;
    }

}
