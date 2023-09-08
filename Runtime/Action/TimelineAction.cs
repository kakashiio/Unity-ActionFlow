using System.Collections.Generic;

namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:07
    //******************************************
    public class TimelineAction : IAction
    {
        public class Item
        {
            public readonly float Time;
            public readonly IAction Action;

            public Item(float time, IAction action)
            {
                Time = time;
                Action = action;
            }
        }

        private List<Item> _Items;
        private bool[] _Finished;
        private bool[] _Started;
        private float _StartTime;

        public TimelineAction(List<Item> items)
        {
            _Items = items;
            _Finished = new bool[items.Count];
            _Started = new bool[items.Count];
        }

        public bool Execute(IActionContext context)
        {
            bool finishAll = true;
            for (int i = 0; i < _Items.Count; i++)
            {
                if (_Finished[i])
                {
                    continue;
                }

                var item = _Items[i];
                if (item.Time <= context.GetTime() - _StartTime)
                {
                    if (!_Started[i])
                    {
                        item.Action.Start(context);
                        _Started[i] = true;
                    }

                    var finish = item.Action.Execute(context);
                    if (finish)
                    {
                        item.Action.End(context);
                    }

                    _Finished[i] |= finish;
                    finishAll |= finish;
                }
                else
                {
                    finishAll = false;
                }
            }
            return finishAll;
        }

        public void Start(IActionContext context)
        {
            _StartTime = context.GetTime();
            for (int i = 0; i < _Finished.Length; i++)
            {
                _Finished[i] = _Started[i] = false;
            }
        }

        public void End(IActionContext context)
        {
        }
    }
}