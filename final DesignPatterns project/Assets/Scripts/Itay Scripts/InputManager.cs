using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ES.InteractionSys;

public class InputManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0){
            MovePlayer(GameManager.player);
        }
        if (Input.GetKeyDown(KeyCode.F)){
            CheckInteraction();
        }
    }

    void CheckInteraction(){
        Camera playerView = GameManager.player.myView.unityCamera;
        if(Physics.Raycast(playerView.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)),
             out RaycastHit hit, GameManager.player.Range, GameManager.interactionManager.interactionLayer))
             {
                 OnInteraction(hit);
             }
    }

    void OnInteraction(RaycastHit hit) {
        //contact interaction manager
        GameManager.interactionManager.InteractWith(hit.collider.GetComponent<InteractableObject>());
    }

    void MovePlayer(Player p) {

        Vector3 movememnt = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))
             * p.Speed * Time.fixedDeltaTime;
        Rigidbody rb = p.GetComponent<Rigidbody>();
        Vector3 newPos = rb.position + rb.transform.TransformDirection(movememnt);
        rb.MovePosition(newPos);
    }
}
