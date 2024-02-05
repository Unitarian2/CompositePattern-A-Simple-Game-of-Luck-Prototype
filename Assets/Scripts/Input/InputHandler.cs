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
        // Mouse sol týklama algýla
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;

            // Fare pozisyonunu dünya koordinatlarýna dönüþtür
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // Raycast kullanarak týklanan noktada bir GameObject ara
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Týklanan GameObject'i al
                GameObject clickedObject = hit.collider.gameObject;

                // Týklanan GameObject ile ilgili iþlemleri yapabilirsiniz
                Debug.Log("Týklanan GameObject: " + clickedObject.name);
                clickedObject.transform.DOScale(0.92f, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear).OnComplete(() =>
                {
                    OnGameObjectClicked?.Invoke(clickedObject);
                });
                
            }
        }
    }

    
}
