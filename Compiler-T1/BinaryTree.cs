using System.Collections;

namespace Compiler_T1
{
    //Proof-of-concept class just to demonstrate how to use the BinaryTreeImage class.
    public class BinaryTree
    {
        private Node _root;
        public Node Root { get { return _root; } set { _root = (Node)value; } }

        public ArrayList arrNodeInfo = new ArrayList();

        private int order = 0; // for set Node.Order by preorder(Node s) or draw this node on End level (Endlevel)

        // Leveller
        public void preorder(Node s)
        {
            if (s != null)
            {
                // return node info 
                #region return node info
                // cout << s.text
                s.Order = order;
                order++;
                #endregion
                preorder(s.Left);
                preorder(s.Right);
            }
        }

        // none Leveller
        public void preorder(Node s, string Arrow, int rootLevel)
        {
            if (s != null)
            {
                // return node info 
                #region return node info
                // cout << s.text
                NodeInfo preorderNodeInfo = new NodeInfo();
                preorderNodeInfo.StartLevel = rootLevel;
                preorderNodeInfo.EndLevel = s.Order;
                preorderNodeInfo.Text = s.Text;
                preorderNodeInfo.Arrow = Arrow;
                arrNodeInfo.Add(preorderNodeInfo);
                #endregion
                
                preorder(s.Left, "Left", s.Order);
                preorder(s.Right, "Right", s.Order);
            }
        }

        public void postorder(Node s)
        {
            if (s != null)
            {
                postorder(s.Left);
                postorder(s.Right);
                // return node info 
                #region return node info
                // cout << s.text
                // MessageBox.Show(s.Text);
                #endregion
            }
        }

        public void inorder(Node s)
        {
            if (s != null)
            {
                inorder(s.Left);
                // return node info 
                #region return node info
                // cout << s.text
                // MessageBox.Show(s.Text);
                #endregion
                inorder(s.Right);
                // return node info 
                #region return node info
                // cout << s.text
                // MessageBox.Show(s.Text);
                #endregion
            }
        }
    }
}

