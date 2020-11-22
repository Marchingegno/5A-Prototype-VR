using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevLoad : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 2f;



    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadScene(levelIndex));
    }
    
    private IEnumerator LoadScene(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait for it to end
        yield return new WaitForSeconds(transitionTime);

        //change scene
        SceneManager.LoadScene(levelIndex);
    }
}
