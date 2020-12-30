using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevLoad : MonoBehaviour
{

    public Animator transition;
    [FormerlySerializedAs("transitionTime")] public float transitionDelay = 2f;



    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadScene(levelIndex));
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadScene(SceneManager.GetSceneByName(levelName).buildIndex));
    }
    
    private IEnumerator LoadScene(int levelIndex)
    {
        //play animation
        yield return new WaitForSeconds(transitionDelay);
        transition.SetTrigger("Start");
        //wait for it to end
        
        yield return new WaitForSeconds(2f);
        //change scene
        Application.LoadLevel(levelIndex);
        SceneManager.LoadScene(levelIndex);
    }
    
}
