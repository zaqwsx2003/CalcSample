using Microsoft.JScript;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 초기0존재시 데이터클리어
        /// </summary>
        private void ZeroClear()
        {
            if (lblSum.Text == "0") { lblSum.Text = string.Empty; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ZeroClear();
            lblSum.Text += "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text = lblSum.Text.Substring(0, lblSum.Text.Length - 1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text += "*";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text += "/";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text += "+";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text += "-";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (lblSum.Text != string.Empty)
            {
                lblSum.Text = Evaluator.EvalToDouble(lblSum.Text).ToString();
            }
        }

        /// <summary>
        /// 클리어
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            lblSum.Text = "0";
        }
    }


    public class Evaluator
    {
        public static int EvalToInteger(string statement)
        {
            string s = EvalToString(statement);
            return int.Parse(s.ToString());
        }

        public static double EvalToDouble(string statement)
        {
            string s = EvalToString(statement);
            return double.Parse(s);
        }

        public static string EvalToString(string statement)
        {
            object o = EvalToObject(statement);
            return o.ToString();
        }

        public static object EvalToObject(string statement)
        {
            return _evaluatorType.InvokeMember(
                        "Eval",
                        BindingFlags.InvokeMethod,
                        null,
                        _evaluator,
                        new object[] { statement }
                     );
        }

        static Evaluator()
        {
            ICodeCompiler compiler;
            compiler = new JScriptCodeProvider().CreateCompiler();

            CompilerParameters parameters;
            parameters = new CompilerParameters();
            parameters.GenerateInMemory = true;

            CompilerResults results;
            results = compiler.CompileAssemblyFromSource(parameters, _jscriptSource);

            Assembly assembly = results.CompiledAssembly;
            _evaluatorType = assembly.GetType("Evaluator.Evaluator");

            _evaluator = Activator.CreateInstance(_evaluatorType);
        }

        private static object _evaluator = null;
        private static Type _evaluatorType = null;
        private static readonly string _jscriptSource =

            @"package Evaluator
            {
               class Evaluator
               {
                  public function Eval(expr : String) : String 
                  { 
                     return eval(expr); 
                  }
               }
            }";
    }
}
