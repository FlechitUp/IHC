using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClickPoint : MonoBehaviour
{
    public GameObject moleContainer;
    private Mole[] moles;
    //NavMeshAgent agent;
    int i = 0;
    void Start()
    {
        moles = moleContainer.GetComponentsInChildren<Mole>();
        // agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {       

        if (i > 7) i = 0;

       /* if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 clickPos = Input.mousePosition;
            Debug.Log("clic " + clickPos);

            if (Physics.Raycast(Camera.main.ScreenPointToRay(clickPos), out hit,100))
            {

                Vector3 vecTem = hit.point;
                vecTem.x = vecTem.x - 15f;
                vecTem.y = -0.4776725f;
                vecTem.z = vecTem.z - 6f;
                Debug.Log(hit.point);


                moles[i].transform.localPosition = hit.point;//vecTem;//hit.point;
                i++;

            }
        }*/

         if (Input.GetMouseButtonDown(0))
         {
             RaycastHit hit;
            //.Infinity, layerMask))      

           
             if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))//, 1000))
             {               
                 Debug.Log("okiwil");

                 moles[i].moveTo(hit);//vecTem;//hit.point;
                 i++;
             }




         }


    }
}