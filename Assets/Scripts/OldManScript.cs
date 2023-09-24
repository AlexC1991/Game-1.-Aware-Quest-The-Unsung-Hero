using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class OldManScript : MonoBehaviour
    {
        public static Animator oldManAnimator;
        [TagSelector]
        [SerializeField] private string thisTag;
        public static bool characterIsHere;


        private void Awake()
        {
            oldManAnimator = GetComponent<Animator>();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(thisTag))
            {
                characterIsHere = true;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(thisTag))
            {
                characterIsHere = false;
            }
        }
    }
}