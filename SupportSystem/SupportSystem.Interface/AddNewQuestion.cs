using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.Interface
{
    public partial class AddNewQuestion : Form
    {
        private Problem _problem1;
        private Problem _problem2;
        public AddNewQuestion(Problem problem1, Problem problem2)
        {
            InitializeComponent();
            problem1Label.Text = problem1.ShortName;
            problem2Label.Text = problem2.ShortName;
            _problem1 = problem1;
            _problem2 = problem2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var newQuestion = new Question(newQuestionText.Text);
            DataBaseContext.CreateQuestion(newQuestion);
            var relation1 = new ProblemQuestionRelationship(_problem1, newQuestion, Int32.Parse(prob1Yes.Text),
                Int32.Parse(prob1No.Text));
            var relation2 = new ProblemQuestionRelationship(_problem2, newQuestion, Int32.Parse(prob2Yes.Text),
                Int32.Parse(prob2No.Text));
            DataBaseContext.CreateRelationship(relation1);
            DataBaseContext.CreateRelationship(relation2);
            this.Close();
        }
    }
}
