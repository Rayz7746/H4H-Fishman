using UnityEngine;
using TMPro;

public class DialogueManager31 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public Transform targetCharacter;
    public Vector3 offset = new Vector3(0, 2f, 0);
    public Camera mainCamera;
    
    private string[] sentences = new string[] 
    {
        "Congratulations, you have finished the level. Now you understand the dangers that oil poses to marine life and the sea." ,
        "Pouring toxins into the oceans can have long-term effects on the ecosystem, and recovery efforts are expensive and tedious.",
        "NOW",
        "You have reached the coral maze found deep in the ocean. Coral is dying right now due to climate change. ",
        "They have a mutualistic relationship. Due to the heat, though, the bacteria is dying and the corals are starting to bleach.", 
       "Navigate through this maze and find the ending. Special Movement: try W and S!!!!",
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