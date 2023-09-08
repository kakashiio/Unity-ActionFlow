using System.Threading;
using UnityEngine;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:21
    //******************************************
    public class ForAction : IAction
    {
        private int _Count;
        private IAction _Action;

        private int _CurrentCount;

        public ForAction(int count, IAction action)
        {
            _Count = count;
            _Action = action;
        }

        public bool Execute(IActionContext context)
        {
            while (_CurrentCount < _Count)
            {
                var finish = _Action.Execute(context);
                if (finish)
                {
                    _CurrentCount++;
                    if (_CurrentCount < _Count)
                    {
                        _Action.End(context);
                        _Action.Start(context);
                    }
                }
                else
                {
                    break;
                }
            }
            
            return _CurrentCount >= _Count;
        }

        public void Start(IActionContext context)
        {
            _CurrentCount = 0;
            _Action.Start(context);
        }

        public void End(IActionContext context)
        {
            _Action.End(context);
        }
    }
}