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
        // Mouse sol t�klama alg�la
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;

            // Fare pozisyonunu d�nya koordinatlar�na d�n��t�r
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            // Raycast kullanarak t�klanan noktada bir GameObject ara
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // T�klanan GameObject'i al
                GameObject clickedObject = hit.collider.gameObject;

                // T�klanan GameObject ile ilgili i�lemleri yapabilirsiniz
                Debug.Log("T�klanan GameObject: " + clickedObject.name);
                clickedObject.transform.DOScale(0.92f, 0.1f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.Linear).OnComplete(() =>
                {
                    OnGameObjectClicked?.Invoke(clickedObject);
                });
                
            }
        }
    }

    
}
