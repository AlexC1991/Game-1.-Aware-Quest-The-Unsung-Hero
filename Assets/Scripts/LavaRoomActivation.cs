using UnityEngine;

namespace AlexzanderCowell
{
    public class LavaRoomActivation : MonoBehaviour
    {
        public static bool _playerIsInLavaPit;
        [TagSelector]
        [SerializeField] private string thisTag;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == thisTag)
            {
                _playerIsInLavaPit = true;
            }
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == thisTag)
            {
                _playerIsInLavaPit = true;
            }

        }
    }
}
