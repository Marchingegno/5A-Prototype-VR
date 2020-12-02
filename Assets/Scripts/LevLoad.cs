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
        transition.SetTrigger("Start");
        //wait for it to end
        yield return new WaitForSeconds(transitionDelay);

        //change scene
        SceneManager.LoadScene(levelIndex);
    }
}
