using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace Compiler_T1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        internal static List<TokenType> Body = new List<TokenType>();

        #region Scaner Method
        /// <summary>
        /// get any token in last line in a List of TokenType Struct's Frame
        /// </summary>
        /// <param name="last"></param>
        /// <returns></returns>
        private void getToken(string lastLine)
        {
            // create end of line 
            lastLine += " ";
            //
            // spell the last line to word
            char[] spell = lastLine.ToCharArray();
            int orderCounter = 1;

            string buffer = "";
            for (int index = 0; index < spell.Length; index++)
            //foreach (char token in spell)
            {
                char token = spell[index];

                #region WhiteSpace
                if (char.IsWhiteSpace(token)) // Example: "    " or Tab
                {
                    // find new token
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }
                    continue;
                }
                #endregion WhiteSpace
                #region Operand + - * /
                else if (token == '/' || token == '+' || token == '-' || token == '*') // read Operand Char
                {
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }
                    addToken(orderCounter, token.ToString(), "Operand");
                    orderCounter++;
                }
                #endregion Operand + - */
                #region Separator ( )
                else if (token == '(' || token == ')') // read Separator Char
                {
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }
                    addToken(orderCounter, token.ToString(), "Separator");
                    orderCounter++;
                }
                #endregion Separator ( )
                #region Number int, float, double
                else if (char.IsDigit(token) || token == '.')
                {
                    // save old unknow token and create new token space
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }

                    // ([digit][digit]*) = (int) 
                    Regex integer = new Regex(@"^([\d][\d]*)$"); // example:  123
                    //
                    // (int)e(int)
                    Regex integerDoubleSample = new Regex(@"^([\d][\d]*[\<e>][\d][\d]*)$"); // example:  123e123
                    //
                    // (int)e('-' or '+')(int)
                    Regex integerDouble = new Regex(@"^([\d][\d]*[\<e>]([\-|+])[\d][\d]*)$"); // example: 123e-123
                    //
                    // ([digit]*).(int)
                    Regex floating = new Regex(@"^([\d]*[\.][\d][\d]*)$"); // example: 123.123  or  .123
                    //
                    // ([digit]*).(int)e(int)
                    Regex floatDoubleSample = new Regex(@"^([\d]*[\.][\d][\d]*[\<e>][\d][\d]*)$"); // example: .123e123
                    //
                    // ([digit]*).(int)e('-' or '+')(int)
                    Regex floatDouble = new Regex(@"^([\d]*[\.][\d][\d]*[\<e>]([\-|+])[\d][\d]*)$"); // example: 0.123e+123

                    bool operand_checked = false;
                    do // read all characters of a num token's
                    {
                        if (token == 'e')
                        {
                            if (spell[index + 1] == '+' || spell[index + 1] == '-')
                            {
                                if (char.IsDigit(spell[index + 2]))
                                {
                                    operand_checked = true;
                                    buffer += token;
                                    index++;
                                    token = spell[index];
                                }
                                else break;
                            }
                            else if (char.IsDigit(spell[index + 1]))
                            {
                                buffer += token;
                                index++;
                                token = spell[index];
                                continue;
                            }
                            else break;
                        }
                        buffer += token;
                        index++;
                        token = spell[index];
                    }
                    while (char.IsDigit(token) || token == '.' || (token == 'e' && !operand_checked));

                    if (integer.IsMatch(buffer) || integerDouble.IsMatch(buffer) ||
                        integerDoubleSample.IsMatch(buffer) || floating.IsMatch(buffer) ||
                        floatDouble.IsMatch(buffer) || floatDoubleSample.IsMatch(buffer))
                    {
                        addToken(orderCounter, buffer, "Num");
                    }
                    else
                    {
                        addToken(orderCounter, buffer, "Unknow");
                    }
                    index--;
                    orderCounter++;
                    buffer = "";
                }
                #endregion
                #region Syntax error
                else // read number char or synatx error
                    buffer += token.ToString();
                #endregion Number or Syntax error
            }
            /*
            foreach (char token in spell)
            {
                if (char.IsWhiteSpace(token)) // Example: "    " or Tab
                {
                    // find new token
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }
                    continue;
                }

                else if (token == '/' || token == '+' || token == '-' || token == '*') // read Operand Char
                {
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";
                    }
                    addToken(orderCounter, token.ToString(), "Operand");
                    orderCounter++;
                }

                else if (token == '(' || token == ')') // read Separator Char
                {
                    if (buffer != "")
                    {
                        addToken(orderCounter, buffer, "Unknow");
                        orderCounter++;
                        buffer = "";

                    }
                    addToken(orderCounter, token.ToString(), "Separator");
                    orderCounter++;
                }
                else // read number char or synatx error
                    buffer += token.ToString();
            }
            */
        }

        private void addToken(int Order, string Token, string Type)
        {
            if (Type == "Num")
            {
                int intToken;
                if (int.TryParse(Token, out intToken))
                {
                    Type = "Int";
                    goto ExitAsFindType;
                }

                float fltToken;
                if (float.TryParse(Token, out fltToken))
                {
                    Type = "Float";
                    goto ExitAsFindType;
                }

                double dblToken;
                if (double.TryParse(Token, out dblToken))
                {
                    Type = "Double";
                    goto ExitAsFindType;
                }
                //
                // else
                Type = "Error"; // else for other type
            }
        ExitAsFindType:
            TokenType objToken = new TokenType();
            objToken.Order = Order;
            objToken.Token = Token;
            objToken.Type = Type;
            Body.Add(objToken);
        }

        bool EnterPressed = false;
        private void rtxtBody_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                EnterPressed = true;
                btnScaner_Click(sender, e);
            }
        }

        /// <summary>
        /// Scan The Last Line Data and Print Scaner DataSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScaner_Click(object sender, EventArgs e)
        {
            // open scaner datasource
            timerOpenDataSource.Enabled = true;
            //
            // clear Data Grid View Scaner in MainForm
            Body.Clear();
            //
            // refresh DataGridView Scaner DataSource by Latest Input Data
            if (!EnterPressed)
                rtxtBody.AppendText("\r");
            getToken((rtxtBody.Lines[rtxtBody.Lines.Length - 2]));
            

            #region Print Scaner Data Source

            dgvScaner.Columns.Clear();
            var sacaner = Body.Select(item1 => new { Order = item1.Order, Tokens = item1.Token, Type = item1.Type });
            dgvScaner.DataSource = sacaner.ToList();

            #endregion

            // Start Parser
            btnParser_Click(sender, e);

            EnterPressed = false;
        }
        #endregion

        #region Parser Method

        string Postfix = string.Empty; // for save or print postfix word
        TokenType Lookahead;
        int counter_lah = 0;
        TokenType[] aryBody;
        internal static bool error = true;

        private void btnParser_Click(object sender, EventArgs e)
        {
            error = false;
            Postfix = "";
            counter_lah = 0;
            aryBody = Body.ToArray();
            try
            {
                Lookahead = aryBody[counter_lah];
            }
            catch (Exception ex) 
            { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
            counter_lah++;
            E();
            if (!error)
                rtxtBody.AppendText("\n>> " + Postfix + "\n\n");
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

        private void E()
        {
            if (error) return;
            T();
            R1();
        }

        private void T()
        {
            if (error) return;
            F();
            R2();
        }

        private void F()
        {
            if (error) return;
            switch (Lookahead.Type)
            {
                case "Int":
                    {
                        string buffer = Lookahead.Token;
                        Match(Lookahead.Token);
                        Postfix += buffer + " ";
                    }
                    break;

                case "Float":
                    {
                        string buffer = Lookahead.Token;
                        Match(Lookahead.Token);
                        Postfix += buffer + " ";
                    }
                    break;

                case "Double":
                    {
                        string buffer = Lookahead.Token;
                        Match(Lookahead.Token);
                        Postfix += buffer + " ";
                    }
                    break;

                case "Separator":
                    {
                        if (Lookahead.Token == "(")
                        {
                            Match(Lookahead.Token);
                            E();
                            Match(")");
                        }
                    }
                    break;

                default: Error();
                    return;
            }
        }

        private void R1()
        {
            if (error) return;
            if (Lookahead.Token == "+")
            {
                Match("+");
                T();
                Postfix += "+ ";
                R1();
            }
            else if (Lookahead.Token == "-")
            {
                Match("-");
                T();
                Postfix += "- ";
                R1();
            }
            else Postfix += " ";
        }

        private void R2()
        {
            if (error) return;
            if (Lookahead.Token == "*")
            {
                Match("*");
                T();
                Postfix += "* ";
                R2();
            }
            else if (Lookahead.Token == "/")
            {
                Match("/");
                T();
                Postfix += "/ ";
                R2();
            }
            else Postfix += " ";
        }

        private void Error()
        {
            error = true;
            MessageBox.Show("cannot to parse this line", "Parser Error"
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        #endregion

        #region Graphics Code
        private void btnTree_Click(object sender, EventArgs e)
        {
            DesignForm df = new DesignForm();
            df.SetDesktopLocation(0, 0);
            this.Hide();
            df.ShowDialog();
            this.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Help.pdf");
        }

        /// <summary>
        /// start timer to open mainform to show scaner datasource 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerOpenDataSource_Tick(object sender, EventArgs e)
        {
            if (this.Size.Width < 700)
                this.Size = new Size(this.Size.Width + 5, this.Size.Height);
            else
            {
                this.Size = new Size(700, 490);
                timerOpenDataSource.Enabled = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            rtxtBody.Focus();
            rtxtBody.Select();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm About = new AboutForm();
            About.ShowDialog();
        }
        #endregion
    }

        
}

/// <summary>
/// Save Scaner Data in Token & Type of Token's
/// </summary>
struct TokenType
{
    public string Token;
    public string Type;
    public int Order; // number of token in every line
};
