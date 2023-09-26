using System;
using UnityEngine;

public class LavaRocks : MonoBehaviour
{
    private Animator _thisAnimator;


    private void Start()
    {
        _thisAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (LavaLevelScript._openRocks)
        {
            _thisAnimator.SetBool("StonesAreUp", true);
            LeverActivation();
        }
        else
        {
            /*_thisAnimator.SetBool("StonesAreUp", false);*/
        }
    }

    private void LeverActivation()
    {
        /*LavaLevelScript._openRocks = false;*/
    }
}
