namespace WinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            InputText = new TextBox();
            label2 = new Label();
            label3 = new Label();
            LoadLetterFrequencies = new CheckBox();
            label4 = new Label();
            button1 = new Button();
            label5 = new Label();
            LetterFrequencyList = new TextBox();
            DoubleLetterFrequencyList = new TextBox();
            label6 = new Label();
            TripleLetterFrequencyList = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox3 = new TextBox();
            label10 = new Label();
            ReplaceLetter1 = new TextBox();
            button2 = new Button();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            ReplaceLetter2 = new TextBox();
            button3 = new Button();
            label14 = new Label();
            OutputText = new RichTextBox();
            label15 = new Label();
            DictionaryInput = new TextBox();
            DictionaryList = new RichTextBox();
            label16 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Input Text";
            // 
            // InputText
            // 
            InputText.Location = new Point(12, 27);
            InputText.Multiline = true;
            InputText.Name = "InputText";
            InputText.ScrollBars = ScrollBars.Vertical;
            InputText.Size = new Size(229, 411);
            InputText.TabIndex = 1;
            InputText.TextChanged += InputText_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(434, 12);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Settings";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 40);
            label3.Name = "label3";
            label3.Size = new Size(173, 15);
            label3.TabIndex = 4;
            label3.Text = "Show/Hide Letter Frequencies";
            // 
            // LoadLetterFrequencies
            // 
            LoadLetterFrequencies.AutoSize = true;
            LoadLetterFrequencies.Location = new Point(509, 40);
            LoadLetterFrequencies.Name = "LoadLetterFrequencies";
            LoadLetterFrequencies.Size = new Size(15, 14);
            LoadLetterFrequencies.TabIndex = 5;
            LoadLetterFrequencies.UseVisualStyleBackColor = true;
            LoadLetterFrequencies.CheckedChanged += LoadLetterFrequencies_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(332, 70);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 6;
            label4.Text = "Decode Cipher";
            // 
            // button1
            // 
            button1.Location = new Point(444, 66);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Click Me";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(285, 106);
            label5.Name = "label5";
            label5.Size = new Size(139, 15);
            label5.TabIndex = 9;
            label5.Text = "Single Letter Frequency:";
            // 
            // LetterFrequencyList
            // 
            LetterFrequencyList.Location = new Point(285, 124);
            LetterFrequencyList.Multiline = true;
            LetterFrequencyList.Name = "LetterFrequencyList";
            LetterFrequencyList.ReadOnly = true;
            LetterFrequencyList.ScrollBars = ScrollBars.Vertical;
            LetterFrequencyList.Size = new Size(312, 115);
            LetterFrequencyList.TabIndex = 10;
            // 
            // DoubleLetterFrequencyList
            // 
            DoubleLetterFrequencyList.Location = new Point(294, 280);
            DoubleLetterFrequencyList.Multiline = true;
            DoubleLetterFrequencyList.Name = "DoubleLetterFrequencyList";
            DoubleLetterFrequencyList.ReadOnly = true;
            DoubleLetterFrequencyList.ScrollBars = ScrollBars.Vertical;
            DoubleLetterFrequencyList.Size = new Size(152, 158);
            DoubleLetterFrequencyList.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(294, 262);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "2 Letter:";
            // 
            // TripleLetterFrequencyList
            // 
            TripleLetterFrequencyList.Location = new Point(452, 280);
            TripleLetterFrequencyList.Multiline = true;
            TripleLetterFrequencyList.Name = "TripleLetterFrequencyList";
            TripleLetterFrequencyList.ReadOnly = true;
            TripleLetterFrequencyList.ScrollBars = ScrollBars.Vertical;
            TripleLetterFrequencyList.Size = new Size(145, 158);
            TripleLetterFrequencyList.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(452, 262);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 13;
            label7.Text = "3 Letter:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(644, 12);
            label8.Name = "label8";
            label8.Size = new Size(159, 15);
            label8.TabIndex = 15;
            label8.Text = "Letter Frequency in English:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(575, 27);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 16;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Arial", 7.75F, FontStyle.Bold);
            textBox3.HideSelection = false;
            textBox3.Location = new Point(644, 39);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(261, 22);
            textBox3.TabIndex = 17;
            textBox3.Text = "E,T,A,S,I,N,R,O,H,L,D,U,C,M,W,G,Y,P,F,B,V,K,J,X,Z,Q";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(404, 467);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 18;
            label10.Text = "Output Text";
            // 
            // ReplaceLetter1
            // 
            ReplaceLetter1.Cursor = Cursors.IBeam;
            ReplaceLetter1.Location = new Point(795, 133);
            ReplaceLetter1.MaxLength = 1;
            ReplaceLetter1.Name = "ReplaceLetter1";
            ReplaceLetter1.Size = new Size(100, 21);
            ReplaceLetter1.TabIndex = 19;
            // 
            // button2
            // 
            button2.Location = new Point(768, 199);
            button2.Name = "button2";
            button2.Size = new Size(127, 23);
            button2.TabIndex = 20;
            button2.Text = "Replace Letters!";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(647, 106);
            label11.Name = "label11";
            label11.Size = new Size(166, 15);
            label11.TabIndex = 21;
            label11.Text = "Replace Letter 1 with Letter 2";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(658, 136);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 22;
            label12.Text = "Letter 1";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(658, 163);
            label13.Name = "label13";
            label13.Size = new Size(48, 15);
            label13.TabIndex = 24;
            label13.Text = "Letter 2";
            // 
            // ReplaceLetter2
            // 
            ReplaceLetter2.Cursor = Cursors.IBeam;
            ReplaceLetter2.Location = new Point(795, 160);
            ReplaceLetter2.MaxLength = 1;
            ReplaceLetter2.Name = "ReplaceLetter2";
            ReplaceLetter2.Size = new Size(100, 21);
            ReplaceLetter2.TabIndex = 23;
            // 
            // button3
            // 
            button3.Location = new Point(658, 199);
            button3.Name = "button3";
            button3.Size = new Size(83, 23);
            button3.TabIndex = 25;
            button3.Text = "Reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(696, 73);
            label14.Name = "label14";
            label14.Size = new Size(165, 16);
            label14.TabIndex = 26;
            label14.Text = "Output Text Options Only";
            // 
            // OutputText
            // 
            OutputText.Location = new Point(12, 496);
            OutputText.Name = "OutputText";
            OutputText.ReadOnly = true;
            OutputText.ScrollBars = RichTextBoxScrollBars.Vertical;
            OutputText.Size = new Size(906, 199);
            OutputText.TabIndex = 27;
            OutputText.Text = "";
            OutputText.MouseClick += OutputText_MouseClick;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(647, 239);
            label15.Name = "label15";
            label15.Size = new Size(61, 15);
            label15.TabIndex = 30;
            label15.Text = "Dictionary";
            // 
            // DictionaryInput
            // 
            DictionaryInput.Location = new Point(647, 280);
            DictionaryInput.Name = "DictionaryInput";
            DictionaryInput.ReadOnly = true;
            DictionaryInput.Size = new Size(100, 21);
            DictionaryInput.TabIndex = 31;
            // 
            // DictionaryList
            // 
            DictionaryList.Location = new Point(768, 280);
            DictionaryList.Name = "DictionaryList";
            DictionaryList.Size = new Size(127, 158);
            DictionaryList.TabIndex = 32;
            DictionaryList.Text = "";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(603, 315);
            label16.Name = "label16";
            label16.Size = new Size(0, 15);
            label16.TabIndex = 33;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(647, 315);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 123);
            textBox1.TabIndex = 34;
            textBox1.Text = "Click on any word in the Output Text Box to search for similar words in the Dictionary";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 707);
            Controls.Add(textBox1);
            Controls.Add(label16);
            Controls.Add(DictionaryList);
            Controls.Add(DictionaryInput);
            Controls.Add(label15);
            Controls.Add(OutputText);
            Controls.Add(label14);
            Controls.Add(button3);
            Controls.Add(label13);
            Controls.Add(ReplaceLetter2);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(button2);
            Controls.Add(ReplaceLetter1);
            Controls.Add(label10);
            Controls.Add(textBox3);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(TripleLetterFrequencyList);
            Controls.Add(label7);
            Controls.Add(DoubleLetterFrequencyList);
            Controls.Add(label6);
            Controls.Add(LetterFrequencyList);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(LoadLetterFrequencies);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(InputText);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox InputText;
        private Label label2;
        private Label label3;
        private CheckBox LoadLetterFrequencies;
        private Label label4;
        private Button button1;
        private Label label5;
        private TextBox LetterFrequencyList;
        private TextBox DoubleLetterFrequencyList;
        private Label label6;
        private TextBox TripleLetterFrequencyList;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox3;
        private Label label10;
        private TextBox ReplaceLetter1;
        private Button button2;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox ReplaceLetter2;
        private Button button3;
        private Label label14;
        private RichTextBox OutputText;
        private Label label15;
        private TextBox DictionaryInput;
        private RichTextBox DictionaryList;
        private Label label16;
        private TextBox textBox1;
    }
}
