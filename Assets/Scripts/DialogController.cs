using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{
    public class DialogController : MonoBehaviour
    {
        [SerializeField] private Text playersText;

        [SerializeField] private Text oldManText;

        /*[SerializeField] private Text ninjaText;
        [SerializeField] private Text helpfulHintText;
        [SerializeField] private Text ninjaMasterText;*/
        private GameObject _thisEButton;
        [SerializeField] private GameObject[] smallSpeechBubbles;
        [SerializeField] private GameObject[] smallSpeechBubblesTwo;
        [SerializeField] private GameObject[] largeSpeechBubbles;
        private readonly float _betweenTextCounter = 0.1f;
        private float _resetTextCounter;
        private float _currentTextCounter;
        private int _currentLineIndex;
        private int _currentLetterIndex;
        private bool _nextLetter;
        private int _currentTextSize;
        private int _textMaxSize;
        private int _decreaseTextSizeAmount;
        private bool _decreaseTextSize;
        private int _eButtonPress;
        private bool _didPressE;
        private bool _startStory;
        private bool _bubblesAreUp;
        private bool _bubblesAreGone;
        [Header("Character Dialog")]
        [SerializeField] private string[] dialogTextOldManOne;
        [SerializeField] private string[] dialogTextOldManTwo;
        [SerializeField] private string[] ninjaTextOne;
        [SerializeField] private string[] randomNinjaText;
        [SerializeField] private string[] randomHelpFulHints;
        [SerializeField] private string[] randomNinjaMasterText;
        [SerializeField] private string[] ninjaMasterText;
        public static bool currentlyTalking;


        private void Start()
        {
            _decreaseTextSizeAmount = 1;
            _textMaxSize = 18;
            _nextLetter = true;
            _currentTextSize = _textMaxSize;
            playersText.text = "";
            oldManText.text = "";
        }

        private void Update()
        {
            
            if (!_bubblesAreGone || !_startStory)
            {
                SpeechBubbleControlOneMinus();
            }

            if (Input.GetKeyDown(KeyCode.E) && _eButtonPress < 2)
            {
                _didPressE = true;
            }

            if (_didPressE)
            {
                _eButtonPress += 1;
                _didPressE = false;
            }

            if (OldManScript.characterIsHere && _eButtonPress == 1)
            {
                _thisEButton.GetComponent<CanvasGroup>().alpha = 0;
                _startStory = true;
            }

            if (_startStory)
            {
                SpeechBubbleControlOnePlus();

                if (_bubblesAreUp)
                {
                    FirstOldManInteractionTree();
                    currentlyTalking = true;
                }
            }
            else
            {
                currentlyTalking = false;
            }

            if (OldManScript.characterIsHere && _eButtonPress == 0)
            {
                _thisEButton = GameObject.Find("OldManEBubble");
                EButtonBubbleControl();
            }
        }

        private void FirstOldManInteractionTree()
        {
            if (_nextLetter)
            {
                _currentTextCounter += 0.9f * Time.deltaTime;

                if (_currentTextCounter > _betweenTextCounter)
                {
                    if (_currentLetterIndex < dialogTextOldManOne[_currentLineIndex].Length)
                    {
                        if (_currentLineIndex == 0)
                        {
                            FontChangeSize();
                            PlayersDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex % 2 == 0 && _currentLineIndex < 7)
                        {
                            FontChangeSize();
                            PlayersDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex == 1)
                        {
                            FontChangeSize();
                            OldManDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex % 2 == 1 && _currentLineIndex < 6)
                        {
                            FontChangeSize();
                            OldManDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex > 6 && _currentLineIndex < 20)
                        {
                            FontChangeSize();
                            OldManDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex >= 20 && _currentLineIndex < 23)
                        {
                            FontChangeSize();
                            PlayersDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex % 2 == 1 && _currentLineIndex >= 23)
                        {
                            FontChangeSize();
                            OldManDialogControl();
                            _currentTextCounter = 0;
                        }
                        else if (_currentLineIndex % 2 == 0 && _currentLineIndex > 23)
                        {
                            FontChangeSize();
                            PlayersDialogControl();
                            _currentTextCounter = 0;
                        }

                        if (_currentLineIndex > 32)
                        {
                            _startStory = false;
                        }
                    }
                }

                if (_currentLetterIndex >= dialogTextOldManOne[_currentLineIndex].Length)
                {
                    EButtonBubbleControl();

                    if (Input.GetKeyDown(KeyCode.E) && _eButtonPress >= 2)
                    {
                        _thisEButton.GetComponent<CanvasGroup>().alpha = 0;
                        playersText.text = "";
                        oldManText.text = "";
                        _currentTextCounter = 0;
                        _currentLineIndex += 1;
                        _currentLetterIndex = 0;
                        _currentTextSize = _textMaxSize;
                    }
                }

            }
        }

        private void PlayersDialogControl()
        {
            playersText.fontSize = _currentTextSize;
            playersText.text += dialogTextOldManOne[_currentLineIndex][_currentLetterIndex];
            _currentLetterIndex++;
            _thisEButton = GameObject.Find("MainEButton");
        }

        private void OldManDialogControl()
        {
            oldManText.fontSize = _currentTextSize;
            oldManText.text += dialogTextOldManOne[_currentLineIndex][_currentLetterIndex];
            _currentLetterIndex++;
            _thisEButton = GameObject.Find("OldManEBubble");
        }

        private void FontChangeSize()
        {
            if (_currentLetterIndex % 3 == 0 && _currentTextSize > 11)
            {
                _decreaseTextSize = true;
            }

            if (_decreaseTextSize)
            {
                _currentTextSize -= _decreaseTextSizeAmount;
                _decreaseTextSize = false;
            }
        }

        private void EButtonBubbleControl()
        {
            const float duration = 1;
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            _thisEButton.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(0.5f, 1, lerp);
        }

        private void SpeechBubbleControlOnePlus()
        {
            foreach (var One in smallSpeechBubbles)
            {
                One.GetComponent<CanvasGroup>().alpha += Mathf.Lerp(0, 1, 0.5f) * Time.deltaTime;

                if (One.GetComponent<CanvasGroup>().alpha == 1)
                {
                    foreach (var two in smallSpeechBubblesTwo)
                    {
                        two.GetComponent<CanvasGroup>().alpha += Mathf.Lerp(0, 1, 0.5f) * Time.deltaTime;;

                        if (two.GetComponent<CanvasGroup>().alpha == 1)
                        {
                            foreach (var big in largeSpeechBubbles)
                            {
                                big.GetComponent<CanvasGroup>().alpha += Mathf.Lerp(0, 1, 0.5f) * Time.deltaTime;;

                                if (big.GetComponent<CanvasGroup>().alpha == 1)
                                {
                                    _bubblesAreUp = true;
                                }
                            }

                        }
                    }
                }


            }
        }

        private void SpeechBubbleControlOneMinus()
        {
            foreach (var One in smallSpeechBubbles)
            {
                One.GetComponent<CanvasGroup>().alpha -= Mathf.Lerp(1, 0,  0.1f) * Time.deltaTime;
                
                

                if (One.GetComponent<CanvasGroup>().alpha == 0)
                {
                    foreach (var two in smallSpeechBubblesTwo)
                    {
                        two.GetComponent<CanvasGroup>().alpha -= Mathf.Lerp(1, 0, 0.1f) * Time.deltaTime;

                        if (two.GetComponent<CanvasGroup>().alpha == 0)
                        {
                            two.GetComponent<CanvasGroup>().alpha = 0;
                            
                            foreach (var big in largeSpeechBubbles)
                            {
                                big.GetComponent<CanvasGroup>().alpha -= Mathf.Lerp(1, 0, 0.1f) * Time.deltaTime;

                                if (big.GetComponent<CanvasGroup>().alpha == 0)
                                {
                                    big.GetComponent<CanvasGroup>().alpha = 0;
                                    
                                    _bubblesAreGone = true;
                                }
                            }

                        }
                    }
                }


            }
        }
    }
}
          
      

      
  
 

