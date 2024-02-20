using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    private Vector3 pos;
    public GameObject obstacle;
    public GameObject activeGameObject;
    private TileScript activeGameObjectScript;

    // public GridScript activeTile;
    public TileScript tileScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000, layerMask)){
            pos = hit.point;
        }

        // placing the obstacle on the gird
        if(hit.collider){
            activeGameObject = hit.collider.gameObject;
            activeGameObjectScript = activeGameObject.GetComponent<TileScript>();
            var x = activeGameObject.transform.position.x;
            var z = activeGameObject.transform.position.z;
            if(Input.GetMouseButton(1)){
                if(activeGameObjectScript.unPlaceable == false){
                    Instantiate(obstacle, new Vector3(x, 1f, z), Quaternion.identity);
                    activeGameObjectScript.unPlaceable = true;
                }
                else{
                    Debug.Log("Cannot Place Obstacle there");
                }
            }
        }
    }
}
