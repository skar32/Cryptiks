using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public Animator transition;
    public float transitionTime;

    public void OnBeginDrag(PointerEventData eventData)
    {
        float horizontal = eventData.position.x - eventData.pressPosition.x;

        if (Mathf.Sign(horizontal) == 1 && PuzzleGameHandler.currStageSelected >= 2) {
            Debug.Log("Going to most recent puzzle");
            StartCoroutine(LoadLevel(PuzzleGameHandler.currStageSelected));
        } else if (Mathf.Sign(horizontal) == -1) {
            Debug.Log("Going to selection screen");
            StartCoroutine(LoadLevel(1));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    IEnumerator LoadLevel(int nextLevel)
    {
        yield return new WaitForSeconds(0.3f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(nextLevel);
    }
}
