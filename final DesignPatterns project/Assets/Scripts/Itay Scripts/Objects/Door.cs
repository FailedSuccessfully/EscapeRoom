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
            this._state = new LockedDoor(this);
        }
        public void GetLookedAt()
        {
            GameManager.uIHelper.ShowText("It's a door...");
        }

        public void GetTouched()
        {
            this._state.HandleTouch();
        }
        private void Update() {
        }

        internal void OpenSelf(){
            gameObject.SetActive(false);

        }
    }

    public abstract class DoorState{
        protected Door _context;

        public DoorState(Door context){
            this._context = context;
        }

        public void SetContext(Door context){
            this._context = context;
        }

        public abstract void HandleTouch();

    }

    public class LockedDoor : DoorState
    {
        public LockedDoor(Door context) : base(context)
        {
        }

        public override void HandleTouch()
        {
            GameManager.uIHelper.ShowText("Locked...");
        }
    }

    public class UnlockedDoor : DoorState
    {
        public UnlockedDoor(Door context) : base(context)
        {
        }

        public override void HandleTouch()
        {
            _context.OpenSelf();
        }
    }

    public class UnlockedDoorWithUI : UnlockedDoor
    {
        public UnlockedDoorWithUI(Door context) : base(context)
        {
        }

        public override void HandleTouch()
        {
            // open door
            base.HandleTouch();

            // access ui
        }
    }
}