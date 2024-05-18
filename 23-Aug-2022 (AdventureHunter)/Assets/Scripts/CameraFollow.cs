using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
    //minX,maxX,
   [SerializeField] private float minX,maxX;
   private Transform player;
   private Vector3 tempPos;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!player){
            return;
        }
        tempPos = transform.position;
        tempPos.x = player.position.x;
        if(tempPos.x>maxX){
            tempPos.x = minX;
        }if(tempPos.x>maxX){
            tempPos.x = maxX;
        }
        transform.position = tempPos;

    }
}
