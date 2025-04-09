using System;

namespace AI.DecisionTree
{
    public abstract class Node
    {
        public abstract void Execute();
    }

    #region Binary Decision Node
    public class BinaryDecisionNode : Node
    {
        private Node _actionYes;
        private Node _actionNo;

        private Func<bool> _decisionDelegate;

        public BinaryDecisionNode(Node actionYes, Node actionNo, Func<bool> decisionDelegate)
        {
            _actionYes = actionYes;
            _actionNo = actionNo;
            _decisionDelegate = decisionDelegate;
        }

        public override void Execute()
        {
            if (_decisionDelegate.Invoke())
            {
                _actionYes.Execute();
            }
            else
            {
                _actionNo.Execute();
            }
        }
    }
    #endregion

    #region Multiple Decision Node
    public class MultipleDecisionNode : Node
    {
        private Node[] _options;

        //Usamos un int que funcionara como index de todas las opciones y tomara un camino de nodos

        private Func<int> _decisionDelegate;

        public MultipleDecisionNode(Node[] options, Func<int> decisionDelegate)
        {
            _options = options;
            _decisionDelegate = decisionDelegate;
        }

        public override void Execute()
        {
            var optionIndex = _decisionDelegate?.Invoke() ?? default(int);
            _options[optionIndex].Execute();
        }
    }
    #endregion

    #region Action Node
    public class ActionNode : Node
    {
        private Action _action;

        public ActionNode(Action action)
        {
            _action = action;
        }

        public override void Execute()
        {
            _action?.Invoke();
        }
    }
    #endregion
}   

/*#region Ternary Decision Node
    public class TernaryDecisionNode : Node
    {
        private Node _firstOption;
        private Node _secondOption;
        private Node _thirdOption;

        private Func<int> _decisionDelegate;

        public TernaryDecisionNode(Node firstOption, Node secondOption, Node thirdOption, Func<int> decisionDelegate)
        {
            _firstOption = firstOption;
            _secondOption = secondOption;
            _thirdOption = thirdOption;
            _decisionDelegate = decisionDelegate;
        }

        public override void Execute()
        {
            switch (_decisionDelegate?.Invoke())
            {
                case 0:
                    _firstOption.Execute();
                    break;
                case 1:
                    _secondOption.Execute();
                    break;
                case 2:
                    _thirdOption.Execute();
                    break;
            }
        }
    }
    #endregion*/
