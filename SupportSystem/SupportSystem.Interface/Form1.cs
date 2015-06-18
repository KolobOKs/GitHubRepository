using System;
using System.Windows.Forms;
using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.Interface
{
    public partial class Form1 : Form
    {
        private Question _currentQuestion;

        private event EventHandler<AnswerEventArgs> _answerGiven; 


        public Form1()
        {
            InitializeComponent();
            ProblemDetector.Initialize(DataBaseContext.Problems, DataBaseContext.Questions);
            _answerGiven+= OnAnswerGiven;
        }

        private void OnAnswerGiven(object sender, AnswerEventArgs answerEventArgs)
        {
            try
            {
                ProblemDetector.AnswerCalculation(_currentQuestion, answerEventArgs.Result);
                problemsListBox.DataSource = ProblemDetector.ProblemRatios;
                problemsListBox.DisplayMember = "Problem.ShortName";
                problemsListBox.Refresh();
                _currentQuestion = ProblemDetector.GetNextQuestion();
                questionTextLabel.Text = _currentQuestion.QuestionText;
            }
            catch (NullReferenceException exception)
            {
                new AddNewQuestion(ProblemDetector.ProblemRatios[0].Problem, ProblemDetector.ProblemRatios[1].Problem)
                    .ShowDialog();
                detectedProblemLabel.Text = ProblemDetector.ProblemRatios[0].Problem.ShortName;
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
        }

        private void presetButton1_Click(object sender, EventArgs e)
        {
        }

        private void presetButton4_Click(object sender, EventArgs e)
        {
            PresetFacade.Presets[0].MakePreset();
            _currentQuestion = ProblemDetector.GetNextQuestion();
            questionTextLabel.Text = _currentQuestion.QuestionText;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            OnAnswerGiven(this,new AnswerEventArgs(true));
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            OnAnswerGiven(this,new AnswerEventArgs(false));
        }

        private void solvedButton_Click(object sender, EventArgs e)
        {
            ProblemDetector.ConfirmedAssumption(ProblemDetector.ProblemRatios[0]);
            this.Close();
        }

        private void unsolvedButton_Click(object sender, EventArgs e)
        {
            ProblemDetector.MistakenBelief(ProblemDetector.ProblemRatios[0]);
            _currentQuestion = ProblemDetector.GetNextQuestion();
            questionTextLabel.Text = _currentQuestion.QuestionText;
        }

        private void missQuestion_Click(object sender, EventArgs e)
        {
            OnAnswerGiven(this, new AnswerEventArgs(null));
        }
    }

    public class AnswerEventArgs : EventArgs
    {
        public bool? Result { get; set; }

        public AnswerEventArgs(bool? result)
        {
            Result = result;
        }
    }
}