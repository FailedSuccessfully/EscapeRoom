using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ES.InteractionSys{
    public class Door : InteractableObject, iLookable, iTouchable
    {
        private DoorState _state;

        public void StateTransition(DoorState state) {
            this._state = state;
        }

        // Start is called before the first frame update
        void Start()
        {
            this._state = new LockedDoor();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void GetLookedAt()
        {
            //throw new System.NotImplementedException();
        }

        void iTouchable.GetTouched()
        {
            this._state.HandleTouch();
        }
    }

    public abstract class DoorState{
        protected Door _context;

        public void SetContext(Door context){
            this._context = context;
        }

        public abstract void HandleTouch();

    }

    public class LockedDoor : DoorState
    {
        public override void HandleTouch()
        {
            // do nothing / alert UI
        }
    }

    public class UnlockedDoor : DoorState
    {
        public override void HandleTouch()
        {
            // open door
        }
    }

    public class UnlockedDoorWithUI : UnlockedDoor
    {
        public override void HandleTouch()
        {
            // open door
            (this as UnlockedDoor).HandleTouch();

            // access ui
        }
    }
}