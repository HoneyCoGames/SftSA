    using UnityEngine;
    using System.Collections;
     
    public class CameraController : MonoBehaviour {
     
        public float verticalScrollArea = 10f;
        public float horizontalScrollArea = 10f;
        public float verticalScrollSpeed = .1f;
        public float horizontalScrollSpeed = 10f;
       
        public void EnableControls(bool _enable) {
     
            if(_enable) {
                //ZoomEnabled = true;
                MoveEnabled = true;
                CombinedMovement = true;
            } else {
                ZoomEnabled = false;
                MoveEnabled = false;
                CombinedMovement = false;
            }
        }
     
        public bool ZoomEnabled = false;
        public bool MoveEnabled = true;
        public bool CombinedMovement = true;
     
        private Vector2 _mousePos;
        private Vector2 _moveVector;
        private float _xMove;
        private float _yMove;
        private float _zMove;
       
        void Update () {
            _mousePos = Input.mousePosition;
           
            //Move camera if mouse is at the edge of the screen
            if (MoveEnabled) {
               
                //Move camera if mouse is at the edge of the screen
                if (_mousePos.x < horizontalScrollArea)
                {
                    _xMove = -1;
                }
                else if (_mousePos.x >= Screen.width - horizontalScrollArea) {
                    _xMove = 1;
                }
                else {
                    _xMove = 0;
                }
               
                // if (_mousePos.y < verticalScrollArea) {
                //     _zMove = -1;
                // }
                // else if (_mousePos.y >= Screen.height - verticalScrollArea) {
                //     _zMove = 1;
                // }
                // else {
                //     _zMove = 0;
                // }
               
                //Move camera if wasd or arrow keys are pressed
                float xAxisValue = Input.GetAxis("Horizontal");
                float yAxisValue = Input.GetAxis("Vertical");

                if (xAxisValue != 0) {
                    Debug.Log("X axis detected");
                    if (CombinedMovement) {
                        _xMove += xAxisValue;
                    }
                    else {
                        _xMove = xAxisValue;
                    }
                }
               
                if (yAxisValue != 0) {
                    Debug.Log("Y axis detected");
                    if (CombinedMovement) {
                        _yMove += yAxisValue;
                    }
                    else {
                        _yMove = yAxisValue;
                        Debug.Log("ALL GOOD!!!");
                    }
                }
     
            }
            else {
                _xMove = 0;
                _yMove = 0;
                _zMove = 0;
            }
     
            // Zoom Camera in or out
            // if(ZoomEnabled) {
            //     if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            //         _zMove = 1;
            //     }
            //     else if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            //         _zMove = -1;
            //     }
            //     else {
            //         _zMove = 0;
            //     }
            // }
            // else {
            //     _zMove = 0;
            // }
     
            //move the object
           MoveMe(_xMove, _yMove);
        }
       
        private void MoveMe(float x, float y) {

            float xSpeed = x * horizontalScrollSpeed;
            float ySpeed = y * verticalScrollSpeed;

            if(ySpeed > 0.05 || ySpeed < -0.05){
                y = 0;
            }
            if(xSpeed > 0.05 || xSpeed < -0.05){
                x = 0;
            }




            _moveVector = (new Vector2(xSpeed,
            ySpeed) * Time.deltaTime);
            transform.Translate(_moveVector, Space.World);
            Debug.Log(_moveVector);
        }
    }
