namespace SupportSystem.Interface
{
    partial class AddNewQuestion
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
            this.problem1Label = new DevExpress.XtraEditors.LabelControl();
            this.problem2Label = new DevExpress.XtraEditors.LabelControl();
            this.newQuestionText = new System.Windows.Forms.TextBox();
            this.prob1Yes = new System.Windows.Forms.TextBox();
            this.prob1No = new System.Windows.Forms.TextBox();
            this.prob2No = new System.Windows.Forms.TextBox();
            this.prob2Yes = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // problem1Label
            // 
            this.problem1Label.Location = new System.Drawing.Point(12, 26);
            this.problem1Label.Name = "problem1Label";
            this.problem1Label.Size = new System.Drawing.Size(94, 19);
            this.problem1Label.TabIndex = 0;
            this.problem1Label.Text = "labelControl1";
            // 
            // problem2Label
            // 
            this.problem2Label.Location = new System.Drawing.Point(12, 64);
            this.problem2Label.Name = "problem2Label";
            this.problem2Label.Size = new System.Drawing.Size(94, 19);
            this.problem2Label.TabIndex = 1;
            this.problem2Label.Text = "labelControl2";
            // 
            // newQuestionText
            // 
            this.newQuestionText.Location = new System.Drawing.Point(12, 107);
            this.newQuestionText.Name = "newQuestionText";
            this.newQuestionText.Size = new System.Drawing.Size(595, 26);
            this.newQuestionText.TabIndex = 2;
            this.newQuestionText.Text = "newQuestionText";
            // 
            // prob1Yes
            // 
            this.prob1Yes.Location = new System.Drawing.Point(13, 140);
            this.prob1Yes.Name = "prob1Yes";
            this.prob1Yes.Size = new System.Drawing.Size(100, 26);
            this.prob1Yes.TabIndex = 3;
            this.prob1Yes.Text = "0";
            this.prob1Yes.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // prob1No
            // 
            this.prob1No.Location = new System.Drawing.Point(119, 139);
            this.prob1No.Name = "prob1No";
            this.prob1No.Size = new System.Drawing.Size(100, 26);
            this.prob1No.TabIndex = 4;
            this.prob1No.Text = "0";
            // 
            // prob2No
            // 
            this.prob2No.Location = new System.Drawing.Point(507, 139);
            this.prob2No.Name = "prob2No";
            this.prob2No.Size = new System.Drawing.Size(100, 26);
            this.prob2No.TabIndex = 6;
            this.prob2No.Text = "0";
            // 
            // prob2Yes
            // 
            this.prob2Yes.Location = new System.Drawing.Point(401, 140);
            this.prob2Yes.Name = "prob2Yes";
            this.prob2Yes.Size = new System.Drawing.Size(100, 26);
            this.prob2Yes.TabIndex = 5;
            this.prob2Yes.Text = "0";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(247, 142);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(135, 53);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // AddNewQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 207);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.prob2No);
            this.Controls.Add(this.prob2Yes);
            this.Controls.Add(this.prob1No);
            this.Controls.Add(this.prob1Yes);
            this.Controls.Add(this.newQuestionText);
            this.Controls.Add(this.problem2Label);
            this.Controls.Add(this.problem1Label);
            this.Name = "AddNewQuestion";
            this.Text = "AddNewQuestion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl problem1Label;
        private DevExpress.XtraEditors.LabelControl problem2Label;
        private System.Windows.Forms.TextBox newQuestionText;
        private System.Windows.Forms.TextBox prob1Yes;
        private System.Windows.Forms.TextBox prob1No;
        private System.Windows.Forms.TextBox prob2No;
        private System.Windows.Forms.TextBox prob2Yes;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}