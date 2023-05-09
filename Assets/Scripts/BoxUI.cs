using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxUI : MonoBehaviour
{
    public TriggerBox _triggerBox;
    public TMP_Text _speedText;
    public TMP_Text _waypointText;
    public TMP_Text _boxTimer;
    private float speed;
    private int waypointNumber;
    private float boxTimer;
    void Start()
    {

    }

    void Update()
    {
        speed = _triggerBox._speed;
        waypointNumber = _triggerBox._waypointNumber;
        boxTimer = _triggerBox._boxTimer;

        _speedText.text = ("BoxSpeed: " + speed.ToString());
        _waypointText.text = ("Waypoint: " + waypointNumber.ToString());
        _boxTimer.text = ("Timer: " + boxTimer.ToString());
    }
}
