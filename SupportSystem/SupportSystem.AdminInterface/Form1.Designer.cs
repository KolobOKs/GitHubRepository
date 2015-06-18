namespace SupportSystem.AdminInterface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.problemsListBox = new DevExpress.XtraEditors.ListBoxControl();
            this.questionsListBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.newProblemTextBox = new System.Windows.Forms.TextBox();
            this.newQuestionTextBox = new System.Windows.Forms.TextBox();
            this.yesTextBox = new System.Windows.Forms.TextBox();
            this.NoTextBox = new System.Windows.Forms.TextBox();
            this.newRelationshipButton = new DevExpress.XtraEditors.SimpleButton();
            this.newProblemButton = new DevExpress.XtraEditors.SimpleButton();
            this.newQuestionButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.problemsListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // problemsListBox
            // 
            this.problemsListBox.Location = new System.Drawing.Point(472, 13);
            this.problemsListBox.Name = "problemsListBox";
            this.problemsListBox.Size = new System.Drawing.Size(789, 214);
            this.problemsListBox.TabIndex = 0;
            // 
            // questionsListBox
            // 
            this.questionsListBox.Location = new System.Drawing.Point(472, 233);
            this.questionsListBox.Name = "questionsListBox";
            this.questionsListBox.Size = new System.Drawing.Size(789, 322);
            this.questionsListBox.TabIndex = 1;
            // 
            // newProblemTextBox
            // 
            this.newProblemTextBox.Location = new System.Drawing.Point(12, 12);
            this.newProblemTextBox.Name = "newProblemTextBox";
            this.newProblemTextBox.Size = new System.Drawing.Size(444, 26);
            this.newProblemTextBox.TabIndex = 2;
            // 
            // newQuestionTextBox
            // 
            this.newQuestionTextBox.Location = new System.Drawing.Point(12, 148);
            this.newQuestionTextBox.Name = "newQuestionTextBox";
            this.newQuestionTextBox.Size = new System.Drawing.Size(444, 26);
            this.newQuestionTextBox.TabIndex = 3;
            // 
            // yesTextBox
            // 
            this.yesTextBox.Location = new System.Drawing.Point(708, 561);
            this.yesTextBox.Name = "yesTextBox";
            this.yesTextBox.Size = new System.Drawing.Size(100, 26);
            this.yesTextBox.TabIndex = 4;
            this.yesTextBox.Text = "0";
            // 
            // NoTextBox
            // 
            this.NoTextBox.Location = new System.Drawing.Point(1023, 561);
            this.NoTextBox.Name = "NoTextBox";
            this.NoTextBox.Size = new System.Drawing.Size(100, 26);
            this.NoTextBox.TabIndex = 5;
            this.NoTextBox.Text = "0";
            // 
            // newRelationshipButton
            // 
            this.newRelationshipButton.Location = new System.Drawing.Point(1129, 561);
            this.newRelationshipButton.Name = "newRelationshipButton";
            this.newRelationshipButton.Size = new System.Drawing.Size(132, 47);
            this.newRelationshipButton.TabIndex = 6;
            this.newRelationshipButton.Text = "Новое отношение";
            this.newRelationshipButton.Click += new System.EventHandler(this.newRelationshipButton_Click);
            // 
            // newProblemButton
            // 
            this.newProblemButton.Location = new System.Drawing.Point(237, 44);
            this.newProblemButton.Name = "newProblemButton";
            this.newProblemButton.Size = new System.Drawing.Size(132, 47);
            this.newProblemButton.TabIndex = 7;
            this.newProblemButton.Text = "Новая проблема";
            this.newProblemButton.Click += new System.EventHandler(this.newProblemButton_Click);
            // 
            // newQuestionButton
            // 
            this.newQuestionButton.Location = new System.Drawing.Point(237, 180);
            this.newQuestionButton.Name = "newQuestionButton";
            this.newQuestionButton.Size = new System.Drawing.Size(132, 47);
            this.newQuestionButton.TabIndex = 8;
            this.newQuestionButton.Text = "Новый вопрос";
            this.newQuestionButton.Click += new System.EventHandler(this.newQuestionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 620);
            this.Controls.Add(this.newQuestionButton);
            this.Controls.Add(this.newProblemButton);
            this.Controls.Add(this.newRelationshipButton);
            this.Controls.Add(this.NoTextBox);
            this.Controls.Add(this.yesTextBox);
            this.Controls.Add(this.newQuestionTextBox);
            this.Controls.Add(this.newProblemTextBox);
            this.Controls.Add(this.questionsListBox);
            this.Controls.Add(this.problemsListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.problemsListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsListBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl problemsListBox;
        private DevExpress.XtraEditors.CheckedListBoxControl questionsListBox;
        private System.Windows.Forms.TextBox newProblemTextBox;
        private System.Windows.Forms.TextBox newQuestionTextBox;
        private System.Windows.Forms.TextBox yesTextBox;
        private System.Windows.Forms.TextBox NoTextBox;
        private DevExpress.XtraEditors.SimpleButton newRelationshipButton;
        private DevExpress.XtraEditors.SimpleButton newProblemButton;
        private DevExpress.XtraEditors.SimpleButton newQuestionButton;
    }
}

