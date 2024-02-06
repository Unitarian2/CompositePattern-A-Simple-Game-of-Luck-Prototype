using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputHandler : Singleton<InputHandler>
{
    public static event Action<GameObject> OnGameObjectClicked;
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 mousePosition = Input.mousePosition;

            
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                
                GameObject clickedObject = hit.collider.gameObject;

                
                //Debug.Log("Týklanan GameObject: " + clickedObject.name);
                clickedObject.transform.DOScale(0.92f, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear).OnComplete(() =>
                {
                    OnGameObjectClicked?.Invoke(clickedObject);
                });
                
            }
        }
    }

    
}
