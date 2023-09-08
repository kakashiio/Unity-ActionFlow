namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 18:17
    //******************************************
    public class IfAction : IAction
    {
        private ICondition _Condition;
        private IAction _TrueAction;
        private IAction _FalseAction;

        private IAction _Action;

        public IfAction(ICondition condition, IAction trueAction, IAction falseAction)
        {
            _Condition = condition;
            _TrueAction = trueAction ?? EmptyAction.DEFAULT;
            _FalseAction = falseAction ?? EmptyAction.DEFAULT;
        }

        public bool Execute(IActionContext context)
        {
            return _Action.Execute(context);
        }

        public void Start(IActionContext context)
        {
            _Action = _Condition.Evaluate(context) ? _TrueAction : _FalseAction;
            _Action.Start(context);
        }

        public void End(IActionContext context)
        {
            _Action.End(context);
        }
    }
}