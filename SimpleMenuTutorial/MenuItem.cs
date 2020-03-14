using System;

namespace SimpleMenuTutorial
{
    public class MenuItem
    {
        public string ItemName { get; set; }
        public Action<object> Function { get; set; }
        public bool IsSelected { get; set; }

        public void Invoke(object parameterObject = null)
        {
            Function.Invoke(parameterObject);
        }
    }
}
