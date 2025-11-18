using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows.Forms;
using Bps.BpsBase.Entities.Constants;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.Core.GlobalStaticsVariables;
using Newtonsoft.Json;

namespace BPS.Windows.Service
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Application.ThreadException +=
			//new ThreadExceptionEventHandler(Application_ThreadException);

			Param.SetAdaptation(Adaptation.SelmaCilek);

			if (Param.SELF_HOST)
			{
				HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(Param.API_ADDRESS);
				config.MapHttpAttributeRoutes();

				config.Routes.MapHttpRoute(
					name: "DefaultApi",
					routeTemplate: "api/{controller}/{id}",
					defaults: new { id = RouteParameter.Optional }
				);

				config.Routes.MapHttpRoute(
					name: "Image",
					routeTemplate: "api/{controller}/{action}/{*folderName}",
					defaults: new { controller = "StaticFile", action = "GetImageList", folderName = RouteParameter.Optional }
				);

				// Static file route
				config.Routes.MapHttpRoute(
					name: "StaticFiles",
					routeTemplate: "teknik/{*filePath}",
					defaults: new { controller = "StaticFile", action = "GetFile" }
				);

				var json = config.Formatters.JsonFormatter;
				json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
				config.Formatters.Remove(config.Formatters.XmlFormatter);
				config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

				HttpSelfHostServer server = new HttpSelfHostServer(config);
				server.OpenAsync().Wait();
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmService());
		}

		//static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		//{

		//    var fromAddress = new MailAddress("ilkaygumus@gmail.com", "İlkay");
		//    var toAddress = new MailAddress("ilkaygumus@gmail.com", "İlkay");
		//    const string fromPassword = "";
		//    const string subject = "exception report";
		//    Exception exception = e.Exception;
		//    string body = exception.Message + "\n" + exception.Data + "\n" + exception.StackTrace + "\n" + exception.Source;

		//    var smtp = new SmtpClient
		//    {
		//        Host = "smtp.gmail.com",
		//        Port = 587,
		//        EnableSsl = true,
		//        DeliveryMethod = SmtpDeliveryMethod.Network,
		//        UseDefaultCredentials = false,
		//        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
		//    };
		//    using (var message = new MailMessage(fromAddress, toAddress)
		//    {
		//        Subject = subject,
		//        Body = body
		//    })
		//    {
		//        //You can also use SendAsync method instead of Send so your application begin invoking instead of waiting for send mail to complete. SendAsync(MailMessage, Object) :- Sends the specified e-mail message to an SMTP server for delivery. This method does not block the calling thread and allows the caller to pass an object to the method that is invoked when the operation completes. 
		//        smtp.Send(message);
		//    }
		//}
	}
}
