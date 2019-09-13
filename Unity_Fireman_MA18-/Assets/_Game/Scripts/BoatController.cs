using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public List<Transform> positions = new List<Transform>();

    private int currentPosition = 1;
    private Vector3 originalScale;
     public float speed = 10;

    // prenumerera på eventen från ButtonInput
    private void OnEnable()
    {
        ButtonInput.OnLeft += OnLeftPressed;
        ButtonInput.OnRight += OnRightPressed;
    }

    //avsluta prenumerationerna från ButtonInput
    private void OnDisable()
    {
        ButtonInput.OnLeft -= OnLeftPressed;
        ButtonInput.OnRight -= OnRightPressed;
    }

    private void Start()
    {
        originalScale = transform.localScale;
        UpdatePosition();

    }


    // kommer köras när OnLeft eventet har triggads pga av prenumerationen i OnEnable
    public void OnLeftPressed()
    {

        if (currentPosition > 0)
        {
            Debug.Log("RIGHT klickad");
            transform.localScale = originalScale;
            currentPosition--;
            UpdatePosition();
        }
    }

    // kommer köras när OnRight eventet har triggads pga av prenumerationen i OnEnable
    public void OnRightPressed()
    {

        if (currentPosition < positions.Count - 1)
        {
            Debug.Log("RIGHT klickad");
            transform.localScale = new Vector3(-1.4096F, 1.6F, 1);
            currentPosition++;
            UpdatePosition();
        }
    }


    private void UpdatePosition()
    {
        transform.position = positions[currentPosition].position;
    }

}
