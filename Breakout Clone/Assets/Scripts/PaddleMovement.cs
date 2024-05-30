using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {

    private Transform paddleParentTransform;
    [SerializeField] private Transform paddleLeftMostPoint;
    [SerializeField] private Transform paddleRightMostPoint;
    private Vector3 oldPlayerPosition;
    private float worldLeftMostPoint = -8.88f; 
    private float worldRightMostPoint = 8.88f;
    private float mouseLeftMostPoint = -8;
    private float mouseRightMostPoint = 8;

    private void Start() {
        paddleParentTransform=GetComponent<Transform>();
    }

    private void Update() {
        HandleMovement();
        //Debug.Log(paddleParentTransform.position);
    }

    void HandleMovement() {
        Vector3 mouseScreenPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPaddlePosition = new Vector3(mouseScreenPosition.x, 0, 0);
        Debug.Log(mouseScreenPosition);
        
        if(paddleLeftMostPoint.position.x<=worldLeftMostPoint || paddleRightMostPoint.position.x>=worldRightMostPoint) {
            //Paddle has reached world Borders
            if (mouseScreenPosition.x<=mouseLeftMostPoint || mouseScreenPosition.x>=mouseRightMostPoint) {
                //mouse is out of the bounds it should be in
                paddleParentTransform.position = oldPlayerPosition;

            }
            else {
                //mouse is now in bounds and the paddle should move normally
                paddleParentTransform.position = newPaddlePosition;
                oldPlayerPosition = newPaddlePosition;
            }
        }
        else {
            //Paddle is inside the world borders
            paddleParentTransform.position = newPaddlePosition;
            oldPlayerPosition = newPaddlePosition;
        }
        
    }


}