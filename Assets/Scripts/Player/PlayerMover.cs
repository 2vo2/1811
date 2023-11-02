using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotateValue;
    [SerializeField] private Vector2 _clickToStepPosition;

    private bool _lookForward = true;
    private bool _lookLeft = false;
    private bool _lookRight = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePosition = Input.mousePosition;
            var viewportMousePosition = Camera.main.ScreenToViewportPoint(mousePosition);

            if (_lookLeft == true)
                MoveLeft(viewportMousePosition.x, viewportMousePosition.y, _clickToStepPosition.x, _clickToStepPosition.y);
            else if (_lookRight == true)
                MoveRight(viewportMousePosition.x, viewportMousePosition.y, _clickToStepPosition.x, _clickToStepPosition.y);
            else if (_lookForward)
                MoveForward(viewportMousePosition.x, viewportMousePosition.y, _clickToStepPosition.x, _clickToStepPosition.y);
        }
    }
    
    private void MoveForward(float mousePositionX, float mousePositionY, float clickToStepPositionX, float clickToStepPositionY)
    {
        if (mousePositionX >= clickToStepPositionX && 
            mousePositionX <= clickToStepPositionY) // Forward
        {
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookForward = true;
        }
        else if (mousePositionX <= clickToStepPositionX) // Left
        {
            transform.Rotate(0f, -_rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookLeft = true;
            _lookForward = false;
        }
        else if (mousePositionX >= clickToStepPositionY) // Right
        {
            transform.Rotate(0f, _rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookRight = true;
            _lookForward = false;
        }
    }

    private void MoveLeft(float mousePositionX, float mousePositionY, float clickToStepPositionX, float clickToStepPositionY)
    {
        if (mousePositionX >= clickToStepPositionX && 
            mousePositionX <= clickToStepPositionY) // Right
        {
            transform.Rotate(0f, _rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookForward = true;
            _lookLeft = false;
        }
        else if (mousePositionX <= clickToStepPositionX) // Forward
        {
            var moveVector = transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed));
            _rigidbody.MovePosition(moveVector);
        }
        else if (mousePositionX >= clickToStepPositionY) // left
        {
            transform.Rotate(0f, -_rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookLeft = true;
        }
    }

    private void MoveRight(float mousePositionX, float mousePositionY, float clickToStepPositionX, float clickToStepPositionY)
    {
        if (mousePositionX >= clickToStepPositionX && 
            mousePositionX <= clickToStepPositionY) // Left
        {
            transform.Rotate(0f, -_rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookForward = true;
            _lookRight = false;
        }
        else if (mousePositionX <= clickToStepPositionX) // Right
        {
            transform.Rotate(0f, _rotateValue, 0f);
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
            _lookRight = true;
        }
        else if (mousePositionX >= clickToStepPositionY) // Forward
        {
            _rigidbody.MovePosition((transform.position + transform.TransformDirection(new Vector3(0f, 0f, _speed))));
        }
    }
}
