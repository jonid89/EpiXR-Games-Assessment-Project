using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public List<Vector3> _boxWaypoints;
    public float _timerCooldown = 5.0f;
    public float _speed = 5.0f;
    public float _boxTimer;
    private bool moveToNextWaypoint;
    public int _waypointNumber;
    private Vector3 direction;
    private Material materialToChange;
    public Color _normalColor = new Color(79, 78, 200, 255); 
    public Color _cooldownColor = new Color(255, 46, 0, 255); 

    void Start()
    {
        _boxTimer = 0;
        moveToNextWaypoint = false;
        _waypointNumber = 0;
        materialToChange = gameObject.GetComponent<Renderer>().material;
    }

    void Update()
    {

        if (_boxTimer > 0)
        {
            _boxTimer -= Time.deltaTime;   
            if (_boxTimer < 0) _boxTimer = 0;
        }

        if(moveToNextWaypoint){
            CheckNextWaypoint();
            StartCoroutine(MoveToNextWaypoint());
            materialToChange.color = _cooldownColor;
            StartCoroutine(ChangeColor());
            _boxTimer = _timerCooldown;
            moveToNextWaypoint = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _boxTimer <= 0){
            moveToNextWaypoint = true;
        }
    }

    private void CheckNextWaypoint(){
        _waypointNumber ++;
        if(_waypointNumber >= _boxWaypoints.Count) _waypointNumber = 0;
    }

    private IEnumerator MoveToNextWaypoint()
    {
        float time = 0;
        Vector3 start = transform.position;
        Vector3 target = _boxWaypoints[_waypointNumber];
        while (time < _speed)
        {
            transform.position = Vector3.Lerp(start, target, time / _speed);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;
    }

    private IEnumerator ChangeColor()
    {
        float time = 0;
        Color startValue = materialToChange.color;
        while (time < _timerCooldown)
        {
            materialToChange.color = Color.Lerp(startValue, _normalColor, time / _timerCooldown);
            time += Time.deltaTime;
            yield return null;
        }
        materialToChange.color = _normalColor;
    }


}

