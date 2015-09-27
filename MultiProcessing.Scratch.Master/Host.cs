namespace MultiProcessing.Scratch.Master
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Threading;
  using System.Diagnostics;
  using System.IO;

  /// <summary>
  /// Control the processes
  /// </summary>
  public class Host
  {
    /// <summary>
    /// Exit flag
    /// </summary>
    private volatile bool exit = false;

    /// <summary>
    /// Start up the processes
    /// </summary>
    public void Start()
    {
      var masterThread = new Thread(this.Master);
      masterThread.Start();
    }

    /// <summary>
    /// Stop the processes by setting exit flag
    /// </summary>
    public void Stop()
    {
      this.exit = true;
    }

    /// <summary>
    /// Thread for monitoring processes
    /// </summary>
    private void ProcessMon()
    {

    }

    /// <summary>
    /// Start the processes and monitor them
    /// </summary>
    private void Master()
    {
      using (var context = NetMQContext.Create)
      //// Start processes
      var processPath = AppDomain.CurrentDomain.BaseDirectory;
      var workerPath = Path.Combine(processPath, "MultiProcessing.Scratch.FirstWorker.exe");
      var firstWorker = StartProcess(workerPath);
      var loggerPath = Path.Combine(processPath, "MultiProcessing.Scratch.Logger.exe");
      var logger = StartProcess(loggerPath);
      var processes = new Dictionary<Process, string>
      {
        { firstWorker, workerPath },
        { logger, loggerPath }
      };

      //// Wait for exit
      while (!this.exit)
      {
        var processList = processes.Keys.ToList();
        foreach (var process in processList)
        {          
          if (process.HasExited)
          {
            var newProcess = StartProcess(processes[process]);
            processes[newProcess] = processes[process];
            processes.Remove(process);
          }
        }
                
        Thread.Sleep(1);
      }

      //// Kill the processes
      foreach (var processKey in processes.Keys)
      {
        processKey.Kill();
      }      
    }

    /// <summary>
    /// Start up an external process and return a reference
    /// </summary>
    /// <param name="path">Process executable path</param>
    /// <returns>Process object</returns>
    private Process StartProcess(string path)
    {
      var startInfo = new ProcessStartInfo(path);
      startInfo.CreateNoWindow = false;
      startInfo.UseShellExecute = false;
      return Process.Start(startInfo);
    }
  }
}
