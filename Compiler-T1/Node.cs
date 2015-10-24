namespace Compiler_T1
{
    public class Node
    {
        private Node _left;
        private Node _right;
        private string _text;
        private int _order;

        #region INode Members

        public Node Left { get { return _left; } set { _left = (Node)value; } }
        public Node Right { get { return _right; } set { _right = (Node)value; } }
        public string Text { get { return _text; } }
        public int Order { get { return _order; } set { _order = (int)value; } }

        public Node(Node left, Node right, string text)
        {
            _left = left; _right = right; _text = text; 
        }

        #endregion
    }
}
