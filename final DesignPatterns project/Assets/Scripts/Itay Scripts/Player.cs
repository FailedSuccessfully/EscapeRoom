using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _speed;

    public PlayerCamera myView;

    #region Getter/Setter
    public float Speed {
        get {return _speed;}
    }
    public float Range {
        get {return _speed;}
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponentInChildren<PlayerCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    
    public void InteractWith(InterractableObject target)
    {


        /*
        if(Physics.Raycast(viewCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out RaycastHit hit, interractRange, targetLayer))
        {
        InterractionHandler(hit);
        }
        */
        
    }
}
