using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float sightRange= 10;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject warning= null;
    [SerializeField] private GameObject detect= null;

    [SerializeField] private GameObject defeat= null;
    private Transform enemiTransform;

    void Awake()
    {
        enemiTransform= transform;
    }

    void Update()
    {
       DetecPlayer(IsLookinThePlayer(playerTransform.position));
    }
    private float timeOnSight;
    private void DetecPlayer(bool isLookinThePlayer)
    {
        if (isLookinThePlayer)
        {
            warning.SetActive(true);
            detect.SetActive(false);
            if (timeOnSight<=3)
            {
                timeOnSight+= Time.deltaTime;
            }
            if (!(timeOnSight>=1.5f)) return;
            warning.SetActive(false);
            detect.SetActive(true);
            defeat.SetActive(true);

            //EditorSceneManager.LoadScene("SampleScene");
            Invoke("reload",3f);
        }
        else
        {
            if (timeOnSight>0)
            {
                timeOnSight-= Time.deltaTime;
            }
            if (!(timeOnSight<=0)) return;
            warning.SetActive(false);
            detect.SetActive(false);
        }
    }
    private bool IsLookinThePlayer(Vector3 playerPositin)
    {
        var displacement= playerPositin- enemiTransform.position;
        var distanceToPlayer= displacement.magnitude;
        if (distanceToPlayer<= sightRange)
        {
            var dot= Vector3.Dot(enemiTransform.forward,displacement.normalized);
            if(!(dot >=0.5))return false;

            var layerMask= 1 << 2;
            layerMask= ~layerMask;
            if(Physics.Raycast(enemiTransform.position,displacement.normalized,out var hit,sightRange,layerMask))
            {
                Debug.DrawRay(enemiTransform.position,displacement.normalized*hit.distance,Color.red);
                Debug.Log("Did hit");
               
               
               if(!hit.collider.GetComponent<FPS_Movimiento>()) return false;

                Debug.DrawRay(enemiTransform.position,displacement.normalized*hit.distance,Color.green);
                return true;
            }
            
        }
        return false;
    }

     void reload()
     {
         
            EditorSceneManager.LoadScene("SampleScene");
     }




}
