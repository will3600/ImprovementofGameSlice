using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKControl : MonoBehaviour {

    protected Animator animator;

    public bool ikActive = false;
    public Transform rightHandobj = null;
    public Transform leftHandobj = null;

    public bool leftHandIK;
    public bool rightHandIK;

    public Vector3 leftHandPos;
    public Vector3 rightHandPos;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}

    void OnAnimatorIK()
    {
        if (animator)
        {
            RaycastHit LHit;
            RaycastHit RHit;

            // Lefthand IK Check
            if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.0f), -transform.up + new Vector3(-1.0f, 0.0f, 0.0f), out LHit, 1.5f))
            {

                leftHandIK = true;
                leftHandPos = LHit.point;

                if (ikActive = true)
                {
                    if (leftHandobj != null)
                    {
                        // Brings the left hand up towards the wall
                        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandobj.position);
                        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandobj.rotation);
                    }
                }

                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
                }
            }
            else
                leftHandIK = false;

            // righthand IK Check
            if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.0f), -transform.up + new Vector3(1.0f, 0.0f, 0.0f), out RHit, 1.5f))
            {

                rightHandIK = true;
                rightHandPos = RHit.point;

                if (ikActive = true)
                {
                    if (rightHandobj != null)
                    {
                        // Brings the right hand up towards the wall
                        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandobj.position);
                        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandobj.rotation);
                    }
                }

                else
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
                    animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
                }
            }
            else
                rightHandIK = false;      
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Visual representations for the rays
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.0f), -transform.up + new Vector3(-1.0f, 0.0f, 0.0f), Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.0f), -transform.up + new Vector3(1.0f, 0.0f, 0.0f), Color.green);
    }
}
