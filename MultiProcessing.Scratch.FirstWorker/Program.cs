﻿namespace MultiProcessing.Scratch.FirstWorker
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;

  /// <summary>
  /// Worker process
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Worker process main method
    /// </summary>
    /// <param name="args">Command line arguments</param>
    public static void Main(string[] args)
    {
      //// Phone home
      while (true)
      {
        //// Spin uselessly
        Thread.Sleep(10);
        //// wait for exit signal or kill
      }
    }
  }
}
