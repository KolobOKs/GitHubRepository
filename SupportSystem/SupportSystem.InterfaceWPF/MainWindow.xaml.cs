using System;
using System.Windows;
using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.InterfaceWPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ProblemDetector.Initialize(DataBaseContext.Problems, DataBaseContext.Questions);
            ProblemDetector.QuestionFound += ProblemDetectorOnQuestionFound;
            ProblemDetector.RatiosChanged += ProblemDetectorOnRatiosChanged;
            ProblemDetector.ProblemFound += ProblemDetectorOnProblemFound;
            ProblemDetector.NextStateTransfer+= ProblemDetectorOnNextStateTransfer;
            foreach (ProblemRatio problemRatio in ProblemDetector.ProblemRatios)
            {
                ProblemsListBox.Items.Add(problemRatio);
            }
        }

        private void ProblemDetectorOnNextStateTransfer(object sender, EventArgs eventArgs)
        {
            MainTabControl.SelectedIndex = 4;
        }

        private void ProblemDetectorOnProblemFound(object sender, ProblemFoundEventArgs problemFoundEventArgs)
        {
            MainTabControl.SelectedIndex = 2;
            ProblemTextBlock.Text = problemFoundEventArgs.Problem.ShortName;
        }

        private void ProblemDetectorOnRatiosChanged(object sender, EventArgs eventArgs)
        {
            ProblemsListBox.Items.Clear();
            foreach (ProblemRatio problemRatio in ProblemDetector.ProblemRatios)
            {
                ProblemsListBox.Items.Add(problemRatio);
            }
        }

        private void ProblemDetectorOnQuestionFound(object sender, QuestionFoundEventArgs questionFoundEventArgs)
        {
            QuestionTextBlock.Text = questionFoundEventArgs.Question.QuestionText;
            MainTabControl.SelectedIndex = 1;
        }

        private void Preset1Button_Click(object sender, RoutedEventArgs e)
        {
            PresetFacade.Presets[0].MakePreset();
        }

        private void YesAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemDetector.AnswerCalculation(true);
        }

        private void NoAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemDetector.AnswerCalculation(false);
        }

        private void SkipAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemDetector.AnswerCalculation(null);
        }

        private void ProblemSolvedButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemDetector.ConfirmedAssumption();
            MainTabControl.SelectedIndex = 3;
        }

        private void WrongProblemButton_Click(object sender, RoutedEventArgs e)
        {
            ProblemDetector.WrongProblem();
        }
    }
}