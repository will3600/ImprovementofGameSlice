using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IKHandling : MonoBehaviour {

    Animator anim;

    public float ikWeight = 1;

    public Transform leftIKTarget;
    public Transform rightIKTarget;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeight);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeight);

        anim.SetIKPosition(AvatarIKGoal.LeftHand, leftIKTarget.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, rightIKTarget.position);
    }

}
