using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridScript : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    private Vector3 pos;
    [SerializeField] private TextMeshProUGUI textUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // tacking mouse position using raycast
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask)){
            pos = hit.point;
        }
        DisplayName();
    }

    void DisplayName(){
        if(hit.collider){
            var posX = hit.collider.gameObject.transform.position.x + 1f;
            var posZ = hit.collider.gameObject.transform.position.z + 1f;
            textUI.text = "Tile[" + posX.ToString("F0") + ", " + posZ.ToString("F0") + "]";
        }
        else{
            textUI.text = "";
        }
    }
}
