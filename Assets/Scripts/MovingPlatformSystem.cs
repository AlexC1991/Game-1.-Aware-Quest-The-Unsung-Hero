using System;
using UnityEngine;
namespace AlexzanderCowell
{
    public class MovingPlatformSystem : MonoBehaviour
    {
        [TagSelector]
        [SerializeField] private string thisTag;

        private GameObject _playerGameObject;


        private void Awake()
        {
            _playerGameObject = GameObject.FindGameObjectWithTag(thisTag);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(thisTag))
            {
                _playerGameObject.transform.parent = transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(thisTag))
            {
                _playerGameObject.transform.parent = null;
            }
        }
    }
}

