using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ES.InteractionSys
{
public class Switch : InteractableObject, iLookable, iTouchable
{
        [SerializeField] Door iOpen;
        public void GetLookedAt()
        {
            GameManager.uIHelper.ShowText("It's a switch...");
        }

        public void GetTouched()
        {
            iOpen.StateTransition(new UnlockedDoor(iOpen));
        }
}
}