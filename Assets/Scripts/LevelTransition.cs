using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour 
{
   private void Update()
   {
       if (transform.position.y >= 9f)
       {
           SceneManager.LoadScene("Level3");
       }
   }
}