using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Compiler_T1
{
    public partial class DesignForm : Form
    {
        public DesignForm()
        {
            InitializeComponent();
        }

        private int numNode = 0; // number of Node in Tree
        public int NumNode
        {
            get { return numNode; }
            set { numNode = value; numArrow = (numNode - 1) * 4; }
        }

        private int numArrow = 0; // number of Arrow Line in Tree = (numNode - 1) * 4;

        private Point[] Node_in_Level; // for save every node location in a level

        public void ProcessRequest()
        {
            BinaryTree tree = new BinaryTree();
            tree.Root = new Node(null, null, "E()");
            tree.Root = E();
            if (!error)
                DrawTree(tree);
        }

        #region Parser Method

        TokenType Lookahead;
        int counter_lah = 0;
        TokenType[] aryBody;
        bool error = true;

        private void start_Parsr()
        {
            if (MainForm.error)
            {
                MessageBox.Show("Your data have error !", "RunTime Error");
                Dispose();
            }
            error = false;
            counter_lah = 0;
            aryBody = MainForm.Body.ToArray();
            try
            {
                Lookahead = aryBody[counter_lah];
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            counter_lah++;
            ProcessRequest();
        }

        private void Match(string tt)
        {
            if (error) return;
            if (Lookahead.Token == tt)
            {
                try
                {
                    Lookahead = aryBody[counter_lah];
                    counter_lah++;
                }
                catch { return; }
            }
            else Error();
        }

        private Node E()
        {
            if (error) return new Node(null, null, "error");
            NumNode++;
            return new Node(T(), R1(), "E()");
        }

        private Node T()
        {
            if (error) return new Node(null, null, "error");
            NumNode++;
            return new Node(F(), R2(), "T()");
        }

        private Node F()
        {
            if (error) return new Node(null, null, "error");
            NumNode++;
            switch (Lookahead.Type)
            {
                case "Int":
                    {
                        string buffer = Lookahead.Token;
                        Match(Lookahead.Token);
                        // Postfix += buffer + " ";
                        return new Node(null, null, "F(" + buffer + ")");
                    }

                case "Float":
                    {
                        string buffer = Lookahead.Token;
                        Match(Lookahead.Token);
                        // Postfix += buffer + " ";
                        return new Node(null, null, "F(" + buffer + ")");
                    }

                case "Separator":
                    {
                        if (Lookahead.Token == "(")
                        {
                            Match(Lookahead.Token);
                            Node f = new Node(E(), null, "F()");
                            Match(Lookahead.Token);
                            return f;
                        }
                        else
                        { Error(); return new Node(null, null, "error"); }
                    }

                default: Error();
                    return new Node(null, null, "error");
            }
        }

        private Node R1()
        {
            if (error) return new Node(null, null, "error");
            NumNode++;
            if (Lookahead.Token == "+")
            {
                Match("+");
                return new Node(T(), R1(), "+ R1()");
                // Postfix += "+ ";
            }
            else if (Lookahead.Token == "-")
            {
                Match("-");
                return new Node(T(), R1(), "- R1()");
                // Postfix += "- ";
            }
            else return new Node(null, null, "R1(Ɛ)"); //Postfix += " ";
        }

        private Node R2()
        {
            if (error) return new Node(null, null, "error");
            NumNode++;
            if (Lookahead.Token == "*")
            {
                Match("*");
                return new Node(T(), R2(), "× R2()");
                // Postfix += "* ";
            }
            else if (Lookahead.Token == "/")
            {
                Match("/");
                return new Node(T(), R2(), "/ R2()");
                // Postfix += "/ ";
            }
            else return new Node(null, null, "R2(Ɛ)"); //Postfix += " ";
        }

        private void Error()
        {
            error = true;
            MessageBox.Show("cannot to parse this line", "Parser Error"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        #endregion   

        #region Graphic Designer

        private Point nowLocation; // first node location
        private int level = 0;
        public int Level
        {
            get { return level; }
            set { level = value; /*width = Convert.ToInt32((NumNode * (NumNode + 1) / 2) / (level + 1));*/ }
        }
        //                    ___ ___
        //         |---------|___R___|---------|        -Level 0 (Root)
        //         |                           |
        //         |                           |
        //      ___|___                        |
        //     |___C___|                       |        -Level 1 (Child)
        //                                     |
        //     |<----------->|                 |
        //         (width)                  ___|___
        //                                 |___C___|    -Level 2 (Child)
        //
        // distance between child Node & root Node     = (numNode * (numNode + 1) / 2) / (level + 1)
        private int width = 100;
       
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainerTree;
        private Microsoft.VisualBasic.PowerPacks.LineShape[] LineShapeArrow;
        private Microsoft.VisualBasic.PowerPacks.OvalShape[] OvalShapeNode;
        private Label[] LabelIndoor;

        private void DrawTree(BinaryTree BTS)
        {
            shapeContainerTree = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            LineShapeArrow = new Microsoft.VisualBasic.PowerPacks.LineShape[numArrow];
            OvalShapeNode = new Microsoft.VisualBasic.PowerPacks.OvalShape[NumNode];
            LabelIndoor = new Label[NumNode];
            Node_in_Level = new Point[numNode];

            // 
            // shapeContainerTree
            // 
            this.shapeContainerTree.Location = new System.Drawing.Point(0, 0);
            this.shapeContainerTree.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainerTree.Size = new System.Drawing.Size(3000, 5000);
            this.shapeContainerTree.TabIndex = 0;
            this.shapeContainerTree.TabStop = false;
            this.Controls.Add(shapeContainerTree);
            //
            Node_in_Level[0] = new Point(300, 20);
            nowLocation = Node_in_Level[0];
            BTS.preorder(BTS.Root); // First set Order Data 
            BTS.preorder(BTS.Root, "Root", -1);
            preorderDrawTree(BTS.arrNodeInfo);
        }

        private void preorderDrawTree(System.Collections.ArrayList arrayListNodeInfo)
        {
            foreach (NodeInfo NI in arrayListNodeInfo)
            {
                // MessageBox.Show(NI.Text + "  " + NI.Arrow + "   " + NI.StartLevel.ToString() + "   " + NI.EndLevel.ToString());
                //
                if (NI.StartLevel < 0) // First Node (Root)
                {
                    DrawOval(nowLocation, NI.Text);
                }
                else
                {
                    Point EndPoint = getNewPoint(NI.StartLevel, NI.EndLevel, NI.Arrow);
                    DrawNode(EndPoint, Node_in_Level[NI.StartLevel], NI.Text, NI.Arrow);
                }
            }
        }

        /// <summary>
        /// process the root location and create new point for child node 
        /// </summary>
        /// <param name="rootLevel">Start Level (The Level of child's root location) </param>
        /// <param name="selfLevel">child Level</param>
        /// <param name="Arrow">Arrow of child by relation root node</param>
        /// <returns></returns>
        private Point getNewPoint(int rootLevel, int selfLevel, string Arrow)
        {
            #region Algorithm 
            // getNewPoint Algorithm
            /*                                                    ______
                                                                 /      \
                                                                / Start. \
                                                               /__________\
                                                                    ||        
                                                                    ||
                                                                   \||/
                                                     _______________\/_______________
                                                    |                                |
                                                    | x = Node_in_Level[rootLevel].X |                      
                                                    | Level = rootLevel;             |
                                                    |________________________________|
                                                                    ||
                                                                    ||
                                                                   \||/
                                                                    \/                         /\
                                                                   /  \                       /  \ 
                                                                  / if \                     / if \                      ______________
                                                                 /Arrow \      (NO)       \ /Arrow \      (NO)       \  |              |
                                                                /   ==   ------------------\   ==   ------------------\ | return Error |
                                                                \ "Left" ------------------/"Right" ------------------/ |______________|
                                                                 \      /                 / \      /                 / 
                                                                  \    /                     \    /
                                                                   \  /                       \  /
                                                                    ||                         ||
                                                                    || (YES)                   || 
                                                                   \||/                        ||
                                                ____________________\/__________________       || (YES)
                                               |                                        |      ||
                                               | x = Node_in_Level[rootLevel].X - width |      ||
                                               |________________________________________|     \||/
                                                                    ||            /\       ____\/__________________________________
                                                                    ||           /||\     |                                        | 
                                                                   \||/           ||      | x = Node_in_Level[rootLevel].X + width | 
                                                                    \/            ||      | x = checkLineOverride(x, "Right")      |
                                                                   /  \           ||      | Node_in_Level[selfLevel] =             |
          __________________________________                      / if \          ||      |        new Point(x, selfLevel * 100)   |
         |                                  |  /      (NO)       /      \         ||      | return new Point(x, selfLevel * 100)   |
         | x = checkLineOverride(x, "Left") | /------------------ x < 30 \        ||      |________________________________________|
         |__________________________________| \------------------        /        ||                          ||
                          ||                   \                 \ then /         ||                          ||
                          ||                                      \    /          ||                          ||
                         \||/                                      \  /           ||                          ||
                          \/                                        ||            ||                          ||
                         /  \                                       || (YES)      ||                          ||
                        / if \                                      ||            ||                          ||
                       /      \                 (YES)              \||            ||                          ||
                      / x < 30 -------------------------------------\|            ||                          ||
                      \        -------------------------------------/|            ||                          ||
                       \ then /                                    /||            ||                          ||
                        \    /                                      ||            ||                          ||
                         \  /                                      \||/           ||                          ||
                          ||                         _______________\/____________||___                       ||
                          || (NO)                   |                                  |                      ||
                         \||/                       | ShiftAll2Right(Math.Abs(x) + 40) |                      ||
           _______________\/_____________________   |__________________________________|                    __\/__
          |                                      |                                                       \ /      \
          | Node_in_Level[selfLevel] =           ---------------------------------------------------------\  END.  \                    
          |        new Point(x, selfLevel * 100) ---------------------------------------------------------/_________\
          | return new Point(x, selfLevel * 100) |                                                       /
          |______________________________________|    
             
            */
            #endregion

            #region Code
            Level = rootLevel; // set width
            int x = Node_in_Level[rootLevel].X;

            if (Arrow == "Left")
            {
            reLoadData:
                x = Node_in_Level[rootLevel].X - width;
                //
                // check the maybe All shabe exit in form
                //
                if (x < 30)
                {
                    ShiftAll2Right(Math.Abs(x) + 40);
                    goto reLoadData;
                }
                else
                {
                    x = checkLineOverride(x, "Left", rootLevel);
                    if (x < 30)
                    {
                        ShiftAll2Right(Math.Abs(x) + 40);
                        goto reLoadData;
                    }
                    else // END
                    {
                        Node_in_Level[selfLevel] = new Point(x, selfLevel * 100);
                        return new Point(x, selfLevel * 100);
                    }
                }
            }
            else if (Arrow == "Right") // END
            {
                x = Node_in_Level[rootLevel].X + width;
                x = checkLineOverride(x, "Right", rootLevel);
                Node_in_Level[selfLevel] = new Point(x, selfLevel * 100);
                return new Point(x, selfLevel * 100);
            }
            else return new Point(x, selfLevel * 100);
            #endregion
        }
        
        /// <summary>
        /// Draw Node by Oval and Arrow Lines
        /// </summary>
        /// <param name="StartLoc"></param>
        /// <param name="EndLoc"></param>
        /// <param name="NodeIndoorText"></param>
        private void DrawNode(Point EndLoc, Point StartLoc, string NodeIndoorText, string Arrow)
        {
            DrawOval(EndLoc, NodeIndoorText);
            DrawLineArrow(StartLoc, EndLoc);
        }

        int OvalShapeCounter = 0;
        /// <summary>
        /// draw a oval shape by a label indoor
        /// </summary>
        /// <param name="loc">point of Oval and indoor Label location</param>
        /// <param name="inText">Text of indoor Label</param>
        private void DrawOval(Point loc, string inText)
        {
            // 
            // ovalShapeNode
            // 
            if (OvalShapeCounter >= NumNode) return;
            this.OvalShapeNode[OvalShapeCounter] = new Microsoft.VisualBasic.PowerPacks.OvalShape();
            this.OvalShapeNode[OvalShapeCounter].BackColor = System.Drawing.Color.MistyRose;
            this.OvalShapeNode[OvalShapeCounter].BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.OvalShapeNode[OvalShapeCounter].Cursor = System.Windows.Forms.Cursors.Hand;
            this.OvalShapeNode[OvalShapeCounter].Location = loc;
            this.OvalShapeNode[OvalShapeCounter].Size = new System.Drawing.Size(60, 30);
            this.shapeContainerTree.Shapes.Add(OvalShapeNode[OvalShapeCounter]);
            OvalShapeNode[OvalShapeCounter].BringToFront();
            // 
            // indoor label
            // 
            this.LabelIndoor[OvalShapeCounter] = new Label();
            this.LabelIndoor[OvalShapeCounter].AutoSize = true;
            this.LabelIndoor[OvalShapeCounter].BackColor = System.Drawing.Color.MistyRose;
            this.LabelIndoor[OvalShapeCounter].Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LabelIndoor[OvalShapeCounter].Location = new System.Drawing.Point(loc.X + 6, loc.Y + 8);
            this.LabelIndoor[OvalShapeCounter].Size = new System.Drawing.Size(40, 16);
            this.LabelIndoor[OvalShapeCounter].Text = inText;
            this.LabelIndoor[OvalShapeCounter].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Controls.Add(LabelIndoor[OvalShapeCounter]);
            LabelIndoor[OvalShapeCounter].BringToFront();
            OvalShapeCounter++;
        }

        /// <summary>
        /// check every line by X(hight_width) for contact 
        /// </summary>
        /// <param name="hight_Width">X of Uper Line |</param>
        /// <returns></returns>
        private int checkLineOverride(int _Width, string Arrow, int SourceNodeLevel)
        {
            bool Found = false;
            do
            {
                Found = false;
                for (int i = 0; i < OvalShapeCounter; i++)
                {
                    if (OvalShapeNode[i].Location.X == _Width && i > SourceNodeLevel)
                    {
                        if (Arrow == "Left")
                            _Width -= 50;
                        else if (Arrow == "Right")
                            _Width += 50;
                        Found = true;
                        break;
                    }
                }
            } while (Found);
            return _Width;
        }

        int LineShapeCounter = 0;
        /// <summary>
        /// Draw 4 Line:
        /// 
        /// (Start Point).____________        or         ____________.(Start Point)
        ///                           |                 |
        ///                           |                 |
        ///                         \ | /             \ | /
        ///                          \|/               \|/
        ///                           .                 .
        ///                       (End Point)       (End Point)
        /// </summary>
        /// <param name="Startloc"> Start Point</param>
        /// <param name="Endloc"> End Point </param>
        /// <param name="RL"> Right Arrow or Left Arrow </param>
        private void DrawLineArrow(Point Startloc, Point Endloc)
        {
            char RL = (Startloc.X < Endloc.X) ? 'R' : 'L';
            Startloc = new Point(Startloc.X + 30, Startloc.Y + 15);
            Endloc = new Point(Endloc.X + 30, Endloc.Y);
            switch (RL)
            {
                case 'R':
                    #region Right Arrow
                    {
                        // Right Arrow:
                        //
                        // (Start Point).____________        
                        //                           |       
                        //                           |       
                        //                         \ | /     
                        //                          \|/      
                        //                           .       
                        //                       (End Point)  
                        // 
                        // lineShapeArrow (Right Line -)
                        // 
                        if (LineShapeCounter >= numArrow) return;
                        LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.LineShapeArrow[LineShapeCounter].X1 = Startloc.X;
                        this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].Y1 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].Y2 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
                        this.LineShapeArrow[LineShapeCounter].BorderColor = Color.Red;
                        this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
                        LineShapeCounter++;
                        // 
                        // lineShapeArrow (Up Line |)
                        // 
                        if (LineShapeCounter >= numArrow) return;
                        LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.LineShapeArrow[LineShapeCounter].X1 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].Y1 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].Y2 = Endloc.Y;
                        this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
                        this.LineShapeArrow[LineShapeCounter].BorderColor = Color.Red;
                        this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
                        LineShapeCounter++;
                    }
                    break;
                    #endregion

                case 'L':
                    #region Left Arrow
                    {
                        // Left Arrow:
                        //
                        //      ____________.(Start Point)
                        //     |
                        //     |
                        //   \ | /
                        //    \|/
                        //     .
                        // (End Point)
                        // 
                        // lineShapeArrow (Left Line -)
                        // 
                        if (LineShapeCounter >= numArrow) return;
                        LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.LineShapeArrow[LineShapeCounter].X1 = Startloc.X;
                        this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].Y1 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].Y2 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
                        this.LineShapeArrow[LineShapeCounter].BorderColor = Color.Blue;
                        this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
                        LineShapeCounter++;
                        // 
                        // lineShapeArrow (Up Line |)
                        // 
                        if (LineShapeCounter >= numArrow) return;
                        LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                        this.LineShapeArrow[LineShapeCounter].X1 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
                        this.LineShapeArrow[LineShapeCounter].Y1 = Startloc.Y;
                        this.LineShapeArrow[LineShapeCounter].Y2 = Endloc.Y;
                        this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
                        this.LineShapeArrow[LineShapeCounter].BorderColor = Color.Blue;
                        this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
                        LineShapeCounter++;
                    }
                    break;
                    #endregion

                default: return;
            }
            // 
            // lineShapeArrow (Left Cross Line \)
            // 
            if (LineShapeCounter >= numArrow) return;
            LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.LineShapeArrow[LineShapeCounter].X1 = Endloc.X - 5;
            this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
            this.LineShapeArrow[LineShapeCounter].Y1 = Endloc.Y - 5;
            this.LineShapeArrow[LineShapeCounter].Y2 = Endloc.Y;
            this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
            this.LineShapeArrow[LineShapeCounter].BorderColor = (RL == 'L') ? Color.Blue : Color.Red;
            this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
            LineShapeCounter++;
            // 
            // lineShapeArrow (Right Cross Line /)
            // 
            if (LineShapeCounter >= numArrow) return;
            LineShapeArrow[LineShapeCounter] = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.LineShapeArrow[LineShapeCounter].X1 = Endloc.X + 5;
            this.LineShapeArrow[LineShapeCounter].X2 = Endloc.X;
            this.LineShapeArrow[LineShapeCounter].Y1 = Endloc.Y - 5;
            this.LineShapeArrow[LineShapeCounter].Y2 = Endloc.Y;
            this.LineShapeArrow[LineShapeCounter].BorderWidth = 2;
            this.LineShapeArrow[LineShapeCounter].BorderColor = (RL == 'L') ? Color.Blue : Color.Red;
            this.shapeContainerTree.Shapes.Add(LineShapeArrow[LineShapeCounter]);
            LineShapeCounter++;
        }

        /// <summary>
        /// Move All Controls (OvalShape , LineShapeArrow , Label , ...) to Right to the number of pick
        /// </summary>
        /// <param name="numberPick">is time of shift</param>
        private void ShiftAll2Right(int numberPick)
        {
            for (int counter = 0; counter < OvalShapeCounter; counter++)
            {
                this.OvalShapeNode[counter].Location = new Point(OvalShapeNode[counter].Location.X + numberPick,
                                                                 OvalShapeNode[counter].Location.Y);
                this.LabelIndoor[counter].Location = new Point(LabelIndoor[counter].Location.X + numberPick,
                                                               LabelIndoor[counter].Location.Y);
                Node_in_Level[counter] = 
                    new Point(Node_in_Level[counter].X + numberPick, Node_in_Level[counter].Y);
            }

            for (int counter = 0; counter < LineShapeCounter; counter++)
            {
                this.LineShapeArrow[counter].X1 = LineShapeArrow[counter].X1 + numberPick;
                this.LineShapeArrow[counter].X2 = LineShapeArrow[counter].X2 + numberPick;
            }
        }

        #endregion

        private void DesignForm_Load(object sender, EventArgs e)
        {
            start_Parsr(); 
        }

    }
}

struct NodeInfo
{
    public int StartLevel;
    public int EndLevel;
    public string Text;
    public string Arrow;
};