using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class TypingEffect : MonoBehaviour
{
    private TextMeshProUGUI textDisplay;
    private string fullText = "You have seen how corals are affected by Climate Change. Humans have come up with solutions to this problem, such as coral farming. Coral preservation is important for ocean ecosystems, and they provide homes to fish like me. You have reached the end, and I have evolved to fight people who pollute the ocean and ruin marine life. Those who oppose will fear my wrath. Now, I will break my enemy and your screen";
    public float typingSpeed = 0.05f;
    private bool isTypingComplete = false;

    void Start()
    {
        textDisplay = GetComponent<TextMeshProUGUI>();
        textDisplay.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        
        isTypingComplete = true;
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("thank");
    }
}