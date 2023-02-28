    using UnityEngine;
    using System.Collections;
     
    public class CameraController : MonoBehaviour {
     
        public float verticalScrollArea = 10f;
        public float horizontalScrollArea = 10f;
        public static float verticalScrollSpeed = .3f;
        public static float horizontalScrollSpeed = .3f;
       
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
       
        private void MoveMe(float xx, float yy) {
            //Debug.Log(x);
            // if(y > 1 || y < -1){
            //     y = 0;
            //     //Debug.Log("Correction applied to y: "+y);
            // }
            // if(x > 1 || x < -1){
            //     x = 0;
            //     //Debug.Log("Correction applied to x: "+x);
            // }
            if(transform.position.x > 1.4)
            {
                float xSpeed = -.05f;
                float ySpeed = yy * verticalScrollSpeed;
                _moveVector = (new Vector2(xSpeed,
                ySpeed) * Time.deltaTime);
                transform.Translate(_moveVector, Space.World);
            }
            else if(transform.position.x < -1.5)
            {
                float xSpeed = .05f;
                float ySpeed = yy * verticalScrollSpeed;
                _moveVector = (new Vector2(xSpeed,
                ySpeed) * Time.deltaTime);
                transform.Translate(_moveVector, Space.World);
            }
            else if(transform.position.y > 0.9)
            {
                float xSpeed = xx * horizontalScrollSpeed;
                float ySpeed = -0.5f;

                _moveVector = (new Vector2(xSpeed,
                ySpeed) * Time.deltaTime);
                transform.Translate(_moveVector, Space.World);
            }
            else if(transform.position.y < -0.79)
            {
                float xSpeed = xx * horizontalScrollSpeed;
                float ySpeed = 0.5f;

                _moveVector = (new Vector2(xSpeed,
                ySpeed) * Time.deltaTime);
                transform.Translate(_moveVector, Space.World);
            }
            else 
            {
                float xSpeed = xx * horizontalScrollSpeed;
                float ySpeed = yy * verticalScrollSpeed;

                _moveVector = (new Vector2(xSpeed,
                ySpeed) * Time.deltaTime);
                transform.Translate(_moveVector, Space.World);
            }


        }
    }
