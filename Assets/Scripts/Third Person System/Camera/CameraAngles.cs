using System.Collections;
using UnityEngine;


public class CameraAngles : MonoBehaviour
{
    public CameraAngle Angle;
    public static Camera _camera;
    public static CameraMoves _currentMovement;
    public static SmoothCameraMovement _smoothing;

    private static float _moveSpeed;
    private static float _targetSpeed;
    private static float _camMoveStartTime;
    private static float _camMoveEndTime;

    private static bool _isFindingStartSpeed = false;
    private static bool _isFindingSmoothEnd = false;
    public static bool _isMoving = false;

    public void Update()
    {


        if (_isMoving)
            MoveCamera();
        if (_isFindingStartSpeed)
            FindStartingSpeed();
        if (_isFindingSmoothEnd)
            FindSmoothEnding();
    }


    public void MoveCamera()
    {
        switch (_currentMovement)
        {
            case CameraMoves.None:
                break;
            case CameraMoves.ZoomInSlow:
                _camera.transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.ZoomIn:
                _camera.transform.Translate(Vector3.forward * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.ZoomOutSlow:
                _camera.transform.Translate(Vector3.back * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.ZoomOut:
                _camera.transform.Translate(Vector3.back * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.MoveUp:
                _camera.transform.Translate(Vector3.up * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.MoveDown:
                _camera.transform.Translate(Vector3.down * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.MoveLeft:
                _camera.transform.Translate(Vector3.left * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.MoveRight:
                _camera.transform.Translate(Vector3.right * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnLeftSlow:
                _camera.transform.Rotate(Vector3.down * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnLeft:
                _camera.transform.Rotate(Vector3.down * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnRightSlow:
                _camera.transform.Rotate(Vector3.up * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnRight:
                _camera.transform.Rotate(Vector3.up * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnUpSlow:
                _camera.transform.Rotate(Vector3.left * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnUp:
                _camera.transform.Rotate(Vector3.left * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnDownSlow:
                _camera.transform.Rotate(Vector3.right * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnDown:
                _camera.transform.Rotate(Vector3.right * Time.deltaTime * _moveSpeed, Space.Self);
                break;
            case CameraMoves.TurnRoundNPCLeft:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.up, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCLeftSlow:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.up, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCRight:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.down, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundNPCRightSlow:
                _camera.transform.RotateAround(GameManager.NPCs[DialoguePlayback.NPC].position, Vector3.down, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonLeft:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.up, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonLeftSlow:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.up, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonRight:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.down, _moveSpeed * 10 * Time.deltaTime);
                break;
            case CameraMoves.TurnRoundEmmonRightSlow:
                _camera.transform.RotateAround(GameManager.Player.transform.position, Vector3.down, _moveSpeed * 10 * Time.deltaTime);
                break;
            default:
                break;
        }
    }

    public void StartMovingCamera(Camera camera, CameraMoves movement, SmoothCameraMovement smoothing, float moveStart, float moveEnd)
    {
        Debug.LogWarning("Start new angle! Movement start at: " + moveStart);
        _camera = camera;
        _currentMovement = movement;
        _smoothing = smoothing;
        _camMoveStartTime = moveStart;
        _camMoveEndTime = moveEnd;

        _moveSpeed = 0;

        FindTargetSpeed();

        _isFindingStartSpeed = true;

        FindStartingMoment();   //do we start the camera movement immediately or do we wait?     
    }

    public void FindStartingMoment()
    {

        if (_camMoveStartTime > 0)  //we start later
        {
            StartCoroutine(WaitToStartMovementRoutine(_camMoveStartTime));
        }
        else  // start movement immediately
        {
            _isMoving = true;
            FindEndingMoment(); //until when do we move
        }
    }

    public void FindEndingMoment()
    {
        Debug.Log("find ending moment at " + _camMoveEndTime);
        if (_camMoveEndTime > 0)
        {
            StartCoroutine(WaitToStopMovementRoutine(_camMoveEndTime)); //start coroutine
        }
        else        //the camera does not stop moving until the end
        {
            Debug.Log("we move until the end");
        }
    }

    public IEnumerator WaitToStartMovementRoutine(float startingTime)
    {
        Debug.Log("Start coroutine");
        yield return new WaitForSeconds(startingTime);

        _isMoving = true;
        FindEndingMoment();
    }

    public static IEnumerator WaitToStopMovementRoutine(float endingTime)
    {
        yield return new WaitForSeconds(endingTime);

        _isFindingSmoothEnd = true;
        _isFindingStartSpeed = false;
    }

    public static void StopMovingCamera()   //the end of the cycle
    {
        Debug.Log("End of the cycle");
        _isMoving = false;
        _isFindingStartSpeed = false;
        _isFindingSmoothEnd = false;
        _camMoveStartTime = 0;
        _camMoveEndTime = 0;
    }

    public void FindStartingSpeed()
    {
        if (_smoothing == SmoothCameraMovement.SmoothBegin || _smoothing == SmoothCameraMovement.SmoothBeginSmoothEnd)
        {
            _moveSpeed = Mathf.Lerp(_moveSpeed, _targetSpeed, .2f * Time.deltaTime);

            if (_moveSpeed > (_targetSpeed * .9f))
            {
                _isFindingStartSpeed = false;
            }
        }
        else
        {
            _moveSpeed = _targetSpeed;
            _isFindingStartSpeed = false;
        }
    }

    public void FindSmoothEnding()
    {
        if (_smoothing == SmoothCameraMovement.SmoothBeginSmoothEnd || _smoothing == SmoothCameraMovement.SmoothEnd)
            _moveSpeed = Mathf.Lerp(_moveSpeed, 0, .2f * Time.deltaTime);
        else
        _isMoving = false;

        if (_moveSpeed < (_targetSpeed * 0.1f))
        {
            _isMoving = false;
            _isFindingSmoothEnd = false;
            _moveSpeed = 0;
        }
    }

    public void FindTargetSpeed()
    {
        switch (_currentMovement)
        {
            case CameraMoves.None:
                break;
            case CameraMoves.ZoomInSlow:
                _targetSpeed = 0.005f;
                break;
            case CameraMoves.ZoomIn:
                _targetSpeed = 0.016f;
                break;
            case CameraMoves.ZoomOutSlow:
                _targetSpeed = 0.006f;
                break;
            case CameraMoves.ZoomOut:
                _targetSpeed = 0.016f;
                break;
            case CameraMoves.MoveUp:
                _targetSpeed = 0.02f;
                break;
            case CameraMoves.MoveDown:
                _targetSpeed = 0.02f;
                break;
            case CameraMoves.MoveLeft:
                _targetSpeed = 0.02f;
                break;
            case CameraMoves.MoveRight:
                _targetSpeed = 0.02f;
                break;
            case CameraMoves.TurnLeftSlow:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnLeft:
                _targetSpeed = 0.4f;
                break;
            case CameraMoves.TurnRightSlow:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnRight:
                _targetSpeed = 0.4f;
                break;
            case CameraMoves.TurnUpSlow:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnUp:
                _targetSpeed = 0.5f;
                break;
            case CameraMoves.TurnDownSlow:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnDown:
                _targetSpeed = 0.5f;
                break;
            case CameraMoves.TurnRoundNPCLeftSlow:
                _targetSpeed = 0.6f;
                break;
            case CameraMoves.TurnRoundNPCLeft:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnRoundNPCRightSlow:
                _targetSpeed = 0.6f;
                break;
            case CameraMoves.TurnRoundNPCRight:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnRoundEmmonLeftSlow:
                _targetSpeed = 0.6f;
                break;
            case CameraMoves.TurnRoundEmmonLeft:
                _targetSpeed = 0.1f;
                break;
            case CameraMoves.TurnRoundEmmonRightSlow:
                _targetSpeed = 0.6f;
                break;
            case CameraMoves.TurnRoundEmmonRight:
                _targetSpeed = 0.1f;
                break;
            default:
                break;
        }
        //TO DO look for target speed only one time. And not in a function which is called every update
    }
}
