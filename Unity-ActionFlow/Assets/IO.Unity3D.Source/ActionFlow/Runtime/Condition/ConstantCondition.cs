namespace IO.Unity3D.Source.ActionFlow
{
    //******************************************
    //  
    //
    // @Author: Kakashi
    // @Email: john.cha@qq.com
    // @Date: 2023-09-07 19:14
    //******************************************
    public class ConstantCondition : ICondition
    {
        private bool _Value;

        public ConstantCondition(bool value)
        {
            _Value = value;
        }

        public bool Evaluate(IActionContext context)
        {
            return _Value;
        }
    }
}