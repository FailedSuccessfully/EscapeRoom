using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ES.InteractionSys
{
public class Key : Switch, iPickable, iLookable
{
        public void GetPicked()
        {
            throw new System.NotImplementedException();
        }

        void iLookable.GetLookedAt()
        {
            throw new System.NotImplementedException();
        }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}