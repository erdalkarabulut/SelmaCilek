using System;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.WinForm;


//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net", ConfigFileExtension = "config")]
namespace BPS.Windows.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
	        Param.SetAdaptation(Adaptation.SelmaCilek);

            CompositionRoot.Wire(new BusinessModule());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");

            //Application.Run(new FrmTakvim());
            //Application.Run(new TempForm());
            //Application.Run(CompositionRoot.Resolve<TempForm>());
            Application.Run(CompositionRoot.Resolve<FrmLogin>());
            //Application.Run(CompositionRoot.Resolve<FrmShopiFYProductEntegrasyon>());
        }
    }
}