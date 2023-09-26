using System;
using Unity.VisualScripting;
using UnityEngine;

public class GateActivation : MonoBehaviour
{
    private Animator _gateAnimator;
    private bool _doesSeePlayer;

    private void Awake()
    {
        _gateAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doesSeePlayer = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _doesSeePlayer)
        {
            _gateAnimator.SetBool("OpenGate", true);
        }
        else
        {
            _gateAnimator.SetBool("OpenGate", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _doesSeePlayer = false;
        }
    }
}
