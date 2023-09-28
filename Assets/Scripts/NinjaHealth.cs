using UnityEngine;

namespace AlexzanderCowell
{
    
    public class NinjaHealth : MonoBehaviour
    {
        private int _health = 20;
        private int _attackDamage = 5;
        private bool _isDead;

        private void Start()
        {
            CharacterMovementScript._playerIsAttacking = false;
            _health = Mathf.Clamp(_health, 0, 20);
        }

        private void Update()
        {
            Debug.Log("Player is Attacking Or Not " + CharacterMovementScript._playerIsAttacking);
            
            if (CharacterMovementScript._playerIsAttacking && _isDead != true)
            {
                _health -= _attackDamage;
                CharacterMovementScript._playerIsAttacking = false;
            }

            if (_health <= 0)
            {
                _isDead = true;
            }

            if (_isDead)
            {
                Destroy(gameObject);
            }
        }
    }
}
