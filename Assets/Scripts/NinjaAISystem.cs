using System;
using AlexzanderCowell;
using UnityEngine;
using UnityEngine.AI;

public class NinjaAISystem : MonoBehaviour
{
    private NavMeshAgent _thisAgent;
    private Animator _thisAnimator;
    private bool _doesSeePlayer;
    private bool _isPlayerInAttackRange;
    private bool _isPlayerInSightRange;
    private float _randomDistance;
    private Transform ninjaTransform;
    private float ninjaWalkSpeed = 3.0f;
    private float ninjaRunSpeed = 6.0f;
   [SerializeField] private float visionRadius = 20.0f;
   [SerializeField] private float chaseRadius = 10.0f;
   [SerializeField] private float attackRadius = 2.0f;
   private float _moveHorizontal;
   private float _moveVertical;
   private bool _playerHitNinja;
   public static bool _ninjaIsAttackingPlayer;
   public static bool _canAttackPlayer;
   private float attackTimer = 0.8f;
   private float attackResetTimer;
    
   
    private void Start()
    {
        attackResetTimer = attackTimer;
        _thisAgent = GetComponent<NavMeshAgent>();
        _thisAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canAttackPlayer = true;
        }
    }

    private void Update()
    {
        NinjaAnimations();
        NormalIdleMovement();
        ChasePlayer();
        AttackPlayer();
        PlayerInSight();

        Debug.Log("Can Attack Player or Not " + _canAttackPlayer);
    }

    private void NormalIdleMovement()
    {
        // This will have the Ninja's walk around in random directions for a random amount of time but no longer than 1 minute.
        if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) > chaseRadius)
        {
            
        }
        
        // The Ninja's will choose to either walk or stop and stand still.
        if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) > chaseRadius)
        {
            _thisAgent.speed = ninjaWalkSpeed;
            _randomDistance = UnityEngine.Random.Range(0, 10);
            if (_randomDistance < 1)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * 10);
            }
            else if (_randomDistance < 2)
            {
                _thisAgent.SetDestination(transform.position + transform.right * 10);
            }
            else if (_randomDistance < 3)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * -10);
            }
            else if (_randomDistance < 4)
            {
                _thisAgent.SetDestination(transform.position + transform.right * -10);
            }
            else if (_randomDistance < 5)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * 10 + transform.right * 10);
            }
            else if (_randomDistance < 6)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * -10 + transform.right * -10);
            }
            else if (_randomDistance < 7)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * 10 + transform.right * -10);
            }
            else if (_randomDistance < 8)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * -10 + transform.right * 10);
            }
            else if (_randomDistance < 9)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * 5 + transform.right * 5);
            }
            else if (_randomDistance < 10)
            {
                _thisAgent.SetDestination(transform.position + transform.forward * -5 + transform.right * -5);
            }
        }
        else if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) < chaseRadius)
        {
            _thisAgent.speed = 0;
        }
    }

    private void PlayerInSight()
    {
        if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) < visionRadius)
        {
            /*SoundManager.playZombieAlertSound = false;
            SoundManager.playZombieAmbienceSound = true;
            SoundManager.playZombieDeathSound = false; */
                
            transform.LookAt(CharacterMovementScript._controller.transform.position);
        }
    }

    private void ChasePlayer()
    {
        // If the player character is within the Ninja's vision, the zombie will chase the player and look at the player as well.
        if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) < chaseRadius)
        {
            ninjaRunSpeed = Mathf.Lerp(ninjaRunSpeed, ninjaWalkSpeed, Time.deltaTime);
            _thisAgent.speed = ninjaRunSpeed;
            _thisAgent.SetDestination(CharacterMovementScript._controller.transform.position);
            transform.LookAt(CharacterMovementScript._controller.transform.position);
        }
    }

    private void AttackPlayer()
    {
        // If the Ninja is with in the attack radius of the player, the Ninja will stop moving and attack the player.
        if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) < attackRadius)
        {
            /*SoundManager.playZombieAlertSound = true;
            SoundManager.playZombieAmbienceSound = false;
            SoundManager.playZombieDeathSound = false;*/
            _thisAgent.speed = 0;
            transform.LookAt(CharacterMovementScript._controller.transform.position);
        }
        else if (Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) > attackRadius && Vector3.Distance(transform.position, CharacterMovementScript._controller.transform.position) < chaseRadius)
        {
            /*SoundManager.playZombieAlertSound = false;
            SoundManager.playZombieAmbienceSound = true;
            SoundManager.playZombieDeathSound = false; */
        }

        if (_canAttackPlayer)
        {
            attackTimer -= 0.2f * Time.deltaTime;
              if (attackTimer <= 0 && _canAttackPlayer)
            {
                _ninjaIsAttackingPlayer = true;
                attackTimer = attackResetTimer;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (!_thisAgent == enabled)
        {
            // creates a on draw gizmo to show the path the zombie is taking and the radius of the zombie's vision.
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, visionRadius);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
        
    }

    private void NinjaAnimations()
    {
        _moveHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal movement of the character.
        _moveVertical = Input.GetAxis("Vertical"); // Gets the vertical movement of the character.
        
        if (_moveHorizontal > 0 || _moveVertical > 0 || _moveHorizontal < 0)
        {
            _thisAnimator.SetFloat("Blend", 0.5f, 0.2f, Time.deltaTime);
        }
        else if (_thisAgent.speed == ninjaRunSpeed)
        {
            _thisAnimator.SetFloat("Blend", 1f, 0.2f, Time.deltaTime);
        }
        else
        {
            _thisAnimator.SetFloat("Blend", 0, 0.2f, Time.deltaTime);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canAttackPlayer = false;
        }
    }
}
