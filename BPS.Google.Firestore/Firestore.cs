using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Abstract.SH;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.Entities;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.Firestore;
using Bps.BpsBase.Entities.Models.GN.Enums;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Listed;
using BpsFireStore = Bps.BpsBase.Entities.Models.SH.Firestore;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Entities;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Firebase.Auth;
using Newtonsoft.Json.Converters;
using Svg;
using Firebase.Storage;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json.Serialization;

namespace BPS.Google.Firestore
{
	public class Firestore
	{
		public static Guid? CompanyGuid { get; set; }
		public static List<BpsFireStore.User> users = new List<BpsFireStore.User>();

		private static string _project;
		//private static string _project2;
		private static FirestoreDb _db;
		//private static FirestoreDb _db2;

		private static IStkartService _stkartService;
		private static IUragacService _uragacService;
		private static IShsrvsService _shsrvsService;
		private static IGnkullService _gnkullService;
		private static IGnyetkService _gnyetkService;
		private static IGndpzmService _gndpzmService;
		private static IStdepoService _stdepoService;
		private static IGntipiService _gntipiService;
		private static IGnthrkService _gnthrkService;
		private static IIkpersService _ikpersService;
		private static IStnameService _stnameService;
		private static ISirketService _sirketService;
		private static ISthrktService _sthrktService;
		private static ISpfbasService _spfbasService;
		private static ISpfharService _spfharService;
		private static IStkfytService _stkfytService;
		private static ICrcariService _crcariService;
		private static ICrytklService _crytklService;
		private static ISpfharDal _spfharDal;
		private static IStkartDal _stkartDal;
		private static IXXService _xxService;
		private static IApiService _apiService;

		private static FirestoreChangeListener _workOrderListener;
		private static FirestoreChangeListener _requestListener;

		private static string jsonPath;

		private bool Successful { get; set; }
		private string Response { get; set; }
		private Exception Error { get; set; }
		public static string ErrorLogPath { get; set; }
		private static bool Initialized { get; set; }

		public static async void Initialize()
		{
			if (Initialized) return;

			ErrorLogPath = AppDomain.CurrentDomain.BaseDirectory + "error_log.txt";

			using (StreamWriter sw = File.AppendText(ErrorLogPath))
			{
				sw.WriteLine("0");
			}

			try
			{
				_sirketService = InstanceFactory.GetInstance<ISirketService>();
				_stkartService = InstanceFactory.GetInstance<IStkartService>();
				_uragacService = InstanceFactory.GetInstance<IUragacService>();
				_shsrvsService = InstanceFactory.GetInstance<IShsrvsService>();
				_gnkullService = InstanceFactory.GetInstance<IGnkullService>();
				_gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
				_gndpzmService = InstanceFactory.GetInstance<IGndpzmService>();
				_stdepoService = InstanceFactory.GetInstance<IStdepoService>();
				_gntipiService = InstanceFactory.GetInstance<IGntipiService>();
				_gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
				_ikpersService = InstanceFactory.GetInstance<IIkpersService>();
				_stnameService = InstanceFactory.GetInstance<IStnameService>();
				_sthrktService = InstanceFactory.GetInstance<ISthrktService>();
				_spfbasService = InstanceFactory.GetInstance<ISpfbasService>();
				_spfharService = InstanceFactory.GetInstance<ISpfharService>();
				_stkfytService = InstanceFactory.GetInstance<IStkfytService>();
				_crcariService = InstanceFactory.GetInstance<ICrcariService>();
				_crytklService = InstanceFactory.GetInstance<ICrytklService>();
				_spfharDal = InstanceFactory.GetInstance<ISpfharDal>();
				_apiService = InstanceFactory.GetInstance<IApiService>();
				_stkartDal = InstanceFactory.GetInstance<IStkartDal>();
				_xxService = InstanceFactory.GetInstance<IXXService>();

				CompanyGuid = _sirketService.GetResmiSirketList().Items[0].SRGUID; //1'den fazla şirket olduğu durumda burası değiştirilecek.
				if (CompanyGuid == null)
				{
					MessageBox.Show("CompanyGuid bulunamadı!");
					return;
				}

				using (StreamWriter sw = File.AppendText(ErrorLogPath))
				{
					sw.WriteLine("1");
				}

				if (Param.ADAPTATION == Adaptation.Bala)
				{
					jsonPath = AppDomain.CurrentDomain.BaseDirectory + "bala.json";
				}
				else if (Param.ADAPTATION == Adaptation.Aracikan)
				{
					jsonPath = AppDomain.CurrentDomain.BaseDirectory + "aracikan.json";
				}
				else
				{
					jsonPath = AppDomain.CurrentDomain.BaseDirectory + "efi.json";
				}

				using (StreamWriter sw = File.AppendText(ErrorLogPath))
				{
					sw.WriteLine("2");
				}

				FirebaseApp.Create(new AppOptions
				{
					Credential = GoogleCredential.FromFile(jsonPath)
				});

				Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", jsonPath);

				using (StreamReader r = new StreamReader(jsonPath))
				{
					string json = r.ReadToEnd();
					dynamic array = JsonConvert.DeserializeObject(json);
					foreach (var item in array)
					{
						if (item.Name == "project_id")
						{
							_project = item.Value.ToString();
							break;
						}
					}
				}

				//using (StreamReader r = new StreamReader(jsonPath2))
				//{
				//    string json = r.ReadToEnd();
				//    dynamic array = JsonConvert.DeserializeObject(json);
				//    foreach (var item in array)
				//    {
				//        if (item.Name == "project_id")
				//        {
				//            _project2 = item.Value.ToString();
				//            break;
				//        }
				//    }
				//}

				//FirestoreDbBuilder crmFsBuilder = new FirestoreDbBuilder();
				//crmFsBuilder.ProjectId = _project;
				//crmFsBuilder.CredentialsPath = AppDomain.CurrentDomain.BaseDirectory + "bala.json";
				//_db = crmFsBuilder.Build();

				//FirestoreDbBuilder saFsBuilder = new FirestoreDbBuilder();
				//saFsBuilder.ProjectId = _project2;
				//saFsBuilder.CredentialsPath = AppDomain.CurrentDomain.BaseDirectory + "efi-service.json";
				//_db2 = saFsBuilder.Build();

				_db = FirestoreDb.Create(_project);
				//_db2 = FirestoreDb.Create(_project2);

				users = await GetDocumentsFilterBy<BpsFireStore.User>("users", "company", CompanyGuid.ToString());

				Initialized = true;
				//CopyCollectionToDifferentProject("workOrders");
			}
			catch (Exception ex)
			{
				using (StreamWriter sw = File.AppendText(ErrorLogPath))
				{
					sw.WriteLine(ex.Message);
				}

				MessageBox.Show(ex.ToString());
			}
		}

		static Global CreateGlobal(GNKULL gnkull = null)
		{
			return new Global
			{
				SirketGuid = CompanyGuid,
				UserKod = gnkull == null ? "admin" : gnkull.KULKOD,
				UserId = gnkull == null ? 1 : gnkull.Id,
				PersId = gnkull == null ? 0 : gnkull.PERSID,
				FirstName = gnkull == null ? "İlkay" : gnkull.GNNAME,
				LastName = gnkull == null ? "Gümüş" : gnkull.GNSNAM,
				Role = gnkull == null ? "ADMIN" : gnkull.ROLEKD,
				KaynakKod = "1",
				DilKod = "tr-TR",
				Email = gnkull == null ? "" : gnkull.GNMAIL,
				SirketId = 1,
				SirketType = true
			};
		}

		//public static async void CopyCollectionToDifferentProject(string collection)
		//{
		//    //Query query = _db.Collection(collection).WhereEqualTo("status", status);
		//    Query query = _db.Collection(collection);
		//    QuerySnapshot snapshot = await query.GetSnapshotAsync();

		//    foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
		//    {
		//        var dict = documentSnapshot.ToDictionary();
		//        DocumentReference docRef = _db2.Collection(collection).Document(documentSnapshot.Id);
		//        await docRef.CreateAsync(dict);
		//    }
		//}

		public static async Task ChangeUserPasswordAsync(string userId, string newPassword = "test1234")
		{
			try
			{
				UserRecord userRecord = await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.GetUserAsync(userId);

				UserRecordArgs args = new UserRecordArgs()
				{
					Uid = userRecord.Uid,
					Password = newPassword
				};

				await FirebaseAdmin.Auth.FirebaseAuth.DefaultInstance.UpdateUserAsync(args);

				Console.WriteLine("Password updated successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error updating password: {ex.Message}");
			}
		}

		public static async Task<List<string>> GetUserTokenById(int? id) //BURAYA BAKILACAK!!! EFI VE BALA İÇİN AYNI YERİ KULLANIYOR. BALA'DA FARKLI OLACAK. CompanyGuid orada henüz yok
		{
			List<string> tokenList = new List<string>();
			var colRef = _db.Collection("users");
			Query query = null;
			if (id != null) query = colRef.WhereEqualTo("users", CompanyGuid.ToString()).WhereEqualTo("persId", id);
			else query = colRef.WhereEqualTo("users", CompanyGuid.ToString());
			QuerySnapshot snapshot = await query.GetSnapshotAsync();

			if (snapshot.Documents.Count > 0)
			{
				foreach (var doc in snapshot.Documents)
				{
					try
					{
						string token = doc.ToDictionary()["token"].ToString();
						if (token != "") tokenList.Add(token);
					}
					catch (Exception e)
					{
						Console.WriteLine(e);
					}
				}
			}

			return tokenList;
		}

		public async Task<IFirestoreEntity> GetDocument<T>(string collection, string id) where T : IFirestoreEntity, new()
		{
			try
			{
				DocumentReference docRef = _db.Collection(collection).Document(id);
				DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

				if (snapshot.Exists)
				{
					var map = snapshot.ToDictionary();
					IFirestoreEntity entity = new T().Deserialize(map);
					entity.DocumentId = snapshot.Id;
					return entity;
				}
			}
			catch (Exception ex)
			{

			}

			return null;
		}

		public async Task<List<IFirestoreEntity>> GetAllDocuments<T>(string collection) where T : IFirestoreEntity, new()
		{
			List<IFirestoreEntity> entities = new List<IFirestoreEntity>();

			try
			{
				Query query = _db.Collection(collection);
				QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

				foreach (DocumentSnapshot snapshot in querySnapshot.Documents)
				{
					var map = snapshot.ToDictionary();
					IFirestoreEntity entity = new T().Deserialize(map);
					entity.DocumentId = snapshot.Id;

					entities.Add(entity);
				}
			}
			catch (Exception ex)
			{
				return new List<IFirestoreEntity>();
			}

			return entities;
		}

		public static async void SetField(string collection, string documentId, Dictionary<string, object> data)
		{
			DocumentReference docRef = _db.Collection(collection).Document(documentId);
			await docRef.SetAsync(data, SetOptions.MergeAll);
		}

