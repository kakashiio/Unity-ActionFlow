namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 22:55
    //******************************************
    public class DelayAction : IAction
    {
        private float _Delay;
        private float _Remains;

        private IAction _Action;
        private bool _Started;

        public DelayAction(float delay, IAction action)
        {
            _Delay = delay;
            _Action = action;
        }

        public bool Execute(IActionContext context)
        {
            bool finishDelay = _Remains <= 0;
            bool finishAction = false;
            if (finishDelay)
            {
                if (!_Started)
                {
                    _Started = true;
                    _Action.Start(context);
                }
                finishAction = _Action.Execute(context);
            }

            _Remains -= context.GetDeltaTime();
            return finishAction;
        }

        public void Start(IActionContext context)
        {
            _Remains = _Delay;
            _Started = false;
        }

        public void End(IActionContext context)
        {
            _Action.End(context);
        }
    }
}