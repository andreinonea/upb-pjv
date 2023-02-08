using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField]
    private new Camera camera;

    // Update is called once per frame
    void Update()
    {
        Ray mouseDirection = camera.ScreenPointToRay(Input.mousePosition); //creaza o raza printr-un punct de pe ecran
        transform.LookAt(mouseDirection.GetPoint(100));
    }
}
