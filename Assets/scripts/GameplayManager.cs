using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    public GameObject dummy;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray.GetPoint(5);
            if(Physics.Raycast(ray))
            {
                Instantiate(dummy, ray.GetPoint(25), transform.rotation);
            }
        }
    }
}
