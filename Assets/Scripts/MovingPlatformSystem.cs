using UnityEngine;
namespace AlexzanderCowell
{
    public class MovingPlatformSystem : MonoBehaviour
    {
        [TagSelector]
        [SerializeField] private string thisTag;

        private GameObject _playerGameObject;
        private Animator _thisAnimator;


        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
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

        private void Update()
        {
            

            if (LavaAreaActiviation._allowPlatformsToMove)
            {
                if(_thisAnimator.GetBool("TurnOnPlatforms") != true)
                {
                    _thisAnimator.SetBool("TurnOnPlatforms", true);
                    LavaAreaActiviation._allowPlatformsToMove = false;
                }
            }
            
            if (!LavaAreaActiviation._allowPlatformsToMove && !LavaRoomActivation._playerIsInLavaPit)
            {
                _thisAnimator.SetBool("TurnOnPlatforms", false);
            }
        }
    }
}

