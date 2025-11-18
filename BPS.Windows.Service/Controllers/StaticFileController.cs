using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Bps.BpsBase.Entities.Constants;
using Bps.Core.GlobalStaticsVariables;

namespace BPS.Windows.Service.Controllers
{
	public class StaticFileController : ApiController
	{
		string teknikFolder = "";

		public StaticFileController()
		{
			teknikFolder = AppDomain.CurrentDomain.BaseDirectory + "teknik\\";
			teknikFolder = @"D:\GDrive\Projects\_BitBucket\BPS\Bps.BpsBase.WinForm\bin\Debug\servis\teknik\";
		}

		[HttpGet]
		public HttpResponseMessage GetFile(string filePath)
		{
			string fileFullPath = Path.Combine(teknikFolder, filePath).Replace('/', '\\');

			if (!File.Exists(fileFullPath))
			{
				return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
			}

			var response = new HttpResponseMessage();
			response.Content = new ByteArrayContent(File.ReadAllBytes(fileFullPath));
			response.Content.Headers.ContentType = GetMimeType(fileFullPath);
			return response;
		}

		[HttpGet]
		[Route("api/images/list/{*folderName}")]
		public IHttpActionResult GetImageList(string folderName)
		{
			string folderPath = Path.Combine(teknikFolder, folderName).Replace('/', '\\');

			List<string> imageUrls = new List<string>();
			if (!Directory.Exists(folderPath)) return Ok(imageUrls);

			string[] imageFiles = Directory.GetFiles(folderPath)
				.Where(file => file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".jpeg") || file.ToLower().EndsWith(".png"))
				.ToArray();

			foreach (var file in imageFiles)
			{
				string fileName = Path.GetFileName(file);
				string fileUrl = $"{Param.API_ADDRESS}/teknik/{folderName}/{fileName}";
				imageUrls.Add(fileUrl);
			}

			return Ok(imageUrls);
		}

		private MediaTypeHeaderValue GetMimeType(string filePath)
		{
			// Determine MIME type based on file extension
			string extension = Path.GetExtension(filePath).ToLowerInvariant();
			switch (extension)
			{
				case ".jpg":
				case ".jpeg":
					return new MediaTypeHeaderValue("image/jpeg");
				case ".png":
					return new MediaTypeHeaderValue("image/png");
				case ".gif":
					return new MediaTypeHeaderValue("image/gif");
				default:
					return new MediaTypeHeaderValue("application/octet-stream");
			}
		}
	}
}