using UnityEngine;
using TMPro;

public class DialogTu : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Transform targetCharacter;
    public Vector3 offset = new Vector3(0, 2f, 0);
    public Camera mainCamera;
    
    private string[] sentences = new string[] 
    {
        "Harmful plastics have entered the ocean, and you must avoid them by jumping over them. Be careful they are pointy.",
        "Plastic waste produced by humans can wrap around marine animals, causing them to be hurt.",
        "Now that you have mastered all the controls, you can jump into the ocean to begin your journey and save the sea!",

        //ends

        
    };
    
    private int currentSentenceIndex = 0;
    
    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
            
        ShowCurrentSentence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSentence();
        }
        

        UpdateDialoguePanelPosition();
    }

    void UpdateDialoguePanelPosition()
    {
        if (targetCharacter != null && dialoguePanel != null)
        {

            Vector3 screenPos = mainCamera.WorldToScreenPoint(targetCharacter.position + offset);
            

            dialoguePanel.transform.position = screenPos;
        }
    }

    void ShowCurrentSentence()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = sentences[currentSentenceIndex];
    }

    void NextSentence()
    {
        currentSentenceIndex = (currentSentenceIndex + 1) % sentences.Length;
        ShowCurrentSentence();
    }
}