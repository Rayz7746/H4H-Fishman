using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Transform targetCharacter;
    public Vector3 offset = new Vector3(0, 2f, 0);
    public Camera mainCamera;
    
    private string[] sentences = new string[] 
    {
        "Hello again. This time, you will have to traverse over oil barrels and not fall into the oil water pits.",
        "Oil spills harm ocean life and contain toxins that harm sea life and coat them in oil resin.",
        "Good luck on your journey!",
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