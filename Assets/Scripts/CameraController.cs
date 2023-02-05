    using UnityEngine;
    using System.Collections;
     
    public class CameraController : MonoBehaviour {
     
        public float verticalScrollArea = 10f;
        public float horizontalScrollArea = 10f;
        public float verticalScrollSpeed = 1f;
        public float horizontalScrollSpeed = 1f;
       
        public void EnableControls() {
     
            if(PauseMenu.paused) {
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
        //private float _zMove;
       
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
               
                 if (_mousePos.y < verticalScrollArea) {
                     _yMove = -1;
                 }
                 else if (_mousePos.y >= Screen.height - verticalScrollArea) {
                     _yMove = 1;
                 }
                 else {
                     _yMove = 0;
                 }
               
                //Move camera if wasd or arrow keys are pressed
                float xAxisValue = Input.GetAxis("Horizontal");
                float yAxisValue = Input.GetAxis("Vertical");

                if (xAxisValue != 0) {
                    if (CombinedMovement) {
                        _xMove += xAxisValue;
                    }
                    else {
                        _xMove = xAxisValue;
                    }
                }
               
                if (yAxisValue != 0) {
                    if (CombinedMovement) {
                        _yMove += yAxisValue;
                    }
                    else {
                        _yMove = yAxisValue;
                    }
                }
     
            }
            else {
                _xMove = 0;
                _yMove = 0;
                //_zMove = 0;
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
            //Debug.Log(x);
            // if(y > 1 || y < -1){
            //     y = 0;
            //     //Debug.Log("Correction applied to y: "+y);
            // }
            // if(x > 1 || x < -1){
            //     x = 0;
            //     //Debug.Log("Correction applied to x: "+x);
            // }

            float xSpeed = x * horizontalScrollSpeed;
            float ySpeed = y * verticalScrollSpeed;

            _moveVector = (new Vector2(xSpeed,
            ySpeed) * Time.deltaTime);
            transform.Translate(_moveVector, Space.World);
        }
    }
