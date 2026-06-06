using BruteForcePasswordReset.Core;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BruteForcePasswordReset.UI
{
    public partial class MainForm : Form
    {
        private readonly AttackCoordinator _coordinator = new AttackCoordinator();
        private readonly PerformanceLogger _logger = new PerformanceLogger();

        private string _currentPassword = "";
        private string _currentHash = "";

        private CancellationTokenSource _cts;

        public MainForm()
        {
            InitializeComponent();

            // Automatically set thread count = CPU cores - 1
            numThreads.Value = Math.Max(1, Environment.ProcessorCount - 1);
            numThreads.Maximum = Environment.ProcessorCount;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var result = _coordinator.GeneratePasswordAndHash();

            _currentPassword = result.Password;
            _currentHash = result.Hash;

            lblPassword.Text = "Password: " + _currentPassword;
            lblHash.Text = "Hash: " + _currentHash;

            Log("Generated password and hash.");

            // reset UI stats
            lblAttempts.Text = "Attempts: 0";
            lblElapsed.Text = "Elapsed: 0 ms";
            progressBar.Value = 0;
        }

        private async void btnSingle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentHash))
            {
                Log("Generate a password first.");
                return;
            }

            DisableButtonsForRun();

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Log("Running single-thread brute force...");

            var result = await Task.Run(() =>
            {
                return _coordinator.RunSingleThread(
                    _currentHash,
                    token,
                    _ => { }   // ignore live progress
                );
            });

            if (result.Found)
                Log($"Single-thread result: {result.Password} in {result.Elapsed.TotalMilliseconds} ms");
            else
                Log("Single-thread brute force stopped.");

            // update UI with final stats
            lblAttempts.Text = $"Attempts: {result.Attempts}";
            lblElapsed.Text = $"Elapsed: {result.Elapsed.TotalMilliseconds:F2} ms";

            if (result.Attempts > 0)
            {
                progressBar.Maximum = (int)Math.Min(result.Attempts, int.MaxValue);
                progressBar.Value = progressBar.Maximum;
            }
            else
            {
                progressBar.Value = 0;
            }

            EnableButtonsAfterRun();
        }

        private async void btnMulti_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentHash))
            {
                Log("Generate a password first.");
                return;
            }

            int threads = (int)numThreads.Value;

            DisableButtonsForRun();

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            Log($"Running multi-thread brute force with {threads} threads...");

            var result = await Task.Run(() =>
            {
                return _coordinator.RunMultiThread(
                    _currentHash,
                    threads,
                    token,
                    _ => { }   // ignore live progress
                );
            });

            if (result.Found)
                Log($"Multi-thread result: {result.Password} in {result.Elapsed.TotalMilliseconds} ms");
            else
                Log("Multi-thread brute force stopped.");

            // update UI with final stats
            lblAttempts.Text = $"Attempts: {result.Attempts}";
            lblElapsed.Text = $"Elapsed: {result.Elapsed.TotalMilliseconds:F2} ms";

            if (result.Attempts > 0)
            {
                progressBar.Maximum = (int)Math.Min(result.Attempts, int.MaxValue);
                progressBar.Value = progressBar.Maximum;
            }
            else
            {
                progressBar.Value = 0;
            }

            EnableButtonsAfterRun();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            Log("STOP requested...");
        }

        private void DisableButtonsForRun()
        {
            btnGenerate.Enabled = false;
            btnSingle.Enabled = false;
            btnMulti.Enabled = false;
            btnStop.Enabled = true;
        }

        private void EnableButtonsAfterRun()
        {
            btnGenerate.Enabled = true;
            btnSingle.Enabled = true;
            btnMulti.Enabled = true;
            btnStop.Enabled = false;
        }

        private void Log(string message)
        {
            _logger.Log(message);
            txtLog.AppendText(message + Environment.NewLine);
        }
    }
}
