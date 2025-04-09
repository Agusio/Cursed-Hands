namespace AI.DecisionTree
{
    public class DecisionTree
    {
        private Node _initialNode;

        public DecisionTree(Node initialNode)
        {
            _initialNode = initialNode;
        }

        public void Execute()
        {
            _initialNode.Execute();
        }
    }
}