		public static async Task<bool> SetEntity(string collection, BaseEntity data, List<Dictionary<string, object>> extraData = null, string writeStrstp = "", Global global = null)
		{
			try
			{
				string documentId = "";
				if (data != null) documentId = data.Id.ToString();

				var json = JsonConvert.SerializeObject(data);
				var dataMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

				var options = SetOptions.Overwrite;

				if (dataMap.ContainsKey("STRSTP")) //Servis uygulaması İş emri start stop zamanı
				{
					//STRSTP alanını firestore'a kaydetmek için aç.
					if (writeStrstp != "")
					{
						var strstpString = dataMap["STRSTP"].ToString();
						var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(strstpString);
						var dictList = new List<Dictionary<string, object>>();
						foreach (var obj in list) dictList.Add(obj);

						dictList.Add(new Dictionary<string, object>
						{
							{ "ACCODE", 1 },
							{ "ACTION", "BİTİR" },
							{ "TMSTMP", DateTime.SpecifyKind(DateTime.Now.AddHours(-3), DateTimeKind.Utc) }
                            //{ "TMSTMP", Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)) }
                        });

						dataMap["STRSTP"] = dictList;
					}
					else
					{
						dataMap.Remove("STRSTP");
						options = SetOptions.MergeAll;
					}
				}

				if (extraData != null && extraData.Count > 0)
				{
					foreach (Dictionary<string, object> dict in extraData)
					{
						foreach (var keyValPair in dict)
							dataMap.Add(keyValPair.Key, keyValPair.Value);
					}
				}

				var dateList = dataMap.Where(d => d.Value is DateTime).ToList();
				foreach (KeyValuePair<string, object> kvp in dateList)
				{
					dataMap[kvp.Key] = DateTime.SpecifyKind((DateTime)kvp.Value, DateTimeKind.Utc); ;
				}

				DocumentReference docRef;
				if (string.IsNullOrEmpty(documentId)) docRef = _db.Collection(collection).Document();
				else docRef = _db.Collection(collection).Document(documentId);

				var h = await docRef.SetAsync(dataMap, options);

				if (writeStrstp != "")
				{
					string strstp = "";
					try
					{
						var settings = new JsonSerializerSettings
						{
							Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
							Formatting = Formatting.None
						};

						strstp = JsonConvert.SerializeObject(dataMap["STRSTP"], settings);
						dataMap.Remove("STRSTP");

						json = JsonConvert.SerializeObject(dataMap);

						SHSRVS workOrder = JsonConvert.DeserializeObject<SHSRVS>(json);
						workOrder.STRSTP = strstp;

						var response = _shsrvsService.Ncch_Update_Log(workOrder, workOrder, global);
					}
					catch (Exception e)
					{

					}
				}

				return true;
			}
			catch (Exception ex)
			{

			}

			return false;
		}

		public static async Task<Dictionary<string, object>> GetDocument(string collection, int id)
		{
			var docRef = _db.Collection(collection).Document(id.ToString());
			var snapshop = await docRef.GetSnapshotAsync();
			Dictionary<string, object> dict = null;
			if (snapshop.Exists) dict = snapshop.ToDictionary();

			return dict;
		}

		public static async Task<List<T>> GetDocuments<T>(string collection)
		{
			List<T> documents = new List<T>();

			try
			{
				Query query = _db.Collection(collection);
				QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

				foreach (DocumentSnapshot snapshot in querySnapshot.Documents)
				{
					var map = snapshot.ToDictionary();
					map.Add("documentId", snapshot.Id);
					var json = JsonConvert.SerializeObject(ToDateTime(map));
					var doc = JsonConvert.DeserializeObject<T>(json);
					documents.Add(doc);
				}
			}
			catch (Exception ex)
			{
				return null;
			}


			return documents;
		}

		public static async Task<List<T>> GetDocumentsFilterBy<T>(string collection, string field, object value)
		{
			List<T> documents = new List<T>();

			try
			{
				Query query = _db.Collection(collection).WhereEqualTo(field, value);
				QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

				foreach (DocumentSnapshot snapshot in querySnapshot.Documents)
				{
					var map = snapshot.ToDictionary();
					map.Add("documentId", snapshot.Id);
					var json = JsonConvert.SerializeObject(ToDateTime(map));
					var doc = JsonConvert.DeserializeObject<T>(json);
					documents.Add(doc);
				}
			}
			catch (Exception ex)
			{
				return null;
			}


			return documents;
		}

		private static Dictionary<string, object> ToDateTime(Dictionary<string, object> dictionary)
		{
			var dateList = dictionary.Where(d => d.Value is Timestamp).ToList();
			foreach (KeyValuePair<string, object> kvp in dateList)
			{
				Timestamp ts = (Timestamp)kvp.Value;
				dictionary[kvp.Key] = ts.ToDateTime();
			}

			return dictionary;
		}

		public static async Task ListenWorkOrder()
		{
			if (_workOrderListener != null && (_workOrderListener.ListenerTask.Status == TaskStatus.Running)) return;

			try
			{
				Global global = CreateGlobal();
				GNKULL kull = null;

				CollectionReference colRef = _db.Collection("workOrders");
				Query query = colRef.WhereEqualTo("SRSYNC", false);

				_workOrderListener = query.Listen(async snapshot =>
				{
					foreach (DocumentChange change in snapshot.Changes)
					{
						if (change.ChangeType.ToString() != "Added") continue;

						var settings = new JsonSerializerSettings
						{
							Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
							Formatting = Formatting.None
						};

						Dictionary<string, object> dict = change.Document.ToDictionary();
						TimestampToDateTime(dict);

						string strstp = "";
						try
						{
							strstp = JsonConvert.SerializeObject(dict["STRSTP"], settings);
							dict.Remove("STRSTP");
						}
						catch (Exception e)
						{

						}

						var json = JsonConvert.SerializeObject(dict);

						SHSRVS workOrder = JsonConvert.DeserializeObject<SHSRVS>(json);
						workOrder.STRSTP = strstp;
						List<STHRKT> sthrktList = new List<STHRKT>();

						if (global.PersId != workOrder.SRPRID)
						{
							kull = _gnkullService.Ncch_GetByPersId_NLog(workOrder.SRPRID.Value, global, false).Nesne;
							if (kull != null) global = CreateGlobal(kull);
						}

						bool success = true;
						if (!string.IsNullOrEmpty(workOrder.KULPRC))
						{
							var kulprcList = JsonConvert.DeserializeObject<List<TabletStokHareket>>(workOrder.KULPRC);

							var hareketResponse = new StandardResponse();
							var model = new StokHareketModel();
							model.Baslik = new STHBAS();

							model.Baslik.BELTRH = DateTime.Now;
							model.Baslik.CRKODU = workOrder.CRKODU;
							model.Baslik.EVRAKN = "MOBİL";
							model.Baslik.STHRTP = 1;
							model.Baslik.STFTNO = 6;
							model.Baslik.CKDEPO = kulprcList[0].DPKODU;
							model.Baslik.GNACIK = "Servis modülü depo çıkışı";
							model.Kalemler = new List<STHRKT>();
							model.HedefWmAdresList = new List<string>();
							model.KaynakWmAdresList = new List<string>();

							int satirNo = 1;
							foreach (TabletStokHareket kulprc in kulprcList)
							{
								STHRKT sthrkt = new STHRKT
								{
									CRKODU = workOrder.CRKODU,
									SATIRN = satirNo,
									STKODU = kulprc.STKODU,
									STKNAM = kulprc.STKNAM,
									GRMKTR = kulprc.MIKTAR,
									GNMKTR = kulprc.MIKTAR,
									GROLBR = kulprc.OLCUKD,
									OLCUKD = kulprc.OLCUKD,
									CKDEPO = kulprc.DPKODU,
									GNACIK = "Servis modülü depo çıkışı",
									USTBLG = workOrder.BELGEN,
								};

								model.Kalemler.Add(sthrkt);
								sthrktList.Add(sthrkt);

								satirNo++;
							}

							hareketResponse = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);

							if (hareketResponse.Status != ResponseStatusEnum.OK)
							{
								success = false;
							}
						}

						if (success)
						{
							workOrder.SRSYNC = true;
							workOrder.DTARIH = DateTime.Now;
							if (kull != null) workOrder.DEKULL = kull.KULKOD;

							workOrder.CRUNVN = workOrder.CRUNVN.Replace("\"", "").Replace("\\", "").Replace("'", "");

							string fileName = workOrder.BELGEN + " - " + workOrder.CRUNVN + ".pdf";
							Dictionary<string, object> dic = new Dictionary<string, object>();
							dic.Add("SRSYNC", true);

							if (workOrder.SRVDRM == "03")
							{
								string filePath = await CreateServisRapor(workOrder, sthrktList, global);
								using (var fs = new FileStream(filePath, FileMode.Open))
								{
									string downloadUrl = await UploadServisRapor(fileName, fs);
									workOrder.PDFURL = downloadUrl;
									dic.Add("PDFURL", downloadUrl);
								}
							}

							var response = new StandardResponse<SHSRVS>();
							response = _shsrvsService.Ncch_UpdateFromApi_Log(workOrder, workOrder, global);

							if (response.Status == ResponseStatusEnum.OK)
							{
								await change.Document.Reference.UpdateAsync(dic);
							}
						}
					}
				});
			}
			catch (Exception)
			{
				await StopListening(_workOrderListener);
			}
		}

