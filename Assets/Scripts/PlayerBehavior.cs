using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private int playerPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementPoints(int pointsValue)
    {
        playerPoints += pointsValue;
    }

    public int PlayerPoints()
    {
        return playerPoints;
    }
}
