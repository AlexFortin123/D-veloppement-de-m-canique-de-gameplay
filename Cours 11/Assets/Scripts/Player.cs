using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera m_Camera;

    private Coroutine m_MoveCoroutine;
    // Update is called once per frame
    void Update()
    {
        //Mathf.Clamp(position a clamp, valeur minimum, valeur maximum)
        if(Input.GetMouseButtonDown(0))
        {
            Ray move = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit clickHit;
           if(Physics.Raycast(move, out clickHit, 1000f, LayerMask.GetMask("Ground")))
            {
                if(m_MoveCoroutine != null)
                {
                    StopCoroutine(m_MoveCoroutine);
                }
                m_MoveCoroutine = StartCoroutine("Move", clickHit.point);
            }
        }
    }

    IEnumerable Move(Vector3 i_EndingPos)
    {
        Vector3 initialPos = transform.position;
        Vector3 endingPos = i_EndingPos;
        float distance = Vector3.Distance(initialPos, endingPos);
        float pecentageProgession = 0f;
        while(pecentageProgession < 1)
        {
            pecentageProgession += 3f * Time.deltaTime / distance;
            transform.position = Vector3.Lerp(initialPos, endingPos, pecentageProgession);
            yield return null;
        }

        yield return null;
    }
}