		public static async Task<string> CreateServisRapor(SHSRVS workOrder, List<STHRKT> sthrktList, Global global, string fileExtension = "pdf")
		{
			var ikpers = _ikpersService.Ncch_GetById_NLog(workOrder.SRPRID.Value, global, false)
										.Nesne;
			var personelAdi = ikpers.GNNAME + " " + ikpers.GNSNAM;

			GNTIPI makineKategoriTip = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MKNKTG", false).Nesne;
			var makineKategoriList = _gntipiService.Ncch_GetListByUstTipKod_NLog(global, makineKategoriTip.TIPKOD, false).Items;

			var teknads = new List<string>() { "SRTRKD", "GRDRKD", "MKDRKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, yetkiKontrol: false);
			var servisTuruList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").ToList();
			var garantiDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").ToList();
			var makineDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").ToList();

			var kategori = makineKategoriList.First(m => m.TIPKOD == workOrder.URKTGR);

			var modelList = _gnthrkService.Cch_GetListByTeknad(global, kategori.TEKNAD, false).Items;
			var model = "";
			var mdl = modelList.FirstOrDefault(m => m.HARKOD == workOrder.URMODL);
			if (mdl != null) model = mdl.TANIMI;

			var servisTuru = servisTuruList.First(s => s.HARKOD == workOrder.SRVTUR).TANIMI;
			var garantiDurumu = garantiDurumuList.First(s => s.HARKOD == workOrder.GRNDRM).TANIMI;
			var makineDurumu = makineDurumuList.First(s => s.HARKOD == workOrder.MKNDRM).TANIMI;
			var kurulumTarihi = "";
			if (workOrder.MKKRTR != null) kurulumTarihi = workOrder.MKKRTR.Value.ToShortDateString();

			int toplamSure = 0;

			if (!string.IsNullOrEmpty(workOrder.STRSTP))
			{
				DataTable table = new DataTable();
				table.Columns.Add("ACCODE", typeof(int));
				table.Columns.Add("ACTION", typeof(string));
				table.Columns.Add("TMSTMP", typeof(DateTime));
				table.Columns.Add("TOPDAK", typeof(int));

				var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(workOrder.STRSTP);

				foreach (object o in data)
				{
					var strstp = o as Dictionary<string, object>;
					var str = strstp["TMSTMP"].ToString();
					str = str.Replace("Timestamp: ", "").Trim();
					int dif = str.Length - 19;
					if (dif > 0) str = str.Substring(0, str.Length - dif);

					DateTime dateTime = DateTime.ParseExact(str, "yyyy-MM-ddTHH:mm:ss", null);

					DataRow row = table.NewRow();
					int kod = Convert.ToInt32(strstp["ACCODE"]);
					row["ACCODE"] = kod;
					row["ACTION"] = strstp["ACTION"].ToString();
					row["TMSTMP"] = dateTime;

					if (kod == 1)
					{
						DataRow rw = table.Rows[table.Rows.Count - 1];
						if (Convert.ToInt32(rw["ACCODE"]) == 0)
						{
							DateTime previousTime = DateTime.Parse(rw["TMSTMP"].ToString());
							TimeSpan ts = dateTime - previousTime;
							int minDifference = (int)ts.TotalMinutes;
							rw["TOPDAK"] = minDifference;
							toplamSure += minDifference;
						}
					}
					table.Rows.Add(row);
				}
			}

			var toplamSureStr = toplamSure.ToString() + " dakika --> " + string.Format("{0:0} saat {1:00} dakika", toplamSure / 60, toplamSure % 60);

			Image personelImza, musteriImza;



			personelImza = null;
			if (!string.IsNullOrEmpty(workOrder.PRIMZA))
			{
				if (workOrder.PRIMZA.StartsWith("<?xml"))
				{
					var byteArray = Encoding.ASCII.GetBytes(workOrder.PRIMZA);
					using (var stream = new MemoryStream(byteArray))
					{
						var svgDocument = SvgDocument.Open<SvgDocument>(stream);
						personelImza = svgDocument.Draw();
					}
				}
				else
				{
					byte[] bytes = Convert.FromBase64String(workOrder.PRIMZA);
					using (MemoryStream ms = new MemoryStream(bytes))
					{
						personelImza = Image.FromStream(ms);
					}
				}
			}

			musteriImza = null;
			if (!string.IsNullOrEmpty(workOrder.MSIMZA))
			{
				if (workOrder.MSIMZA.StartsWith("<?xml"))
				{
					var byteArray = Encoding.ASCII.GetBytes(workOrder.MSIMZA);
					using (var stream = new MemoryStream(byteArray))
					{
						var svgDocument = SvgDocument.Open<SvgDocument>(stream);
						musteriImza = svgDocument.Draw();
					}
				}
				else
				{
					byte[] bytes = Convert.FromBase64String(workOrder.MSIMZA);
					using (MemoryStream ms = new MemoryStream(bytes))
					{
						musteriImza = Image.FromStream(ms);
					}
				}
			}

			string docLang = "tr-TR";

			ServisRapor servisRapor = new ServisRapor();
			servisRapor.cellBelgeNo.Text = workOrder.BELGEN;

			string musteriBilgileri = (docLang == "tr-TR" ? "" : "To: ") + workOrder.CRUNVN + "<br><br>" +
									  (docLang == "tr-TR" ? "Yetkili Kişi: " : "Contact Person: ") +
									  (workOrder.CRUNVN ?? "") + "<br>" +
									  (docLang == "tr-TR" ? "İletişim No: " : "Contact Number: ") + (workOrder.CRTLFN ?? "") + "<br>" +
									  //(docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + (crytkl != null ? crytkl.GNMAIL : "") + "<br>" +
									  (docLang == "tr-TR" ? "Adres: " : "Address: ") + (workOrder.CRADRS ?? "");

			servisRapor.richTextMusteri.Html = "<p style=\"font-family: Noir Pro; font-size: 9.71px\">" + musteriBilgileri + "</p>";

			string servisInfo = (docLang == "tr-TR" ? "Belge Tarihi: " : "Offer Date: ") +
								workOrder.BELTRH.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Talep Tarihi: " : "Demand Date: ") +
								workOrder.SRTLTR.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Başlangıç Tarihi: " : "Service Start Date: ") +
								workOrder.SRBSTR.Value.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Bitiş Tarihi: " : "Service End Date: ") +
								workOrder.SRBTTR.Value.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Toplam Çalışma Süresi: " : "Service End Date: ") +
								toplamSureStr + "<br><br>" +
								(docLang == "tr-TR" ? "Talebi Açan: " : "Contact Person at Bala: ") + workOrder.TLPACN +
								"<br>" +
								(docLang == "tr-TR" ? "Servis Türü: " : "Contact Person Phone: ") + servisTuru +
								"<br>" +
								(docLang == "tr-TR" ? "Garanti Durumu: " : "E-mail: ") + garantiDurumu + "<br>" +
								(docLang == "tr-TR" ? "Makina Durumu: " : "") + makineDurumu + "<br><br>" +
								(docLang == "tr-TR" ? "Kategori: " : "") + kategori.TIPADI + "<br>" +
								(docLang == "tr-TR" ? "Model: " : "") + model + "<br>" +
								(docLang == "tr-TR" ? "Seri No: " : "") + workOrder.URSERI + "<br>" +
								(docLang == "tr-TR" ? "Kur. Tarihi: " : "") + kurulumTarihi + "<br>";

			servisRapor.richTextServisInfo.Html = "<p style=\"font-family: Noir Pro; font-size: 12.53px\">" + servisInfo + "</p>";

			servisRapor.cellProblemTanimi.Text = workOrder.PRBTNM;
			servisRapor.cellArizaTespiti.Text = workOrder.PRBTSP;
			servisRapor.cellAksiyon.Text = workOrder.AKSYON;

			servisRapor.bindingSource1.DataSource = sthrktList;
			if (sthrktList.Count == 0)
			{
				servisRapor.lblDegisenParcalar.Visible = false;
				servisRapor.lblUrunKodu.Visible = false;
				servisRapor.lblUrunAdi.Visible = false;
				servisRapor.lblMiktar.Visible = false;
				servisRapor.lblBirim.Visible = false;

				for (int i = 1; i <= 24; i++) servisRapor.Detail.Controls["xrLine" + i.ToString()].Visible = false;
			}

			servisRapor.picturePersonel.Image = personelImza;
			servisRapor.pictureMusteri.Image = musteriImza;
			servisRapor.labelPersonelAdi.Text = personelAdi;
			servisRapor.labelMusteriAdi.Text = workOrder.CRYTKL;

			string filePath = "";
			string folder = AppDomain.CurrentDomain.BaseDirectory + "Servis Raporları\\";

			try
			{
				Directory.CreateDirectory(folder);

				if (fileExtension == "pdf")
				{
					filePath = folder + workOrder.BELGEN + " - " + workOrder.CRUNVN + ".pdf";
					servisRapor.ExportToPdf(filePath);
				}
				else if (fileExtension == "docx")
				{
					filePath = folder + workOrder.BELGEN + " - " + workOrder.CRUNVN + ".docx";
					servisRapor.ExportToDocx(filePath);
				}
			}
			catch (Exception e)
			{
				filePath = "";
				Console.WriteLine(e);
			}

			return filePath;
		}

		public static async Task<string> CreateServisRapor2(SHSRVS shsrvs, List<STHRKT> sthrktList, Global global, string fileExtension = "pdf")
		{
			var ikpers = _ikpersService.Ncch_GetById_NLog(shsrvs.SRPRID.Value, global, false)
										.Nesne;
			var personelAdi = ikpers.GNNAME + " " + ikpers.GNSNAM;


			var teknads = new List<string>() { "SRTRKD", "GRDRKD", "MKDRKD", "STANKD", "STALKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, yetkiKontrol: false);
			var servisTuruList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").ToList();
			var garantiDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").ToList();
			var makineDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").ToList();
			var makineKategoriList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").Where(g => g.EXTRA1 == "SSHMBL").ToList();
			var makineModelList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").Where(g => g.EXTRA1 == "SSHMBL").ToList();

			var kategori = makineKategoriList.First(k => k.HARKOD == shsrvs.URKTGR);

			var model = "";
			var mdl = makineModelList.FirstOrDefault(m => m.HARKOD == shsrvs.URMODL);
			if (mdl != null) model = mdl.TANIMI;

			var servisTuru = servisTuruList.First(s => s.HARKOD == shsrvs.SRVTUR).TANIMI;
			var garantiDurumu = garantiDurumuList.First(s => s.HARKOD == shsrvs.GRNDRM).TANIMI;
			var makineDurumu = makineDurumuList.First(s => s.HARKOD == shsrvs.MKNDRM).TANIMI;
			var kurulumTarihi = "";
			if (shsrvs.MKKRTR != null) kurulumTarihi = shsrvs.MKKRTR.Value.ToShortDateString();

			int toplamSure = 0;

			if (!string.IsNullOrEmpty(shsrvs.STRSTP))
			{
				DataTable table = new DataTable();
				table.Columns.Add("ACCODE", typeof(int));
				table.Columns.Add("ACTION", typeof(string));
				table.Columns.Add("TMSTMP", typeof(DateTime));
				table.Columns.Add("TOPDAK", typeof(int));

				var data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(shsrvs.STRSTP);

				foreach (object o in data)
				{
					var strstp = o as Dictionary<string, object>;
					var str = strstp["TMSTMP"].ToString();
					str = str.Replace("Timestamp: ", "").Trim();
					int dif = str.Length - 19;
					if (dif > 0) str = str.Substring(0, str.Length - dif);

					DateTime dateTime = DateTime.Parse(str);

					DataRow row = table.NewRow();
					int kod = Convert.ToInt32(strstp["ACCODE"]);
					row["ACCODE"] = kod;
					row["ACTION"] = strstp["ACTION"].ToString();
					row["TMSTMP"] = dateTime;

					if (kod == 1)
					{
						DataRow rw = table.Rows[table.Rows.Count - 1];
						if (Convert.ToInt32(rw["ACCODE"]) == 0)
						{
							DateTime previousTime = DateTime.Parse(rw["TMSTMP"].ToString());
							TimeSpan ts = dateTime - previousTime;
							int minDifference = (int)ts.TotalMinutes;
							rw["TOPDAK"] = minDifference;
							toplamSure += minDifference;
						}
					}
					table.Rows.Add(row);
				}
			}

			var toplamSureStr = toplamSure.ToString() + " dakika --> " + string.Format("{0:0} saat {1:00} dakika", toplamSure / 60, toplamSure % 60);

			Image personelImza, musteriImza;

			personelImza = null;
			if (!string.IsNullOrEmpty(shsrvs.PRIMZA))
			{
				if (shsrvs.PRIMZA.StartsWith("<?xml"))
				{
					var byteArray = Encoding.ASCII.GetBytes(shsrvs.PRIMZA);
					using (var stream = new MemoryStream(byteArray))
					{
						var svgDocument = SvgDocument.Open<SvgDocument>(stream);
						personelImza = svgDocument.Draw();
					}
				}
				else
				{
					byte[] bytes = Convert.FromBase64String(shsrvs.PRIMZA);
					using (MemoryStream ms = new MemoryStream(bytes))
					{
						personelImza = Image.FromStream(ms);
					}
				}
			}

			musteriImza = null;
			if (!string.IsNullOrEmpty(shsrvs.MSIMZA))
			{
				if (shsrvs.MSIMZA.StartsWith("<?xml"))
				{
					var byteArray = Encoding.ASCII.GetBytes(shsrvs.MSIMZA);
					using (var stream = new MemoryStream(byteArray))
					{
						var svgDocument = SvgDocument.Open<SvgDocument>(stream);
						musteriImza = svgDocument.Draw();
					}
				}
				else
				{
					byte[] bytes = Convert.FromBase64String(shsrvs.MSIMZA);
					using (MemoryStream ms = new MemoryStream(bytes))
					{
						musteriImza = Image.FromStream(ms);
					}
				}
			}

			string docLang = "tr-TR";

			ServisRapor2 servisRapor = new ServisRapor2();
			servisRapor.cellBelgeNo.Text = shsrvs.BELGEN;

			string musteriBilgileri = (docLang == "tr-TR" ? "" : "To: ") + shsrvs.CRUNVN + "<br><br>" +
									  (docLang == "tr-TR" ? "Yetkili Kişi: " : "Contact Person: ") +
									  (shsrvs.CRUNVN ?? "") + "<br>" +
									  (docLang == "tr-TR" ? "İletişim No: " : "Contact Number: ") + (shsrvs.CRTLFN ?? "") + "<br>" +
									  //(docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + (crytkl != null ? crytkl.GNMAIL : "") + "<br>" +
									  (docLang == "tr-TR" ? "Adres: " : "Address: ") + (shsrvs.CRADRS ?? "");

			servisRapor.richTextMusteri.Html = "<p style=\"font-family: Noir Pro; font-size: 9.71px\">" + musteriBilgileri + "</p>";

			string servisInfo = (docLang == "tr-TR" ? "Belge Tarihi: " : "Offer Date: ") +
								shsrvs.BELTRH.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Talep Tarihi: " : "Demand Date: ") +
								shsrvs.SRTLTR.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Başlangıç Tarihi: " : "Service Start Date: ") +
								shsrvs.SRBSTR.Value.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Servis Bitiş Tarihi: " : "Service End Date: ") +
								shsrvs.SRBTTR.Value.ToShortDateString() + "<br>" +
								(docLang == "tr-TR" ? "Toplam Çalışma Süresi: " : "Service End Date: ") +
								toplamSureStr + "<br><br>" +
								(docLang == "tr-TR" ? "Talebi Açan: " : "Contact Person: ") + shsrvs.TLPACN +
								"<br>" +
								(docLang == "tr-TR" ? "Servis Türü: " : "Contact Person Phone: ") + servisTuru +
								"<br>" +
								(docLang == "tr-TR" ? "Garanti Durumu: " : "E-mail: ") + garantiDurumu + "<br>" +
								(docLang == "tr-TR" ? "Makina Durumu: " : "") + makineDurumu + "<br><br>" +
								(docLang == "tr-TR" ? "Kategori: " : "") + kategori.TANIMI + "<br>" +
								(docLang == "tr-TR" ? "Model: " : "") + model + "<br>" +
								(docLang == "tr-TR" ? "Seri No: " : "") + shsrvs.URSERI + "<br>" +
								(docLang == "tr-TR" ? "Kur. Tarihi: " : "") + kurulumTarihi + "<br>";

			servisRapor.richTextServisInfo.Html = "<p style=\"font-family: Noir Pro; font-size: 12.53px\">" + servisInfo + "</p>";

			servisRapor.cellProblemTanimi.Text = shsrvs.PRBTNM;
			servisRapor.cellArizaTespiti.Text = shsrvs.PRBTSP;
			servisRapor.cellAksiyon.Text = shsrvs.AKSYON;

			servisRapor.bindingSource1.DataSource = sthrktList;
			if (sthrktList.Count == 0)
			{
				servisRapor.lblDegisenParcalar.Visible = false;
				servisRapor.lblUrunKodu.Visible = false;
				servisRapor.lblUrunAdi.Visible = false;
				servisRapor.lblMiktar.Visible = false;
				servisRapor.lblBirim.Visible = false;
				servisRapor.lblBirimFiyat.Visible = false;
				servisRapor.lblToplamFiyat.Visible = false;
				servisRapor.lblDoviz.Visible = false;

				for (int i = 1; i <= 24; i++) servisRapor.Detail.Controls["xrLine" + i.ToString()].Visible = false;

				servisRapor.lblAraToplam.Visible = false;
				servisRapor.lblAraToplam1.Visible = false;
				servisRapor.lblAraToplam2.Visible = false;

				servisRapor.lblKdv.Visible = false;
				servisRapor.lblKdv1.Visible = false;
				servisRapor.lblKdv2.Visible = false;

				servisRapor.lblGenelToplam.Visible = false;
				servisRapor.lblGenelToplam1.Visible = false;
				servisRapor.lblGenelToplam2.Visible = false;
			}
			else
			{
				decimal toplam = 0;
				foreach (STHRKT sthrkt in sthrktList)
				{
					decimal tutar = sthrkt.GNTUTR.HasValue ? sthrkt.GNTUTR.Value : 0;
					toplam += tutar;
				}
				double kdv = ((double)toplam * 0.2);

				servisRapor.lblAraToplam.Text = toplam.ToString("n2");
				servisRapor.lblKdv.Text = kdv.ToString("n2");
				servisRapor.lblGenelToplam.Text = (toplam + (decimal)kdv).ToString("n2");
			}

			servisRapor.picturePersonel.Image = personelImza;
			servisRapor.pictureMusteri.Image = musteriImza;
			servisRapor.labelPersonelAdi.Text = personelAdi;
			servisRapor.labelMusteriAdi.Text = shsrvs.CRYTKL;

			string filePath = "";
			string folder = AppDomain.CurrentDomain.BaseDirectory + "Servis Raporları\\";

			try
			{
				Directory.CreateDirectory(folder);

				if (fileExtension == "pdf")
				{
					filePath = folder + shsrvs.BELGEN + " - " + shsrvs.CRUNVN + ".pdf";
					servisRapor.ExportToPdf(filePath);
				}
				else if (fileExtension == "docx")
				{
					filePath = folder + shsrvs.BELGEN + " - " + shsrvs.CRUNVN + ".docx";
					servisRapor.ExportToDocx(filePath);
				}
			}
			catch (Exception e)
			{
				filePath = "";
				Console.WriteLine(e);
			}

			return filePath;
		}

		private static async Task<string> UploadServisRapor(string fileName, FileStream fs)
		{
			string apiKey = "";
			string user = "";
			string pass = "";
			string storage = "";

			if (Param.ADAPTATION == Adaptation.Bala)
			{
				apiKey = "AIzaSyAppvm3CgY3dVBEBa-S7qnVX-LBI0x8UHw";
				user = "ilkaygumus@gmail.com";
				pass = "123456";
				storage = "balaservice-3067b.appspot.com";
			}
			else
			{
				apiKey = "AIzaSyAgH2wProrkIshHKz7jg6JfGfDvd0EIc6Q";
				user = "erdalkarabulut@gmail.com";
				pass = "123456";
				storage = "efi-service-demo.appspot.com";
			}

			try
			{
				var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
				var a = await auth.SignInWithEmailAndPasswordAsync(user, pass);
				//var cancellation = new CancellationTokenSource();
				var task = new FirebaseStorage(storage, new FirebaseStorageOptions
				{
					AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
					ThrowOnCancel = true
				})
					.Child("ServisRapor")
					.Child(fileName)
					.PutAsync(fs);

				// Track progress of the upload
				//task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

				var downloadUrl = await task;
				return downloadUrl;
			}
			catch (Exception ex)
			{
				string message = ex.Message.Replace(apiKey, "").Replace(user, "").Replace(pass, "").Replace(storage, "");

				MessageBox.Show(message);
				return "ERROR";
			}
		}

		private static async Task<string> UploadServisRapor2(string fileName, FileStream fs)
		{
			//EFI-MOBIL
			string apiKey = "AIzaSyCujZyeDMi5d5QeuvgJ0iIEN-YhF33p8Zs";
			string user = "erdalkarabulut@gmail.com";
			string pass = "123456";
			string storage = "efi-mobile.appspot.com";

			try
			{
				var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
				var a = await auth.SignInWithEmailAndPasswordAsync(user, pass);
				//var cancellation = new CancellationTokenSource();
				var task = new FirebaseStorage(storage, new FirebaseStorageOptions
				{
					AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
					ThrowOnCancel = true
				})
					.Child(CompanyGuid.ToString())
					.Child("ServisRapor")
					.Child(fileName)
					.PutAsync(fs);

				// Track progress of the upload
				//task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

				var downloadUrl = await task;
				return downloadUrl;
			}
			catch (Exception ex)
			{
				string message = ex.Message.Replace(apiKey, "").Replace(user, "").Replace(pass, "").Replace(storage, "");

				MessageBox.Show(message);
				return "ERROR";
			}
		}

		public static async Task ListenRequests()
		{
			if (_requestListener != null && (_requestListener.ListenerTask.Status == TaskStatus.Running)) return;

			try
			{
				Global global = CreateGlobal();
				GNKULL kull = null;

				CollectionReference colRef = _db.Collection("requests");
				Query query = colRef.WhereEqualTo("company", CompanyGuid.ToString()).WhereEqualTo("response", "");

				_requestListener = query.Listen(async snapshot =>
				{
					foreach (DocumentChange change in snapshot.Changes)
					{
						if (change.ChangeType.ToString() == "Removed") continue;

						Dictionary<string, object> dict = change.Document.ToDictionary();
						string response = dict["response"].ToString();

						if (response == "")
						{
							response = JsonConvert.SerializeObject(new List<Dictionary<string, object>>());

							Dictionary<string, object> dic = new Dictionary<string, object>();

							string request = dict["request"].ToString();
							string userName = dict["userName"].ToString();
							Dictionary<string, object> data = null;

							kull = _gnkullService.Cch_GetByUserKod_NLog(userName, global).Nesne;
							if (kull != null)
							{
								global = CreateGlobal(kull);
								if (dict["prokod"] != null) global.ProjeKod = dict["prokod"].ToString();
								if (dict["mnutag"] != null) global.MenuTag = Convert.ToInt32(dict["mnutag"]);
							}
							else
							{
								dic.Add("error", "Kullanıcı bulunamadı!");
								dic.Add("response", response);
								dic.Add("responseTime", Timestamp.GetCurrentTimestamp());
								await change.Document.Reference.UpdateAsync(dic);
								return;
							}

							if (request == "UserLoginLogout")
							{
								data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dict["data"].ToString());
								int pltform = Convert.ToInt16(data["menuPlatform"]);
								if (pltform > -1)
								{
									MenuPlatform platform = (MenuPlatform)pltform;
									//token ve platform kaydedilecek!!

									var yetkiList = _gnyetkService.Ncch_GetKullaniciYetkiList_NLog(global, kull.KULKOD, platform).Items;
									yetkiList = yetkiList.Where(d => d.GRNTLM).ToList();

									if (yetkiList.Count > 0) response = JsonConvert.SerializeObject(yetkiList);
									else dic.Add("error", "Kullanıcı için tanımlı menü yetkilendirmesi bulunamadı!");
								}
								else
								{
									string tkn = data["token"].ToString();
									string devicePlatform = data["platform"].ToString();

									//if (tkn == "" && devicePlatform == "") await change.Document.Reference.DeleteAsync();
								}
							}
							else if (request == "StokMiktarRapor")
							{
								response = _apiService.Ncch_GetStokRapor_NLog(global);
							}
							else if (request == "StokMiktarListWithPrice")
							{
								response = _apiService.Ncch_GetStokRapor_NLog(global, true);
							}
							else if (request == "ServisKartList")
							{
								data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dict["data"].ToString());

								var param = new SshParamModel()
								{
									BELGEN = "",
									DtBaslangic = Convert.ToDateTime(data["startDate"]),
									DtBitis = Convert.ToDateTime(data["endDate"]),
									All = true,
									Tamamlanan = false,
								};

								response = _apiService.Ncch_GetServisKartList_NLog(global, param);
							}
							else if (request == "SaveServisKart")
							{
								try
								{
									response = await _apiService.Ncch_SaveServisKart_NLog(global, dict);
									var d = JsonConvert.DeserializeObject<Dictionary<string, object>>(response);

									SHSRVS shsrvs = JsonConvert.DeserializeObject<SHSRVS>(d["SavedKart"].ToString());
									shsrvs = await GetServisRapor(shsrvs, global);

									var objDic = Bps.Core.Utilities.Converters.Convert.ObjectToDictionary(shsrvs);
									var dc = new Dictionary<string, object>();
									dc.Add("SavedKart", objDic);
									response = JsonConvert.SerializeObject(dc);
								}
								catch (Exception ex)
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("ERROR", ex.ToString());
									response = JsonConvert.SerializeObject(hata);
								}
							}
							else if (request == "GetServisRapor")
							{
								SHSRVS shsrvs = JsonConvert.DeserializeObject<SHSRVS>(dict["data"].ToString());
								shsrvs = await GetServisRapor(shsrvs, global);

								var dc = new Dictionary<string, object>();
								dc.Add("ServisRaporUrl", shsrvs.PDFURL);
								response = JsonConvert.SerializeObject(dc);
							}
							else if (request == "SaveCariYetkili")
							{
								response = _apiService.Ncch_SaveCariYetkili_NLog(global, dict);
							}
							else if (request == "GetServisParametreInfo")
							{
								response = _apiService.Ncch_GetServisParametreInfo_NLog(global);
							}
							else if (request == "GetSiparisFisTipList")
							{
								response = _apiService.Ncch_GetSiparisFisTipList_NLog(global);
							}
							else if (request == "GetSpfbasList")
							{
								data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dict["data"].ToString());
								SPFTIP spftip = JsonConvert.DeserializeObject<SPFTIP>(data["SPFTIP"].ToString());
								DateTime startDate = DateTime.Parse(data["StartDate"].ToString());
								DateTime endDate = DateTime.Parse(data["EndDate"].ToString());

								var param = new SiparisParamModel
								{
									SPDGKD = spftip.SPDGKD ?? "",
									BELGEN = "",
									DtBaslangic = startDate,
									DtBitis = endDate,
									SPFTNO = spftip.SPFTNO,
									SPORKD = spftip.SPORKD ?? "",
								};

								response = _apiService.Ncch_GetSpfbasList_NLog(global, param);
							}
							else if (request == "GetModulPaket")
							{
								var modulPaketList = _uragacService.Ncch_GetUrunAgaciModulPaketList_NLog(global).Items.OrderBy(o => o.MDLNAM).ToList();

								if (modulPaketList.Count > 0)
								{
									Dictionary<string, object> fieldsDict = new Dictionary<string, object>();
									fieldsDict.Add("UrunAgaciModulPaket", modulPaketList);

									response = JsonConvert.SerializeObject(fieldsDict);
								}
								else
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("ERROR", "Ürün bulunamadı!");
									response = JsonConvert.SerializeObject(hata);
								}
							}
							else if (request == "SaveStokImage")
							{
								Dictionary<string, string> imageInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(dict["data"].ToString());

								try
								{
									string stokImagePath = AppDomain.CurrentDomain.BaseDirectory + "StokImages\\" + imageInfo["fileName"];

									using (WebClient webClient = new WebClient())
									{
										webClient.DownloadFile(imageInfo["imgUrl"], stokImagePath);
									}

									string modulKodu = imageInfo["fileName"].Replace(".jpg", "");

									var r = _stkartService.Ncch_GetByStKod_NLog(modulKodu, global, false);
									if (r.Nesne != null)
									{
										STKART oldStkart = r.Nesne;
										STKART sKart = oldStkart.ShallowCopy();
										sKart.STKIMG = imageInfo["imgUrl"];
										_stkartDal.Update(sKart);
										response = "OK";
									}
									else response = "HATA:" + r.Message + r.ErrorMessage;

								}
								catch (Exception e)
								{
									response = "HATA:" + e.ToString();
								}
							}
							else if (request == "SaveProforma")
							{
								bool error = false;
								var resp = new StandardResponse<SiparisKayitModel>();

								data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dict["data"].ToString());

								SPFBAS spfbas = JsonConvert.DeserializeObject<SPFBAS>(data["SPFBAS"].ToString());
								spfbas.KYNKKD = global.KaynakKod;
								List<Product> products = JsonConvert.DeserializeObject<List<Product>>(data["ProductList"].ToString());

								STKFYT stkfyt = _stkfytService.Ncch_GetByFiyatNo_NLog(spfbas.STFYNO.ToString(), global, false).Nesne;
								bool kdvFlag = stkfyt.KDVFLG != null && stkfyt.KDVFLG.Value;

								var model = new SiparisKayitModel { Baslik = spfbas };
								var spfharList = new List<SPFHAR>();
								var existingSpfharList = new List<SPFHAR>();

								if (spfbas.Id == 0)
								{
									var sum = (double)products.Sum(p => p.TotalPrice);

									spfbas.TKDRKD = "01";
									spfbas.CKDEPO = "001"; //Şimdilik heryerde mamul depo 001 olduğu için statik
									spfbas.TOPBRT = sum;
									spfbas.TOPTUT = sum;
									spfbas.TOPKDV = kdvFlag ? sum * 0.2 : 0; //KDV %20 alınıyor. Mobil arayüzde kdv miktarı yapılınca değişecek burası.
									spfbas.TOPKDT = spfbas.TOPTUT + spfbas.TOPKDV;
								}
								else
								{
									existingSpfharList = _spfharService.Cch_GetListByBelge_NLog(spfbas.BELGEN, global).Items;
								}

								int satir = 1;
								foreach (var product in products)
								{
									product.RowNo = satir * 100;

									SPFHAR spfhar;

									if (product.Id > 0)
									{
										SPFHAR existingSpfhar = existingSpfharList.First(s => s.Id == product.Id);

										spfhar = existingSpfhar.ShallowCopy();
										spfhar.SATIRN = product.RowNo;
										spfhar.GNACIK = product.ProductDetails;
										spfhar.GNMKTR = product.Quantity;
										spfhar.GRMKTR = product.Quantity;
										spfhar.GFIYAT = product.UnitPrice;
										spfhar.GNTUTR = product.TotalPrice;
										spfhar.KLNMKTR = product.Quantity;

										existingSpfharList.Remove(existingSpfhar);
									}
									else
									{
										spfhar = new SPFHAR
										{
											SIRKID = spfbas.SIRKID,
											SPHRTP = spfbas.SPHRTP,
											SPFTNO = spfbas.SPFTNO,
											SPORKD = spfbas.SPORKD,
											SPDGKD = spfbas.SPDGKD,
											EVRAKN = spfbas.EVRAKN,
											SATIRN = product.RowNo,
											CRKODU = spfbas.CRKODU,
											STKODU = product.ProductCode,
											STKNAM = product.ProductName,
											GNACIK = product.ProductDetails.Trim(),
											STFYNO = spfbas.STFYNO,
											CKDEPO = spfbas.CKDEPO,
											DVCNKD = spfbas.DVCNKD,
											GNMKTR = product.Quantity,
											OLCUKD = "ADT",
											GRMKTR = product.Quantity,
											GROLBR = "ADT",
											GFIYAT = product.UnitPrice,
											GNTUTR = product.TotalPrice,
											MLKBTR = DateTime.Now,
											KLNMKTR = product.Quantity,
											ACTIVE = true,
											SLINDI = false,
											KYNKKD = spfbas.KYNKKD,
											CHKCTR = false
										};
									}

									spfharList.Add(spfhar);
									satir++;

									//GetUrunOpsiyonRecord(hrk.SATIRN.Value, hrk.STKODU);
								}

								model.Kalems = spfharList;

								//model.UrunOpsiyons = new List<UrunOpsiyonModel>();
								//foreach (var opsiyon in opsiyonList)
								//{
								//    foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
								//    {
								//        model.UrunOpsiyons.AddRange(urOp.Value);
								//    }
								//}

								if (existingSpfharList.Count > 0) _spfharDal.MultiDelete(existingSpfharList);

								resp = _xxService.Ncch_OnlineProformaKaydet_Log(model, global, false);
								if (resp.Status != ResponseStatusEnum.OK)
								{
									error = true;
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("HATA", resp.Message + " " + resp.ErrorMessage);
									List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
									list.Add(hata);
									response = JsonConvert.SerializeObject(list);
								}

								string downloadUrl = "";
								if (!error)
								{
									try
									{
										string extension = ".pdf";
										if (request == "createPdf") extension = ".pdf";
										else if (request == "createXlsx") extension = ".xlsx";

										FileStream fs = await CreateProforma2(resp.Nesne.Baslik.BELGEN, global, extension);
										downloadUrl = await UploadProforma2(resp.Nesne.Baslik.BELGEN, resp.Nesne.Baslik.BELGEN, fs, extension);
									}
									catch (Exception e)
									{

									}
								}

								resp.Nesne.Kalems = resp.Nesne.Kalems.OrderBy(s => s.SATIRN.Value).ToList();

								for (int i = 0; i < products.Count; i++)
								{
									products[i].Id = resp.Nesne.Kalems[i].Id;
									products[i].RowNo = resp.Nesne.Kalems[i].SATIRN.Value;
								}

								var settings = new JsonSerializerSettings
								{
									ContractResolver = new DefaultContractResolver
									{
										NamingStrategy = new CamelCaseNamingStrategy()
									},
									//Formatting = Formatting.Indented // Optional: Makes JSON output more readable
								};

								var serializedObj = JsonConvert.SerializeObject(products, settings);
								var productsMap = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(serializedObj);

								Dictionary<string, object> respObjects = new Dictionary<string, object>();
								respObjects.Add("SPFBAS", resp.Nesne.Baslik);
								respObjects.Add("ProductList", productsMap);
								respObjects.Add("fileUrl", downloadUrl);

								response = JsonConvert.SerializeObject(respObjects);
							}
							else if (request == "GetProforma")
							{
								try
								{
									data = JsonConvert.DeserializeObject<Dictionary<string, object>>(dict["data"].ToString());

									string belgeNo = data["SipBelgeNo"].ToString();

									string extension = ".pdf";
									if (request == "createPdf") extension = ".pdf";
									else if (request == "createXlsx") extension = ".xlsx";

									FileStream fs = await CreateProforma2(belgeNo, global, extension);
									string downloadUrl = await UploadProforma2(belgeNo, belgeNo, fs, extension);

									Dictionary<string, object> respObjects = new Dictionary<string, object>();
									respObjects.Add("fileUrl", downloadUrl);

									response = JsonConvert.SerializeObject(respObjects);
								}
								catch (Exception ex)
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("ERROR", ex.ToString());
									response = JsonConvert.SerializeObject(hata);
								}
							}

							dic.Add("response", response);
							dic.Add("responseTime", Timestamp.GetCurrentTimestamp());
							await change.Document.Reference.UpdateAsync(dic);
						}
					}
				});
			}
			catch (Exception ex)
			{
				await StopListening(_requestListener);

				using (StreamWriter sw = File.AppendText(ErrorLogPath))
				{
					sw.WriteLine(ex.Message);
				}

				MessageBox.Show(ex.ToString());
			}
		}

		private static async Task<SHSRVS> GetServisRapor(SHSRVS shsrvs, Global global)
		{
			if (shsrvs.SRVDRM == "03")
			{
				List<STHRKT> sthrktList = _sthrktService.Ncch_GetListKalemByUstBelgeNo_NLog(global, shsrvs.BELGEN, false).Items;

				shsrvs.CRUNVN = shsrvs.CRUNVN.Replace("\"", "").Replace("\\", "").Replace("'", "");
				string fileName = shsrvs.BELGEN + " - " + shsrvs.CRUNVN + ".pdf";

				string filePath = await CreateServisRapor2(shsrvs, sthrktList, global);
				using (var fs = new FileStream(filePath, FileMode.Open))
				{
					string downloadUrl = await UploadServisRapor2(fileName, fs);
					shsrvs.PDFURL = downloadUrl;
				}
			}

			return shsrvs;
		}

		public static async Task ListenRequest()
		{
			if (_requestListener != null && (_requestListener.ListenerTask.Status == TaskStatus.Running)) return;

			try
			{
				Global global = CreateGlobal();
				GNKULL kull = null;

				CollectionReference colRef = _db.Collection("requests");
				Query query = colRef.WhereEqualTo("response", "");

				_requestListener = query.Listen(async snapshot =>
				{
					foreach (DocumentChange change in snapshot.Changes)
					{
						if (change.ChangeType.ToString() == "Removed") continue;

						Dictionary<string, object> dict = change.Document.ToDictionary();
						string response = dict["response"].ToString();

						if (response == "")
						{
							string request = dict["request"].ToString();
							int persId = Convert.ToInt32(dict["persId"]);

							if (global.PersId != persId)
							{
								kull = _gnkullService.Ncch_GetByPersId_NLog(persId, global, false).Nesne;
								if (kull != null) global = CreateGlobal(kull);
							}

							if (request == "serviceBag")
							{
								string depoNo = dict["data"].ToString();
								var depoList = _gndpzmService.Ncch_GetByPersonelId_NLog(persId, global, false).Items;
								if (depoList != null && depoList.Count > 0)
								{
									GNDPZM gndpzm;
									List<StdepoStokMiktarModel> stokList = new List<StdepoStokMiktarModel>();

									depoList = depoList.Where(d => d.MOBILE).ToList();
									if (depoList.Count > 0)
									{
										if (depoNo != "") gndpzm = depoList.FirstOrDefault(d => d.DPKODU == depoNo);
										else gndpzm = depoList[0];

										if (gndpzm != null)
										{
											var stoklar = _stdepoService.GetStokMiktarRapor(global, depoKodu: gndpzm.DPKODU, yetkiKontrol: false).Items;
											stoklar = stoklar.FindAll(s => s.USESTK > 0 && s.STMLTR != "700"); //Yardımcı malzemeler ve stoğu yok olanları listeye alma
											stokList.AddRange(stoklar);
										}
									}

									//foreach (GNDPZM gndpzm in depoList)
									//{
									//	string depoKodu = gndpzm.DPKODU;
									//	var stoklar = _stdepoService.GetStokMiktarRapor(global, depoKodu: depoKodu, yetkiKontrol: false).Items;
									//	stoklar = stoklar.FindAll(s => s.USESTK > 0 && s.STMLTR != "700"); //Yardımcı malzemeler ve stoğu yok olanları listeye alma
									//	stokList.AddRange(stoklar);
									//}

									List<object> respObject = new List<object>();
									respObject.Add(depoList);
									respObject.Add(stokList);

									response = JsonConvert.SerializeObject(respObject);
								}
								else
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("HATA", "Kullanıcı için tanımlı depo bulunamadı!");
									List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
									list.Add(hata);
									response = JsonConvert.SerializeObject(list);
								}

								Dictionary<string, object> dic = new Dictionary<string, object>();
								dic.Add("response", response);
								await change.Document.Reference.UpdateAsync(dic);
							}
							else if (request == "fields")
							{
								var makineKategoriTip = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MKNKTG", false).Nesne;
								var makineKategoriList = _gntipiService.Ncch_GetListByUstTipKod_NLog(global, makineKategoriTip.TIPKOD, false).Items;

								List<GNTHRK> tipHrkList = new List<GNTHRK>();
								if (makineKategoriList.Count > 0)
								{
									foreach (var gntipi in makineKategoriList)
									{
										var modelList = _gnthrkService.Cch_GetListByTeknad(global, gntipi.TEKNAD, false).Items;
										if (modelList.Count > 0) tipHrkList.AddRange(modelList);
									}

									Dictionary<string, object> fieldsDict = new Dictionary<string, object>();
									fieldsDict.Add("GNTIPI", makineKategoriList);
									fieldsDict.Add("GNTHRK", tipHrkList);

									response = JsonConvert.SerializeObject(fieldsDict);
								}
								else
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("HATA", "Liste boş!");
									response = JsonConvert.SerializeObject(hata);
								}

								Dictionary<string, object> dic = new Dictionary<string, object>();
								dic.Add("response", response);
								await change.Document.Reference.UpdateAsync(dic);
							}
							else if (request.StartsWith("getServisRapor"))
							{
								try
								{
									int id = Convert.ToInt32(dict["data"].ToString());
									SHSRVS workOrder = _shsrvsService.Ncch_GetById_NLog(id, global, false).Nesne;

									string folder = AppDomain.CurrentDomain.BaseDirectory + "Servis Raporları\\";
									Directory.CreateDirectory(folder);
									string fileName = workOrder.BELGEN + " - " + workOrder.CRUNVN + ".pdf";

									Dictionary<string, object> dic = new Dictionary<string, object>();

									response = "";
									if (File.Exists(folder + fileName))
									{
										using (var fs = new FileStream(folder + fileName, FileMode.Open))
										{
											string downloadUrl = await UploadServisRapor(fileName, fs);
											response = workOrder.PDFURL = downloadUrl;
											dic.Add("response", response);
										}

										_shsrvsService.Ncch_UpdateFromApi_Log(workOrder, workOrder, global);

										Dictionary<string, object> dic2 = new Dictionary<string, object>();
										dic2.Add("PDFURL", response);

										DocumentReference docRef = _db.Collection("workOrders").Document(id.ToString());
										await docRef.UpdateAsync(dic2);
									}
									else
									{
										List<STHRKT> sthrktList = new List<STHRKT>();
										if (!string.IsNullOrEmpty(workOrder.KULPRC))
										{
											var kulprcList = JsonConvert.DeserializeObject<List<TabletStokHareket>>(workOrder.KULPRC);
											if (kulprcList != null)
											{
												int satirNo = 1;
												foreach (TabletStokHareket kulprc in kulprcList)
												{
													STHRKT sthrkt = new STHRKT
													{
														CRKODU = workOrder.CRKODU,
														SATIRN = satirNo,
														STKODU = kulprc.STKODU,
														STKNAM = kulprc.STKNAM,
														GRMKTR = kulprc.MIKTAR,
														GNMKTR = kulprc.MIKTAR,
														GROLBR = kulprc.OLCUKD,
														OLCUKD = kulprc.OLCUKD,
														CKDEPO = kulprc.DPKODU,
														GNACIK = "Servis modülü depo çıkışı",
														USTBLG = workOrder.BELGEN,
													};
													sthrktList.Add(sthrkt);
													satirNo++;
												}
											}
										}

										dic.Add("SRSYNC", true);

										if (workOrder.SRVDRM == "03")
										{
											try
											{
												string filePath = await CreateServisRapor(workOrder, sthrktList, global);
												using (var fs = new FileStream(filePath, FileMode.Open))
												{
													string downloadUrl = await UploadServisRapor(fileName, fs);
													response = workOrder.PDFURL = downloadUrl;
													dic.Add("PDFURL", downloadUrl);
												}

												_shsrvsService.Ncch_UpdateFromApi_Log(workOrder, workOrder, global);

												Dictionary<string, object> dic2 = new Dictionary<string, object>();
												dic2.Add("PDFURL", response);

												DocumentReference docRef = _db.Collection("workOrders").Document(id.ToString());
												await docRef.UpdateAsync(dic2);

											}
											catch (Exception e)
											{
												// ignored
											}
										}
									}

									if (response == "")
									{
										dic.Add("response", "ERROR");
									}

									await change.Document.Reference.UpdateAsync(dic);
								}
								catch (Exception e)
								{
									Console.WriteLine(e);
									//throw;
								}

							}
							else if (request == "getModul" || request == "getPaket" || request == "getModulPaket")
							{
								//var stokList = _stkartService.Cch_GetListByMalTur_NLog(global, "001", false).Items;
								//var paketList = _stkartService.Cch_GetListByMalTur_NLog(global, "002", false).Items;

								var modulPaketList = _uragacService.Ncch_GetUrunAgaciModulPaketList_NLog(global).Items;

								if (modulPaketList.Count > 0)
								{
									Dictionary<string, object> fieldsDict = new Dictionary<string, object>();
									fieldsDict.Add("UrunAgaciModulPaket", modulPaketList);

									response = JsonConvert.SerializeObject(fieldsDict);
								}
								else
								{
									Dictionary<string, object> hata = new Dictionary<string, object>();
									hata.Add("HATA", "Liste boş!");
									response = JsonConvert.SerializeObject(hata);
								}

								Dictionary<string, object> dic = new Dictionary<string, object>();
								dic.Add("response", response);
								await change.Document.Reference.UpdateAsync(dic);
							}
							else if (request == "saveStokImage")
							{
								Dictionary<string, string> imageInfo = JsonConvert.DeserializeObject<Dictionary<string, string>>(dict["data"].ToString());

								try
								{
									string stokImagePath = AppDomain.CurrentDomain.BaseDirectory + "StokImages\\" + imageInfo["fileName"];

									using (WebClient webClient = new WebClient())
									{
										webClient.DownloadFile(imageInfo["imgUrl"], stokImagePath);
									}

									string modulKodu = imageInfo["fileName"].Replace(".jpg", "");

									var r = _stkartService.Ncch_GetByStKod_NLog(modulKodu, global, false);
									if (r.Nesne != null)
									{
										STKART oldStkart = r.Nesne;
										STKART sKart = oldStkart.ShallowCopy();
										sKart.STKIMG = imageInfo["imgUrl"];
										_stkartDal.Update(sKart);
										response = "OK";
									}
									else response = "HATA:" + r.Message + r.ErrorMessage;

								}
								catch (Exception e)
								{
									response = "HATA:" + e.ToString();
								}

								Dictionary<string, object> dic = new Dictionary<string, object>();
								dic.Add("response", response);
								await change.Document.Reference.UpdateAsync(dic);
							}
							else if ((request == "createPdf" || request == "createXlsx") && response == "")
							{
								Order order = JsonConvert.DeserializeObject<Order>(dict["data"].ToString());

								var resp = new StandardResponse<SiparisKayitModel>();

								if (string.IsNullOrEmpty(order.PINo))
								{
									var model = new SiparisKayitModel();
									var baslik = new SPFBAS
									{
										SIRKID = global.SirketId.Value,
										SPHRTP = 5,
										SPFTNO = -1,
										BELTRH = DateTime.Now,
										DVCNKD = "USD",
										STFYNO = -1,
										ACTIVE = true,
										SLINDI = false,
										KYNKKD = global.KaynakKod,
										EKKULL = global.UserKod,
										ETARIH = DateTime.Now,
										CHKCTR = false,
									};
									model.Baslik = baslik;

									//var spfhars = sPFHARBindingSource.List;
									//var harekets = new List<SPFHAR>();

									//foreach (var bind in spfhars)
									//{
									//    var hrk = (SPFHAR)bind;
									//    hrk.ACTIVE = true;
									//    hrk.SLINDI = false;
									//    hrk.EVRAKN = model.Baslik.EVRAKN;
									//    hrk.BELGEN = model.Baslik.BELGEN;
									//    hrk.BELTRH = model.Baslik.BELTRH;
									//    hrk.SPHRTP = model.Baslik.SPHRTP;
									//    hrk.SPORKD = model.Baslik.SPORKD;
									//    hrk.SPDGKD = model.Baslik.SPDGKD;
									//    hrk.SPFTNO = model.Baslik.SPFTNO;

									//    harekets.Add(hrk);

									//    GetUrunOpsiyonRecord(hrk.SATIRN.Value, hrk.STKODU);
									//}

									//model.Kalems = harekets;

									//model.UrunOpsiyons = new List<UrunOpsiyonModel>();
									//foreach (var opsiyon in opsiyonList)
									//{
									//    foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
									//    {
									//        model.UrunOpsiyons.AddRange(urOp.Value);
									//    }
									//}

									resp = _xxService.Ncch_OnlineProformaKaydet_Log(model, global, false);
									if (resp.Status != ResponseStatusEnum.OK) resp.Message = "ERROR";

									if (resp.Message != "ERROR") order.PINo = resp.Message;
								}
								else
								{
									resp.Message = order.PINo;
								}

								Dictionary<string, object> dic = new Dictionary<string, object>();

								if (resp.Message == "ERROR")
								{
									response = "ERROR";
								}
								else
								{
									try
									{
										string extension = "";
										if (request == "createPdf") extension = ".pdf";
										else if (request == "createXlsx") extension = ".xlsx";

										FileStream fs = await CreateProforma(order, global, extension);
										string downloadUrl = await UploadProforma(order, fs, extension);
										response = downloadUrl;
									}
									catch (Exception e)
									{

									}
								}

								dic.Add("response", response);
								dic.Add("data", order.PINo);
								await change.Document.Reference.UpdateAsync(dic);

								Dictionary<string, object> dic2 = new Dictionary<string, object>();
								dic2.Add("pdfUrl", response);
								dic2.Add("piNo", order.PINo);

								DocumentReference docRef = _db.Collection("orders").Document(order.DocId);
								await docRef.UpdateAsync(dic2);
							}
						}

						//var json = JsonConvert.SerializeObject(dict);
						//SHSRVS workOrder = JsonConvert.DeserializeObject<SHSRVS>(json);
						//workOrder.SRSYNC = true;
						//workOrder.DTARIH = DateTime.Now;

						//GNKULL kull = _gnkullService.Ncch_GetById_NLog(workOrder.SRPRID.Value, global, false).Nesne;
						//if (kull != null) workOrder.DEKULL = kull.KULKOD;

						//var response = new StandardResponse<SHSRVS>();
						//response = _shsrvsService.Ncch_UpdateFromTablet_Log(workOrder, workOrder, global);

						//if (response.Status == ResponseStatusEnum.OK)
						//{
						//    Dictionary<string, object> dic = new Dictionary<string, object>();
						//    dic.Add("SRSYNC", true);
						//    await change.Document.Reference.UpdateAsync(dic);
						//}
					}
				});
			}
			catch (Exception ex)
			{
				await StopListening(_requestListener);
			}
		}

		private static async Task StopListening(FirestoreChangeListener listener)
		{
			if (listener != null)
			{
				await listener.StopAsync();
				listener = null;
			}
		}

		private static async Task<FileStream> CreateProforma(Order order, Global global, string extension)
		{
			foreach (Product product in order.Products)
			{
				try
				{
					product.StokImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "StokImages\\" + product.ProductCode + ".jpg");
				}
				catch (Exception e)
				{

				}

				if (order.Language == "EN")
				{
					var stname = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, product.ProductCode, "EN", false).Nesne;
					product.ProductName = stname == null ? "" : stname.STKNAM; //product.ProductNameEn;

					if (product.ProductDetails == "") product.ProductDetails = "CATALOGUE";
				}
				else
				{
					if (product.ProductDetails == "") product.ProductDetails = "KATALOG";
				}
			}

			DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			DateTime orderDate = start.AddMilliseconds(order.DocumentDate).ToLocalTime();

			repProforma rProforma = new repProforma();
			rProforma.DataSource = order.Products;

			CultureInfo cultureInfo = new CultureInfo("tr-TR");
			if (order.Currency == "USD")
			{
				cultureInfo = new CultureInfo("en-US");
				rProforma.cellAccountNo.Text = "TR62 0020 5000 0955 6894 7001 01";
			}
			else if (order.Currency == "EUR")
			{
				cultureInfo = new CultureInfo("de-DE");
				rProforma.cellAccountNo.Text = "TR35 0020 5000 0955 6894 7001 02";
			}
			else
			{
				cultureInfo = new CultureInfo("tr-TR");
				rProforma.cellAccountNo.Text = "TR46 0020 5000 0955 6894 7000 01";
			}
			rProforma.ApplyLocalization(cultureInfo);

			//GNKULL kull = _gnkullService.Ncch_GetByPersId_NLog(global.PersId.Value, global, false).Nesne;
			GNKULL export = _gnkullService.Ncch_GetByPersId_NLog(3, global, false).Nesne;
			GNKULL export1 = _gnkullService.Ncch_GetByPersId_NLog(2, global, false).Nesne;
			GNKULL export2 = _gnkullService.Ncch_GetByPersId_NLog(4, global, false).Nesne;

			rProforma.cellEmail.Text = "export@aracikan.com" + Environment.NewLine + "export1@aracikan.com" + Environment.NewLine + "export2@aracikan.com"; //kullAdmin.GNMAIL;
			rProforma.cellTelefon.Text = export.GNNAME + " " + export.GNSNAM + " " + export.GNTELF +
										 Environment.NewLine +
										 export1.GNNAME + " " + export1.GNSNAM + " " + export1.GNTELF +
										 Environment.NewLine +
										 export2.GNNAME + " " + export2.GNSNAM + " " + export2.GNTELF;

			rProforma.cellPINo.Text = order.PINo;
			rProforma.cellBuyerName.Text = order.BuyerName;
			rProforma.cellBuyerEmail.Text = order.BuyerEmail;
			rProforma.cellBuyerAddress.Text = order.BuyerAddress;
			rProforma.cellBuyerContact.Text = order.BuyerContact;
			rProforma.cellShippingTerms.Text = order.ShipmentTerms;
			rProforma.cellPaymentTerms.Text = order.PaymentTerms;
			rProforma.cellDeliveryTerms.Text = order.DeliveryTerms;
			rProforma.cellDate.Text = orderDate.ToShortDateString();

			rProforma.cellAdvancedPayDummy.Text = " ";
			rProforma.cellDiscountDummy.Text = " ";
			rProforma.cellBalanceDummy.Text = " ";

			var sum = order.Products.Sum(p => p.TotalPrice);
			var balance = sum - order.AdvancePayment - order.Discount;
			rProforma.cellBalance.Text = balance.ToString("c2", cultureInfo);

			if (order.AdvancePayment == 0)
			{
				rProforma.cellAdvancePayment.Text = null;
				rProforma.cellAdvancedPaymentLabel.Text = null;
				rProforma.cellAdvancedPayDummy.Text = null;
			}
			else rProforma.cellAdvancePayment.Text = order.AdvancePayment.ToString("c2", cultureInfo);

			if (order.Discount == 0)
			{
				rProforma.cellDiscount.Text = null;
				rProforma.cellDiscountLabel.Text = null;
				rProforma.cellDiscountDummy.Text = null;
			}
			else rProforma.cellDiscount.Text = order.Discount.ToString("c2", cultureInfo);

			if (order.AdvancePayment == 0 && order.Discount == 0)
			{
				rProforma.cellBalance.Text = null;
				rProforma.cellBalanceLabel.Text = null;
				rProforma.cellBalanceDummy.Text = null;
			}


			string filePath = AppDomain.CurrentDomain.BaseDirectory + "OnlineProforma\\" + order.PINo + extension;

			if (extension == ".pdf")
			{
				rProforma.CreateDocument();
				rProforma.ExportToPdf(filePath);
			}
			else if (extension == ".xlsx")
			{
				//XlsxExportOptions options = new XlsxExportOptions(TextExportMode.Text);

				rProforma.xrLabel12.TextFormatString = "{0:n2}";
				rProforma.xrLabel13.TextFormatString = "{0:n2}";
				rProforma.xrTableCell60.TextFormatString = "{0:n2}";
				rProforma.xrTableCell61.TextFormatString = "{0:n2}";
				rProforma.cellParaBirimi.Text = order.Currency;
				rProforma.CreateDocument();
				rProforma.ExportToXlsx(filePath);
			}

			var fs = new FileStream(filePath, FileMode.Open);
			return fs;
		}

		private static async Task<string> UploadProforma(Order order, FileStream fs, string extension)
		{
			try
			{
				var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyD8d0ECOC0EEkxi-k1EE5UOJXRcdK0WAVY"));
				var a = await auth.SignInWithEmailAndPasswordAsync("ilkaygumus@gmail.com", "test1234");
				//var cancellation = new CancellationTokenSource();

				var task = new FirebaseStorage("aracikan-cloud.appspot.com", new FirebaseStorageOptions
				{
					AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
					ThrowOnCancel = true
				})
				.Child("Orders")
				.Child(order.PINo.ToString() + " - " + order.BuyerName + extension)
				.PutAsync(fs);

				// Track progress of the upload
				//task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

				var downloadUrl = await task;
				return downloadUrl;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
				return "ERROR";
			}
		}

		private static async Task<FileStream> CreateProforma2(string belgeNo, Global global, string extension)
		{
			SPFBAS spfbas = _spfbasService.Ncch_GetByBelgeNo_NLog(belgeNo, global, false).Nesne;
			STKFYT stkfyt = _stkfytService.Ncch_GetByFiyatNo_NLog(spfbas.STFYNO.ToString(), global, false).Nesne;
			GNKULL kull = _gnkullService.Cch_GetByUserKod_NLog(global.UserKod, global).Nesne;
			GNKULL creator = _gnkullService.Cch_GetByUserKod_NLog(spfbas.EKKULL, global).Nesne;
			CRCARI cari = _crcariService.Ncch_GetByCariKod_NLog(spfbas.CRKODU, global, false).Nesne;
			List<CRYTKL> yetkiliList = _crytklService.Cch_GetListByCariKod_NLog(spfbas.CRKODU, global, false).Items;

			List<Product> products = _spfharService.Ncch_GetProformaProducts_NLog(belgeNo, global).Items;
			List<string> adresSeparate = new List<string>();
			List<string> cariAdres = _apiService.GetCariTamAdres(global, cari.CRKODU, out adresSeparate);

			bool kdvFlag = stkfyt.KDVFLG != null && stkfyt.KDVFLG.Value;
			int row = 1;
			foreach (Product product in products)
			{
				product.RowNo = row++;

				product.TaxAmount = 0;
				if (kdvFlag) product.TaxAmount = product.TotalPrice * (decimal)0.2;

				try
				{
					product.StokImage = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "StokImages\\" + product.ProductCode + ".jpg");
				}
				catch (Exception e)
				{

				}

				//if (order.Language == "EN")
				//{
				//	var stname = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, product.ProductCode, "EN", false).Nesne;
				//	product.ProductName = stname == null ? "" : stname.STKNAM; //product.ProductNameEn;

				//	if (product.ProductDetails == "") product.ProductDetails = "CATALOGUE";
				//}
				//else
				//{
				//	if (product.ProductDetails == "") product.ProductDetails = "KATALOG";
				//}
			}

			OtonomProforma rProforma = new OtonomProforma();
			rProforma.DataSource = products;

			CultureInfo cultureInfo = new CultureInfo("tr-TR");
			if (spfbas.DVCNKD == "USD") cultureInfo = new CultureInfo("en-US");
			else if (spfbas.DVCNKD == "EUR") cultureInfo = new CultureInfo("de-DE");
			else cultureInfo = new CultureInfo("tr-TR");
			rProforma.ApplyLocalization(cultureInfo);

			rProforma.lblProformaNo.Text = spfbas.BELGEN;
			rProforma.lblDate.Text = spfbas.BELTRH.ToShortDateString();

			rProforma.cellAuthorizedPerson.Text = creator.GNNAME + " " + creator.GNSNAM;
			rProforma.cellAuthorizedEmail.Text = creator.GNMAIL ?? "";
			rProforma.cellAuthorizedCell.Text = creator.GNTELF ?? "";

			rProforma.cellMusteri.Text = cari.CRUNV1;
			rProforma.cellMusteriAdres.Text = cariAdres.Count > 0 ? cariAdres[0].Trim() : "";
			if (adresSeparate.Count > 0)
			{
				rProforma.cellMusteriUlke.Text = adresSeparate[0].Trim();
				rProforma.cellMusteriSehir.Text = adresSeparate[1].Trim();
			}

			if (yetkiliList.Count > 0)
			{
				rProforma.cellMusteriTelefon.Text = yetkiliList[0].ISYTEL; //Şimdilik sadece ilk sıradaki yetkiliyi al
				rProforma.cellMusteriAuthorizedPerson.Text = yetkiliList[0].YETADI + " " + yetkiliList[0].YETSOY;
				rProforma.cellMusteriEmail.Text = yetkiliList[0].GNMAIL;
			}

			if (!kdvFlag)
			{
				rProforma.xrTable2.DeleteRow(rProforma.xrTableRow2);
				rProforma.xrTable2.DeleteRow(rProforma.xrTableRow3);
			}

			//rProforma.cellPINo.Text = spfbas.BELGEN;
			//rProforma.cellBuyerName.Text = "ALICI";
			//rProforma.cellBuyerEmail.Text = "ALICI EMAİL";
			//rProforma.cellBuyerAddress.Text = "ALICI ADRES";
			//rProforma.cellBuyerContact.Text = "ALICI YETKİLİ";
			//rProforma.cellShippingTerms.Text = "SHIPPING TERMS";
			//rProforma.cellPaymentTerms.Text = "PAYMENT TERMS";
			//rProforma.cellDeliveryTerms.Text = "DELIVERY TERMS";
			//rProforma.cellDate.Text = orderDate.ToShortDateString();

			//rProforma.cellAdvancedPayDummy.Text = " ";
			//rProforma.cellDiscountDummy.Text = " ";
			//rProforma.cellBalanceDummy.Text = " ";

			var sum = products.Sum(p => p.TotalPrice);
			//var balance = sum - order.AdvancePayment - order.Discount;
			//rProforma.cellBalance.Text = sum.Value.ToString("c2", cultureInfo); //balance.ToString("c2", cultureInfo);

			//if (order.AdvancePayment == 0)
			//{
			//	rProforma.cellAdvancePayment.Text = null;
			//	rProforma.cellAdvancedPaymentLabel.Text = null;
			//	rProforma.cellAdvancedPayDummy.Text = null;
			//}
			//else rProforma.cellAdvancePayment.Text = order.AdvancePayment.ToString("c2", cultureInfo);

			//if (order.Discount == 0)
			//{
			//	rProforma.cellDiscount.Text = null;
			//	rProforma.cellDiscountLabel.Text = null;
			//	rProforma.cellDiscountDummy.Text = null;
			//}
			//else rProforma.cellDiscount.Text = order.Discount.ToString("c2", cultureInfo);

			//if (order.AdvancePayment == 0 && order.Discount == 0)
			//{
			//	rProforma.cellBalance.Text = null;
			//	rProforma.cellBalanceLabel.Text = null;
			//	rProforma.cellBalanceDummy.Text = null;
			//}


			string filePath = AppDomain.CurrentDomain.BaseDirectory + "OnlineProforma\\" + spfbas.BELGEN + extension;

			if (extension == ".pdf")
			{
				rProforma.CreateDocument();
				rProforma.ExportToPdf(filePath);
			}
			else if (extension == ".xlsx")
			{
				//XlsxExportOptions options = new XlsxExportOptions(TextExportMode.Text);

				rProforma.xrLabel12.TextFormatString = "{0:n2}";
				rProforma.xrLabel13.TextFormatString = "{0:n2}";
				//rProforma.xrTableCell60.TextFormatString = "{0:n2}";
				//rProforma.xrTableCell61.TextFormatString = "{0:n2}";
				//rProforma.cellParaBirimi.Text = spfbas.DVCNKD;
				rProforma.CreateDocument();
				rProforma.ExportToXlsx(filePath);
			}

			var fs = new FileStream(filePath, FileMode.Open);
			return fs;
		}

		private static async Task<string> UploadProforma2(string belgeNo, string customer, FileStream fs, string extension)
		{
			try
			{
				//EFI-MOBIL
				string apiKey = "AIzaSyCujZyeDMi5d5QeuvgJ0iIEN-YhF33p8Zs";
				string user = "ilkaygumus@gmail.com";
				string pass = "test1234";
				string storage = "efi-mobile.appspot.com";

				var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
				var a = await auth.SignInWithEmailAndPasswordAsync(user, pass);
				//var cancellation = new CancellationTokenSource();

				var task = new FirebaseStorage(storage, new FirebaseStorageOptions
				{
					AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
					ThrowOnCancel = true
				})
					.Child(CompanyGuid.ToString())
					.Child("Proforma")
					.Child(belgeNo + " - " + customer + extension)
					.PutAsync(fs);

				// Track progress of the upload
				//task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

				var downloadUrl = await task;
				return downloadUrl;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message);
				return "ERROR";
			}
		}

		private static Dictionary<string, object> TimestampToDateTime(Dictionary<string, object> dictionary)
		{
			var dateList = dictionary.Where(d => d.Value is Timestamp).ToList();
			foreach (KeyValuePair<string, object> kvp in dateList)
			{
				Timestamp ts = (Timestamp)kvp.Value;
				dictionary[kvp.Key] = ts.ToDateTime();
			}

			if (dictionary.ContainsKey("STRSTP"))
			{
				var list = dictionary["STRSTP"] as List<object>;
				if (list != null)
				{
					foreach (Dictionary<string, object> map in list)
					{
						dateList = map.Where(d => d.Value is Timestamp).ToList();
						foreach (KeyValuePair<string, object> kvp in dateList)
						{
							Timestamp ts = (Timestamp)kvp.Value;
							map[kvp.Key] = ts.ToString();
						}
					}

					dictionary["STRSTP"] = list;
				}
			}

			return dictionary;
		}

		//public async Task<bool> SetData(string collection, IFirestoreEntity data)
		//{
		//    try
		//    {
		//        //var serialized = data.Serialize();
		//        var json = JsonConvert.SerializeObject(data);
		//        var dataMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

		//        DocumentReference docRef;
		//        if (string.IsNullOrEmpty(data.DocumentId)) docRef = _db.Collection(collection).Document();
		//        else docRef = _db.Collection(collection).Document(data.DocumentId);

		//        await docRef.SetAsync(dataMap);

		//        return true;
		//    }
		//    catch (Exception ex)
		//    {

		//    }

		//    return false;
		//}

		public static async Task<bool> SendNotification(string title, string body, List<string> tokenList = null, string topic = "", string click_action = "")
		{
			if (FirebaseMessaging.DefaultInstance == null)
			{
				FirebaseApp.Create(new AppOptions()
				{
					Credential = GoogleCredential.FromFile(jsonPath)
				});
			}

			//tokenList = new List<string>();
			//tokenList.Add("fCSkoSzntEoMl0-yjE72b9:APA91bHcE2iOU2gupAtlbQCiehXB-iPHBlgMZuZB-98PwVtMa6V9a-Mq8b60pk3nFuBx9elvINlaRUa7Pq93ZtTVy8gB0FiLPCtdMysbn1fGgCKKic1WBRZ6_vUTFAh-BrL6UYEXU9Oe");

			if (tokenList == null || tokenList.Count == 0) return false;

			try
			{
				//Tek cihaz
				//var message = new FirebaseAdmin.Messaging.Message()
				//{
				//	Token = token,
				//	Notification = new Notification()
				//	{
				//		Title = title,
				//		Body = body
				//	}
				//};

				var message = new MulticastMessage()
				{
					Tokens = tokenList,
					Notification = new Notification
					{
						Title = title,
						Body = body
					}
				};

				//// Tek cihaz
				//string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

				BatchResponse response = await FirebaseMessaging.DefaultInstance.SendEachForMulticastAsync(message);

				Console.WriteLine($"{response.SuccessCount} messages were sent successfully.");
				Console.WriteLine($"{response.FailureCount} messages failed to send.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("HATA: " + ex.ToString());
				return false;
			}

			// // Eski yöntem
			//try
			//{
			//	const string SERVER_KEY_TOKEN = "AAAA68dkOU4:APA91bGYFZozeJq165zCLiRsBPfr15TcY3e1xY0tCBqUSNQYXBKI6Tuc_E8m7lVzpciwF2alnkwKrc9vQCeFb0_htAcH6Bdyyeiz35Ttgxi7ptlQp83jG56O3tuMy73u08t5lSUZybeI";
			//	const string SENDER_ID = "1012662548814";
			//	const string REQUEST_URI = "https://fcm.googleapis.com/fcm/send";
			//	//string target = token == "" ? "/topics/" + topic : token;

			//	WebRequest tRequest = WebRequest.Create(REQUEST_URI);
			//	tRequest.Method = "post";
			//	tRequest.ContentType = " application/json";
			//	tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_KEY_TOKEN));
			//	tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

			//	var data = new
			//	{
			//		registration_ids = tokenList,
			//		notification = new
			//		{
			//			title,
			//			body,
			//			icon = "https://78.165.18.12/images/logo.png",
			//			click_action,
			//			sound = "mySound"
			//		},
			//		//to = target
			//	};

			//	byte[] byteArray = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(data));
			//	tRequest.ContentLength = byteArray.Length;

			//	Stream dataStream = tRequest.GetRequestStream();
			//	dataStream.Write(byteArray, 0, byteArray.Length);
			//	dataStream.Close();

			//	WebResponse tResponse = tRequest.GetResponse();
			//	dataStream = tResponse.GetResponseStream();

			//	StreamReader tReader = new StreamReader(dataStream);
			//	var response = tReader.ReadToEnd();

			//	tReader.Close();
			//	dataStream.Close();
			//	tResponse.Close();
			//	Console.WriteLine(response);
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.ToString());
			//	return false;
			//}

			return true;
		}
	}

	class TabletStokHareket
	{
		public string STKODU;
		public string STKNAM;
		public string OLCUKD;
		public int MIKTAR;
		public string DPKODU;
	}
}


