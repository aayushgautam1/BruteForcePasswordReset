namespace BruteForcePasswordReset.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnGenerate = new Button();
            lblPassword = new Label();
            lblHash = new Label();
            btnSingle = new Button();
            btnMulti = new Button();
            numThreads = new NumericUpDown();
            lblThreads = new Label();
            txtLog = new TextBox();
            btnStop = new Button();
            progressBar = new ProgressBar();
            lblAttempts = new Label();
            lblElapsed = new Label();
            ((System.ComponentModel.ISupportInitialize)numThreads).BeginInit();
            SuspendLayout();
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 12);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(225, 51);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Generate Password";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 91);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Password:";
            // 
            // lblHash
            // 
            lblHash.AutoSize = true;
            lblHash.Location = new Point(12, 128);
            lblHash.Name = "lblHash";
            lblHash.Size = new Size(45, 20);
            lblHash.TabIndex = 3;
            lblHash.Text = "Hash:";
            // 
            // btnSingle
            // 
            btnSingle.Location = new Point(12, 179);
            btnSingle.Name = "btnSingle";
            btnSingle.Size = new Size(185, 29);
            btnSingle.TabIndex = 4;
            btnSingle.Text = "Run Single Thread";
            btnSingle.UseVisualStyleBackColor = true;
            btnSingle.Click += btnSingle_Click;
            // 
            // btnMulti
            // 
            btnMulti.Location = new Point(12, 244);
            btnMulti.Name = "btnMulti";
            btnMulti.Size = new Size(185, 29);
            btnMulti.TabIndex = 5;
            btnMulti.Text = "Run Multi Thread";
            btnMulti.UseVisualStyleBackColor = true;
            btnMulti.Click += btnMulti_Click;
            // 
            // numThreads
            // 
            numThreads.Location = new Point(304, 242);
            numThreads.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numThreads.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numThreads.Name = "numThreads";
            numThreads.Size = new Size(150, 27);
            numThreads.TabIndex = 6;
            numThreads.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // lblThreads
            // 
            lblThreads.AutoSize = true;
            lblThreads.Location = new Point(234, 244);
            lblThreads.Name = "lblThreads";
            lblThreads.Size = new Size(64, 20);
            lblThreads.TabIndex = 7;
            lblThreads.Text = "Threads:";
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Bottom;
            txtLog.Location = new Point(0, 453);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(795, 201);
            txtLog.TabIndex = 8;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(12, 300);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(185, 34);
            btnStop.TabIndex = 9;
            btnStop.Text = "STOP";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Enabled = false;
            btnStop.Click += btnStop_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(0, 362);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(795, 30);
            progressBar.TabIndex = 10;
            // 
            // lblAttempts
            // 
            lblAttempts.AutoSize = true;
            lblAttempts.Location = new Point(12, 400);
            lblAttempts.Name = "lblAttempts";
            lblAttempts.Size = new Size(85, 20);
            lblAttempts.TabIndex = 11;
            lblAttempts.Text = "Attempts: 0";
            // 
            // lblElapsed
            // 
            lblElapsed.AutoSize = true;
            lblElapsed.Location = new Point(200, 400);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.Size = new Size(99, 20);
            lblElapsed.TabIndex = 12;
            lblElapsed.Text = "Elapsed: 0 ms";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 654);
            Controls.Add(lblElapsed);
            Controls.Add(lblAttempts);
            Controls.Add(progressBar);
            Controls.Add(btnStop);
            Controls.Add(txtLog);
            Controls.Add(lblThreads);
            Controls.Add(numThreads);
            Controls.Add(btnMulti);
            Controls.Add(btnSingle);
            Controls.Add(lblHash);
            Controls.Add(lblPassword);
            Controls.Add(btnGenerate);
            Name = "MainForm";
            Text = "Brute Force Password Reset";
            ((System.ComponentModel.ISupportInitialize)numThreads).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGenerate;
        private Label lblPassword;
        private Label lblHash;
        private Button btnSingle;
        private Button btnMulti;
        private NumericUpDown numThreads;
        private Label lblThreads;
        private TextBox txtLog;
        private Button btnStop;
        private ProgressBar progressBar;
        private Label lblAttempts;
        private Label lblElapsed;
    }
}
