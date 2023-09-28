using System;
using UnityEngine;

namespace AlexzanderCowell
{

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
                if (_thisAnimator.GetBool("StonesAreUp") != true)
                {
                    _thisAnimator.SetBool("StonesAreUp", true);
                }
            }
        }

    }
}
