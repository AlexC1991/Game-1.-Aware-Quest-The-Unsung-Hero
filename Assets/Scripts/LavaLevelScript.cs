using Unity.VisualScripting;
using UnityEngine;

public class LavaLevelScript : MonoBehaviour
{
    [TagSelector]
    [SerializeField] private string thisTag;
    private bool _activated;
    private Animator _animator;
    public static bool _openRocks;
    private bool _seePlayer;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(thisTag))
        {
            _seePlayer = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _seePlayer)
        {
            Debug.Log("Detecting Character");
            _activated = true;
            _openRocks = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _activated = false;
        }
        
        Debug.Log(_openRocks);
        
        
        if (_activated)
        {
            _animator.SetBool("ActivateLever", true);
        }
        else
        {
            _animator.SetBool("ActivateLever", false);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(thisTag))
        {
            _seePlayer = false;
        }
    }
}
