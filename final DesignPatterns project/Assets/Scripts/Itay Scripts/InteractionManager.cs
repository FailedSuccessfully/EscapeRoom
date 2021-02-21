using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ES.InteractionSys  {
    public class InteractionManager : MonoBehaviour
    {
        public LayerMask interactionLayer;

        // Start is called before the first frame update
        void Awake()
        {
            if (interactionLayer == 0){                
                interactionLayer = LayerMask.NameToLayer("Interactable");
                Debug.Log(LayerMask.LayerToName(interactionLayer));
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void InteractWith(InteractableObject traget){
            // show interaction menu
            GameManager.uIHelper.ShowMenu(traget);
        }

        public void Touch(iTouchable target){

        }

        public void Pick (iPickable target){

        }

        public void LookAt (iLookable target){

        }
    }
}