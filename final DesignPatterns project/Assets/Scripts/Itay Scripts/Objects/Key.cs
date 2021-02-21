using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ES.InteractionSys
{
    public class Key : InteractableObject, iPickable, iLookable
    {
            [SerializeField] Door iOpen;
            public void GetPicked()
            {
                iOpen.StateTransition(new UnlockedDoorWithUI(iOpen));
                // access ui

                gameObject.SetActive(false);
            }

            public void GetLookedAt()
            {
                GameManager.uIHelper.ShowText("It's a key...");
            }

    }
}   