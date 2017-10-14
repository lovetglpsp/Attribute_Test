using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestAttribute;


    public class Message
    {

        [MsgAttribute(100)]
        public void MessageOne()
        {
            Debug.Log("this is one");
        }
        [MsgAttribute(200)]
        public void MessageTwo(int i)
        {
            Debug.Log("this is Two :"+i);
        }
        [MsgAttribute(300)]
        public void MessageThree()
        {
            Debug.Log("this is Three");
        }

    }
