using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.AdminInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            problemsListBox.SelectedIndexChanged += ProblemsListBoxOnSelectedIndexChanged;
            RefreshProblems();
        }

        private void ProblemsListBoxOnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            RefreshQuestions(problemsListBox.SelectedValue as Problem);
        }

        private void RefreshProblems()
        {
            problemsListBox.Items.Clear();
            problemsListBox.DataSource = DataBaseContext.Problems.ToArray();
            problemsListBox.DisplayMember = "ShortName";
        }

        private void RefreshQuestions(Problem problem)
        {
            questionsListBox.Items.Clear();
            if (problem == null)
                return;
            List<Question> allQuestions = DataBaseContext.Questions.ToList();
            Question[] neededQuestions = (from question in allQuestions
                let flag =
                    question.Relationships.All(relationship => relationship.Problem.ShortName != problem.ShortName)
                where flag
                select question).ToArray();
            questionsListBox.DataSource=neededQuestions;
            questionsListBox.DisplayMember = "QuestionText";
        }

        private void newRelationshipButton_Click(object sender, EventArgs e)
        {
            foreach (Question selectedItem in questionsListBox.CheckedItems)
            {
                DataBaseContext.CreateRelationship(new ProblemQuestionRelationship(
                    problemsListBox.SelectedValue as Problem, selectedItem,
                    Int32.Parse(yesTextBox.Text), Int32.Parse(NoTextBox.Text)));
            }
            RefreshProblems();
        }

        private void newQuestionButton_Click(object sender, EventArgs e)
        {
            DataBaseContext.CreateQuestion(new Question(newQuestionTextBox.Text));
            newQuestionTextBox.Text = "";
        }

        private void newProblemButton_Click(object sender, EventArgs e)
        {
            DataBaseContext.CreateProblem(new Problem(newProblemTextBox.Text, "none"));
            RefreshProblems();
            newProblemTextBox.Text = "";
        }
    }
}