// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Nick Pruehs">
//   Copyright 2013 Nick Pruehs.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Pathfinder
{
    using System;
    using System.Windows.Forms;

    using Pathfinder.Control;

    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    internal static class Program
    {
        #region Methods

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Controller controller = new Controller();
            Application.Run(controller.MainForm);
        }

        #endregion
    }
}