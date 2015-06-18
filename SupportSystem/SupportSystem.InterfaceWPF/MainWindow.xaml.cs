using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SupportSystem.Core;
using SupportSystem.Core.Commons;

namespace SupportSystem.InterfaceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ProblemDetector.Initialize(DataBaseContext.Problems,DataBaseContext.Questions);
            ProblemDetector.QuestionFound+= ProblemDetectorOnQuestionFound;
            ProblemDetector.RatiosChanged+= ProblemDetectorOnRatiosChanged;
            ProblemDetector.ProblemFound+= ProblemDetectorOnProblemFound;
            ProblemsRatingGrid.ItemsSource = ProblemDetector.ProblemRatios;
            ProblemsRatingGrid.RefreshData();
        }

        private void ProblemDetectorOnProblemFound(object sender, ProblemFoundEventArgs problemFoundEventArgs)
        {
            MainTabControl.SelectedIndex = 2;
            ProblemTextBlock.Text = problemFoundEventArgs.Problem.ShortName;
        }

        private void ProblemDetectorOnRatiosChanged(object sender, EventArgs eventArgs)
        {
            ProblemsRatingGrid.RefreshData();
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
    }
}
