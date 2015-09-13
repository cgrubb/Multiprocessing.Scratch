namespace Multiprocessing.Scratch
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Diagnostics;
  using System.IO;
  using MultiProcessing.Scratch.Master;

  /// <summary>
  /// Main program
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Main program method
    /// </summary>
    /// <param name="args">Command line arguments</param>
    public static void Main(string[] args)
    {
      var host = new Host();
      host.Start();
      Console.ReadLine();
      host.Stop();
    }    
  }
}
