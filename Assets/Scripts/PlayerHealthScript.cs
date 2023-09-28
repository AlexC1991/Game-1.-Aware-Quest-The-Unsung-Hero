using System;
using UnityEngine;

namespace AlexzanderCowell
{
    public class PlayerHealthScript : MonoBehaviour
    {
        [SerializeField] private GameObject[] healthBars;
        private int _playerHealthNumber = 100;
        private int attackDamage;

        private void Start()
        {
            NinjaAISystem._ninjaIsAttackingPlayer = false;
            
            foreach (GameObject hBar in healthBars)
            {
                hBar.SetActive(true);
            }
        }

        private void Update()
        {
            Debug.Log("Ninja Is Attacking or Not " + NinjaAISystem._ninjaIsAttackingPlayer);
            
            _playerHealthNumber = Mathf.Clamp(_playerHealthNumber, 0, 100);
            if (NinjaAISystem._ninjaIsAttackingPlayer && NinjaAISystem._canAttackPlayer)
            {
                _playerHealthNumber -= 10;
                NinjaAISystem._ninjaIsAttackingPlayer = false;
            }
            
            HealthBarFunction();
        }

        private void HealthBarFunction()
        {
            if (_playerHealthNumber == 100)
            {
                healthBars[10].SetActive(true);
            }
            else
            {
                healthBars[10].SetActive(false);
            }
            if (_playerHealthNumber <= 90)
            {
                healthBars[9].SetActive(false);
            }
            else
            {
                healthBars[9].SetActive(true);
            }

            if (_playerHealthNumber <= 80)
            {
                healthBars[8].SetActive(false);
            }
            else
            {
                healthBars[8].SetActive(true);
            }
            if (_playerHealthNumber <= 70)
            {
                healthBars[7].SetActive(false);
            }
            else
            {
                healthBars[7].SetActive(true);
            }
            if (_playerHealthNumber <= 60)
            {
                healthBars[6].SetActive(false);
            }
            else
            {
                healthBars[6].SetActive(true);
            }
            if (_playerHealthNumber <= 50)
            {
                healthBars[5].SetActive(false);
            }
            else
            {
                healthBars[5].SetActive(true);
            }
            if (_playerHealthNumber <= 40)
            {
                healthBars[4].SetActive(false);
            }
            else
            {
                healthBars[4].SetActive(true);
            }
            if (_playerHealthNumber <= 30)
            {
                healthBars[3].SetActive(false);
            }
            else
            {
                healthBars[3].SetActive(true);
            }
            if (_playerHealthNumber <= 20)
            {
                healthBars[2].SetActive(false);
            }
            else
            {
                healthBars[2].SetActive(true);
            }
            if (_playerHealthNumber <= 10)
            {
                healthBars[1].SetActive(false);
            }
            else
            {
                healthBars[1].SetActive(true);
            }
            if (_playerHealthNumber <= 0)
            {
                healthBars[0].SetActive(false);
            }
            else
            {
                healthBars[0].SetActive(true);
            }
        }
    }
}