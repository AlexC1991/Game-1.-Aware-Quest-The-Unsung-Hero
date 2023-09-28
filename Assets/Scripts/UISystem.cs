using UnityEngine;

namespace AlexzanderCowell
{
    
    public class UISystem : MonoBehaviour
    {
        private bool _openMenu;
        private int _escCounter;
        private bool _escCountBool;
        [SerializeField] private GameObject inGameMenu;
        [SerializeField] private GameObject inGameMenuControlsScreen;
        private void Start()
        {
            inGameMenu.SetActive(false);
            inGameMenuControlsScreen.SetActive(false);
        }

        private void Update()
        {
            InGameMenuOption();
        }

        private void InGameMenuOption()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _escCountBool = true;
            }

            if (_escCountBool)
            {
                _escCounter += 1;
                _escCountBool = false;
            }

            if (_escCounter == 1)
            {
                inGameMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the center of the screen
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            else if (_escCounter == 2 || _escCounter == 0 )
            {
                inGameMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
                Cursor.visible = false;
                Time.timeScale = 1;
            }

            if (_escCounter == 2)
            {
                _escCounter = 0;
            }
        }

        public void MouseSensitivityLow()
        {
            CharacterMovementScript._mouseSensitivityX = 0.6f;
            CharacterMovementScript._mouseSensitivityY = 0.4f;
        }
        
        public void MouseSensitivityMedium()
        {
            CharacterMovementScript._mouseSensitivityX = 1f;
            CharacterMovementScript._mouseSensitivityY = 0.7f;
        }
        
        public void MouseSensitivityHigh()
        {
            CharacterMovementScript._mouseSensitivityX = 1.8f;
            CharacterMovementScript._mouseSensitivityY = 1.2f;
        }

        public void ReturnToGameButtonOption()
        {
            _escCountBool = true;
        }

        public void ControlsDisplayed()
        {
            _escCounter = 3;

            if (_escCounter == 3)
            {
                inGameMenuControlsScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the center of the screen
                Cursor.visible = true;
                Time.timeScale = 0;
            }
            
        }

        public void GoBackToInGameMenu()
        {
            _escCounter = 1;
            
            inGameMenuControlsScreen.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined; // Lock the cursor to the center of the screen
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
}
