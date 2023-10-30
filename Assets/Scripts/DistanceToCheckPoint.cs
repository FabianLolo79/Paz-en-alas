using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DistanceToCheckPoint : MonoBehaviour
{
    //image bar
    public Slider slider;
    public Image fill;


    // Reference to checkpoint position
    [SerializeField]
    private Transform checkpoint;
    [SerializeField]
    private Transform inicialCheckpoint;

    // Reference to UI text that shows the distance value
    [SerializeField]
    public TextMeshProUGUI distanceProgrese;
    //private Text distanceText;

    // Calculated distance value
    private float distance;
    private float totalDistance;
    private float actualDistance;

    private void Awake()
    {
        totalDistance = checkpoint.transform.position.x - inicialCheckpoint.transform.position.x;
        slider.maxValue = totalDistance;
        slider.value = 0;
    }
    // Update is called once per frame
    private void Update()
    {

        // Calculate distance value by X axis
        distance = (checkpoint.transform.position.x - transform.position.x);
        actualDistance = totalDistance - distance;
        slider.value = actualDistance;

        // Display distance value via UI text
        // distance.ToString("F1") shows value with 1 digit after period
        // so 12.234 will be shown as 12.2 for example
        // distance.ToString("F2") will show 12.23 in this case
        distanceProgrese.text = "Distance: " + distance.ToString("F1") + " meters";

        // If Cat reaches checkpoint then distance text shows "Finish!" word
        if (distance <= 0)
        {
            distanceProgrese.text = "Finish!";
        }
    }

    public void SetMaxDistance(int maxDistance)
    {
        slider.maxValue = maxDistance;
        slider.value = maxDistance;
    }
    public void SetDistance(int distance)
    {
        slider.value = distance;
    }
}
