
using System;
namespace TestAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MsgAttribute : Attribute
    {

        private int messageCod;
        public MsgAttribute(int msg)
        {
            messageCod = msg;
        }
        public int GetMessage()
        {
            return messageCod;
        }
    }
}
