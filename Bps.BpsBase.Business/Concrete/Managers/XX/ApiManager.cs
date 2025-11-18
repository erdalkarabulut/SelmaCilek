using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Abstract.SH;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Svg;
//using Convert = Bps.Core.Utilities.Converters.Convert;

namespace Bps.BpsBase.Business.Concrete.Managers.XX
{
	public class ApiManager : IApiService
	{
		private readonly IGnService _gnService;
		private readonly IGnkullService _gnkullService;
		private readonly IGntipiService _gntipiService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IGnlkhrService _gnlkhrService;
		private readonly IStdepoService _stdepoService;
		private readonly ISthrktService _sthrktService;
		private readonly IShsrvsService _shsrvsService;
		private readonly ICrcariService _crcariService;
		private readonly ICrytklService _crytklService;
		private readonly IGnevrkService _gnevrkService;
		private readonly ICradrsService _cradrsService;
		private readonly ISpftipService _spftipService;
		private readonly ISpfbasService _spfbasService;
		private readonly ISpfharService _spfharService;
		private readonly IIkpersService _ikpersService;
		private readonly IStkfytService _stkfytService;
		private readonly IStkfiyService _stkfiyService;
		private readonly IXXService _xxService;

		public ApiManager(IGnService gnService, IGntipiService gntipiService, IGnthrkService gnthrkService, IStdepoService stdepoService,
			ISthrktService sthrktService, IShsrvsService shsrvsService, IGnkullService gnkullService, ICrcariService crcariService,
			IGnevrkService gnevrkService, ICradrsService cradrsService, IGnlkhrService gnlkhrService, ICrytklService crytklService,
			ISpftipService spftipService, ISpfbasService spfbasService, ISpfharService spfharService, IIkpersService ikpersService,
			IStkfytService stkfytService, IStkfiyService stkfiyService, IXXService xxService)
		{
			_gnService = gnService;
			_gnkullService = gnkullService;
			_gnthrkService = gnthrkService;
			_stdepoService = stdepoService;
			_sthrktService = sthrktService;
			_shsrvsService = shsrvsService;
			_gntipiService = gntipiService;
			_crcariService = crcariService;
			_gnevrkService = gnevrkService;
			_cradrsService = cradrsService;
			_gnlkhrService = gnlkhrService;
			_crytklService = crytklService;
			_spftipService = spftipService;
			_spfbasService = spfbasService;
			_spfharService = spfharService;
			_ikpersService = ikpersService;
			_stkfytService = stkfytService;
			_stkfiyService = stkfiyService;
			_xxService = xxService;
		}

		public List<string> GetCariTamAdres(Global global, string crkodu, out List<string> adresSeparate)
		{
			List<string> adresList = new List<string>();
			adresSeparate = new List<string>();

			var gntipiList = _gntipiService.Ncch_GetByHareketTable_NLog(global, "GNLKHR", false).Items;
			var ulkeTip = gntipiList.Find(t => t.TEKNAD == "ULKEKD").TIPKOD;
			var sehirTip = gntipiList.Find(t => t.TEKNAD == "SEHRKD").TIPKOD;
			var ilceTip = gntipiList.Find(t => t.TEKNAD == "ILCEKD").TIPKOD;
			var semtTip = gntipiList.Find(t => t.TEKNAD == "SEMTKD").TIPKOD;
			var mahalleTip = gntipiList.Find(t => t.TEKNAD == "MAHAKD").TIPKOD;

			List<CRADRS> cradrsList = _cradrsService.Cch_GetListByCariKod_NLog(global, crkodu, false).Items;
			foreach (CRADRS cradrs in cradrsList)
			{
				string ulke = string.IsNullOrEmpty(cradrs.ULKEKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, ulkeTip, cradrs.ULKEKD, false).Nesne.TANIMI;
				string sehir = string.IsNullOrEmpty(cradrs.SEHRKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, sehirTip, cradrs.SEHRKD.Length == 1 ? "0" + cradrs.SEHRKD : cradrs.SEHRKD, false).Nesne.TANIMI + " ";
				string ilce = string.IsNullOrEmpty(cradrs.ILCEKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, ilceTip, cradrs.ILCEKD, false).Nesne.TANIMI + " ";
				string semt = string.IsNullOrEmpty(cradrs.SEMTKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, semtTip, cradrs.SEMTKD, false).Nesne.TANIMI + " / ";
				string mahalle = string.IsNullOrEmpty(cradrs.MAHAKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, mahalleTip, cradrs.MAHAKD, false).Nesne.TANIMI + " ";
				string adres = cradrs.ADRESS + " ";

				string tamAdres = mahalle + adres + ilce + semt + sehir + ulke;

				adresList.Add(tamAdres);

				adresSeparate.Add(ulke);
				adresSeparate.Add(sehir);
				adresSeparate.Add(ilce);
				adresSeparate.Add(semt);
				adresSeparate.Add(mahalle);
				adresSeparate.Add(adres);
			}

			return adresList;
		}

		public string Ncch_GetStokRapor_NLog(Global global, bool withPrice = false, bool yetkiKontrol = false)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var teknads = new List<string>() { "MALGKD", "STANKD", "STALKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
			List<TipHareketListModel> malGrubuList = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
			List<TipHareketListModel> stokAnaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
			List<TipHareketListModel> stokAltGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();

			List<Dictionary<string, object>> stokMiktarDicList = new List<Dictionary<string, object>>();
			List<Dictionary<string, object>> stokMiktarByPartiDicList = new List<Dictionary<string, object>>();

			List<StdepoStokMiktarModel> stokMiktarList = new List<StdepoStokMiktarModel>();
			List<SthrktMiktarByPartiModel> stokMiktarByPartiList = new List<SthrktMiktarByPartiModel>();
			stokMiktarList = _stdepoService.GetStokMiktarRapor(global, yetkiKontrol: false).Items;
			if (stokMiktarList != null && stokMiktarList.Count > 0)
			{
				List<STKFIY> fiyatList = new List<STKFIY>();
				if (withPrice)
				{
					fiyatList = _stkfiyService.Cch_GetListByStfyno_NLog(global, 4, false).Items; //Şimdilik Nesto için 4 nolu fiyat listesi geliyor. Parametrik olacak
				}

				stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global, yetkiKontrol: false).Items;

				foreach (StdepoStokMiktarModel model in stokMiktarList)
				{
					if (!string.IsNullOrEmpty(model.MALGKD)) model.MALGKD = malGrubuList.First(m => m.HARKOD == model.MALGKD).TANIMI;
					if (!string.IsNullOrEmpty(model.STALKD)) model.STALKD = stokAltGrupList.First(m => m.HARKOD == model.STALKD).TANIMI;
					if (!string.IsNullOrEmpty(model.STANKD)) model.STANKD = stokAnaGrupList.First(m => m.HARKOD == model.STANKD).TANIMI;

					if (withPrice)
					{
						STKFIY stkfiy = fiyatList.Find(f => f.STKODU == model.STKODU);
						if (stkfiy != null)
						{
							model.GFIYAT = stkfiy.GFIYAT;
							model.DVCNKD = stkfiy.DVCNKD;
						}
					}

					var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(model);
					objDic.Remove("MPPRTB");
					objDic.Remove("SAPRTB");
					objDic.Remove("SADEGK");
					objDic.Remove("MIPGOS");
					objDic.Remove("EMNSTK");

					stokMiktarDicList.Add(objDic);
				}
			}

			Dictionary<string, object> dic = new Dictionary<string, object>();

			dic.Add("StokMiktarList", stokMiktarDicList);
			dic.Add("StokMiktarByPartiList", stokMiktarByPartiDicList);

			string response = JsonConvert.SerializeObject(dic);
			return response;
		}

		public string Ncch_GetSiparisFisTipList_NLog(Global global, bool yetkiKontrol = false)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			List<SPFTIP> spftipList = _spftipService.Cch_GetList_NLog(global, yetkiKontrol).Items;
			List<STKFYT> stkfytList = _stkfytService.Cch_GetList_NLog(global, yetkiKontrol).Items;

			Dictionary<string, object> dic = new Dictionary<string, object>();
			dic.Add("spftipList", spftipList);
			dic.Add("stkfytList", stkfytList);

			string response = JsonConvert.SerializeObject(dic);
			return response;
		}

		public string Ncch_GetServisParametreInfo_NLog(Global global, bool yetkiKontrol = false)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var teknads = new List<string>() { "SRTRKD", "SRDRKD", "GRDRKD", "MKDRKD", "STANKD", "STALKD", "TKDRKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

			List<TipHareketMinListModel> servisTuruList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> servisDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRDRKD").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> garantiDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> makinaDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> makinaKategoriList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").Where(m => m.EXTRA1 == "SSHMBL").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> makinaModelList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").Where(m => m.EXTRA1 == "SSHMBL").MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<TipHareketMinListModel> teklifDurumList = teknadsResponse.Items.Where(w => w.TEKNAD == "TKDRKD").MapTo<TipHareketListModel, TipHareketMinListModel>();

			List<TipHareketMinListModel> ulkeList = _gnlkhrService.Cch_TipHareketListGetir(global, "001", false).Items.MapTo<TipHareketListModel, TipHareketMinListModel>();
			List<KullaniciMinModel> kullaniciMinList = _gnkullService.Ncch_GetKullaniciMinData_NLog(global, false).Items;

			List<CariKodAdModel> cariList = _crcariService.Ncch_GetCariKodAdList_NLog(global, "0", false).Items; //Alıcılar
			List<CariKodAdModel> adayCariList = _crcariService.Ncch_GetCariKodAdList_NLog(global, "9", false).Items; //Aday Cariler
			if (adayCariList.Count > 0)
			{
				cariList.AddRange(adayCariList);
			}

			List<CariYetkiliModel> cariYetkiliList =
				_crytklService.Ncch_GetCariYetkiliList_NLog(global, yetkiKontrol: false).Items;

			Dictionary<string, object> dic = new Dictionary<string, object>();
			dic.Add("servisTuruList", servisTuruList);
			dic.Add("servisDurumuList", servisDurumuList);
			dic.Add("garantiDurumuList", garantiDurumuList);
			dic.Add("makinaDurumuList", makinaDurumuList);
			dic.Add("makinaKategoriList", makinaKategoriList);
			dic.Add("makinaModelList", makinaModelList);
			dic.Add("teklifDurumList", teklifDurumList);

			dic.Add("ulkeList", ulkeList);
			dic.Add("kullaniciMinList", kullaniciMinList);

			dic.Add("cariList", cariList);
			dic.Add("cariYetkiliList", cariYetkiliList);

			string response = JsonConvert.SerializeObject(dic);
			return response;
		}

		public string Ncch_GetServisKartList_NLog(Global global, SshParamModel param, bool yetkiKontrol = false)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var teknads = new List<string>() { "SRTRKD", "SRDRKD", "GRDRKD", "MKDRKD", "STALKD", "MKNKTG" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
			List<TipHareketListModel> servisTuruList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").ToList();
			List<TipHareketListModel> servisDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "SRDRKD").ToList();
			List<TipHareketListModel> garantiDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").ToList();
			List<TipHareketListModel> makinaDurumuList = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").ToList();
			var makineKategoriTip = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MKNKTG", false).Nesne;
			List<GNTIPI> makinaKategoriList = _gntipiService.Ncch_GetListByUstTipKod_NLog(global, makineKategoriTip.TIPKOD, false).Items;

			List<Dictionary<string, object>> servistKartiDicList = new List<Dictionary<string, object>>();

			List<SHSRVS> servisKartList = _shsrvsService.Cch_GetListByParam_NLog(param, global, yetkiKontrol).Items;
			if (servisKartList != null && servisKartList.Count > 0)
			{
				servisKartList = servisKartList.OrderByDescending(s => s.Id).ToList();
				foreach (SHSRVS model in servisKartList)
				{
					//if (!string.IsNullOrEmpty(model.SRVDRM))
					//{
					//	TipHareketListModel servisDurum = servisDurumuList.FirstOrDefault(m => m.HARKOD == model.SRVDRM);
					//	if (servisDurum == null) servisDurum = servisDurumuList.First(m => m.TANIMI == model.SRVDRM);
					//	model.SRVDRM = servisDurum.TANIMI;
					//}
					//if (!string.IsNullOrEmpty(model.SRVTUR)) model.SRVTUR = servisTuruList.FirstOrDefault(m => m.HARKOD == model.SRVTUR).TANIMI;
					//if (!string.IsNullOrEmpty(model.GRNDRM)) model.GRNDRM = garantiDurumuList.FirstOrDefault(m => m.HARKOD == model.GRNDRM).TANIMI;
					//if (!string.IsNullOrEmpty(model.MKNDRM)) model.MKNDRM = makinaDurumuList.FirstOrDefault(m => m.HARKOD == model.MKNDRM).TANIMI;

					var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(model);
					servistKartiDicList.Add(objDic);
				}
			}

			Dictionary<string, object> dic = new Dictionary<string, object>();
			dic.Add("ServisKartList", servistKartiDicList);

			string response = JsonConvert.SerializeObject(dic);
			return response;
		}

		public string Ncch_GetSpfbasList_NLog(Global global, SiparisParamModel param, bool yetkiKontrol = false)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			List<Dictionary<string, object>> spfbasDicList = new List<Dictionary<string, object>>();

			List<SPFBAS> spfbasList = _spfbasService.Cch_GetListByParam_NLog(param, global, false).Items;
			if (spfbasList != null && spfbasList.Count > 0)
			{
				foreach (SPFBAS model in spfbasList)
				{
					var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(model);
					spfbasDicList.Add(objDic);
				}
			}

			Dictionary<string, object> dic = new Dictionary<string, object>();
			dic.Add("SpfbasList", spfbasDicList);

			string response = JsonConvert.SerializeObject(dic);
			return response;
		}

		public async Task<string> Ncch_SaveServisKart_NLog(Global global, Dictionary<string, object> shsrvsDictionary, bool yetkiKontrol = false)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			StandardResponse<SHSRVS> response = new StandardResponse<SHSRVS>();
			response.Status = ResponseStatusEnum.OK;

			var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(shsrvsDictionary["data"].ToString());
			var json = JsonConvert.SerializeObject(data);
			var dataMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			try
			{
				if (dataMap["Id"] == null || dataMap["Id"].ToString() == "0")
				{
					dataMap["Id"] = 0;
					dataMap["SIRKID"] = global.SirketId;
					dataMap["BELTRH"] = DateTime.Now;
					dataMap["CLSYNC"] = true;
					dataMap["SRSYNC"] = false;
					dataMap["ETARIH"] = DateTime.Now;
					dataMap["ACTIVE"] = true;
					dataMap["SLINDI"] = false;
					dataMap["CHKCTR"] = false;

					string tlpacan = dataMap["TLPACN"].ToString();
					var gnkull = _gnkullService.Cch_GetByUserKod_NLog(tlpacan, global).Nesne;
					dataMap["TLPACN"] = gnkull.GNNAME + " " + gnkull.GNSNAM;
					dataMap["EKKULL"] = gnkull.KULKOD;

					json = JsonConvert.SerializeObject(dataMap);
					SHSRVS shsrvs = JsonConvert.DeserializeObject<SHSRVS>(json);

					var evrakmodel = new EvrakNoUretParamModel();
					evrakmodel.TabloAdi = "SHSRVS";
					evrakmodel.TeknikAd = "BELGEN";
					evrakmodel.IslemTur = 0;
					var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

					if (evrakResponse.Status != ResponseStatusEnum.OK)
					{
						throw new BusinessException(evrakResponse.Message);
					}

					shsrvs.BELGEN = evrakResponse.Nesne;

					List<string> adresSeperate;
					List<string> adresList = GetCariTamAdres(global, shsrvs.CRKODU, out adresSeperate);
					shsrvs.CRADRS = adresList.Count > 0 ? adresList[0] : ".";

					shsrvs.SRVDRM = "01"; //Başlamadı

					response = _shsrvsService.Ncch_Add_NLog(shsrvs, global);

					var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(response.Nesne);
					dic.Add("SavedKart", objDic);
				}
				else
				{
					if (dataMap.ContainsKey("STRSTP") && dataMap["STRSTP"] != null && !dataMap["STRSTP"].ToString().Contains("null")) //Servis uygulaması İş emri start stop zamanı
					{
						var strstpString = dataMap["STRSTP"].ToString();
						var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(strstpString);
						var dictList = new List<Dictionary<string, object>>();
						foreach (var obj in list) dictList.Add(obj);

						dataMap["STRSTP"] = dictList;
					}

					var dateList = dataMap.Where(d => d.Value is DateTime).ToList();
					foreach (KeyValuePair<string, object> kvp in dateList)
					{
						dataMap[kvp.Key] = DateTime.SpecifyKind((DateTime)kvp.Value, DateTimeKind.Utc); ;
					}

					string strstp = "";

					var settings = new JsonSerializerSettings
					{
						Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
						Formatting = Formatting.None
					};

					strstp = JsonConvert.SerializeObject(dataMap["STRSTP"], settings);
					if (strstp.Contains("null")) strstp = null;
					dataMap.Remove("STRSTP");

					json = JsonConvert.SerializeObject(dataMap);

					SHSRVS incomingShsrvs = JsonConvert.DeserializeObject<SHSRVS>(json);
					SHSRVS shsrvs = _shsrvsService.Ncch_GetById_NLog(incomingShsrvs.Id, global, false).Nesne;
					if (shsrvs != null)
					{
						shsrvs.STRSTP = strstp;
						shsrvs.PRBTSP = incomingShsrvs.PRBTSP;
						shsrvs.AKSYON = incomingShsrvs.AKSYON;
						shsrvs.SRVDRM = incomingShsrvs.SRVDRM;
						shsrvs.SRBSTR = incomingShsrvs.SRBSTR;
						shsrvs.SRSYNC = incomingShsrvs.SRSYNC;
						shsrvs.SRBTTR = incomingShsrvs.SRBTTR;
						shsrvs.PRIMZA = incomingShsrvs.PRIMZA;
						shsrvs.MSIMZA = incomingShsrvs.MSIMZA;
						shsrvs.SRPRID = incomingShsrvs.SRPRID;
						shsrvs.KULPRC = incomingShsrvs.KULPRC;

						GNKULL gnkull = null;
						if (incomingShsrvs.SRPRID != null)
						{
							gnkull = _gnkullService.Ncch_GetByPersId_NLog(incomingShsrvs.SRPRID.Value, global, false)
								.Nesne;
							shsrvs.SRVPRS = gnkull.GNNAME + " " + gnkull.GNSNAM;
						}

						if (incomingShsrvs.SRVDRM == "03")
						{
							List<STHRKT> sthrktList = new List<STHRKT>();

							var lst = _sthrktService.Ncch_GetListKalemByUstBelgeNo_NLog(global, shsrvs.BELGEN, false).Items;

							if (!string.IsNullOrEmpty(incomingShsrvs.KULPRC) && (lst == null || lst.Count == 0))
							{
								var kulprcList = JsonConvert.DeserializeObject<List<TabletStokHareket>>(incomingShsrvs.KULPRC);

								var hareketResponse = new StandardResponse();
								var model = new StokHareketModel();
								model.Baslik = new STHBAS();

								model.Baslik.BELTRH = DateTime.Now;
								model.Baslik.CRKODU = incomingShsrvs.CRKODU;
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
										CRKODU = incomingShsrvs.CRKODU,
										SATIRN = satirNo,
										STKODU = kulprc.STKODU,
										STKNAM = kulprc.STKNAM,
										GRMKTR = kulprc.MIKTAR,
										GNMKTR = kulprc.MIKTAR,
										GROLBR = kulprc.OLCUKD,
										OLCUKD = kulprc.OLCUKD,
										CKDEPO = kulprc.DPKODU,
										GNTUTR = kulprc.GFIYAT * kulprc.MIKTAR,
										DVCNKD = kulprc.DVCNKD,
										GNACIK = "Servis modülü depo çıkışı",
										USTBLG = incomingShsrvs.BELGEN,
									};

									model.Kalemler.Add(sthrkt);
									sthrktList.Add(sthrkt);

									satirNo++;
								}

								hareketResponse = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
								if (hareketResponse.Status != ResponseStatusEnum.OK) throw new Exception(hareketResponse.Message);
							}
						}
						response = _shsrvsService.Ncch_UpdateFromApi_Log(shsrvs, shsrvs, global);

						var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(response.Nesne);
						dic.Add("SavedKart", objDic);
					}
					else
					{
						dic.Add("ERROR", "Servis kartı bulunamadı!");
					}
				}
			}
			catch (Exception e)
			{
				dic.Add("ERROR", e.Message + "\r\n" + e.StackTrace);
			}

			return JsonConvert.SerializeObject(dic);
		}

		public string Ncch_SaveCariYetkili_NLog(Global global, Dictionary<string, object> yetkiliDictionary, bool yetkiKontrol = false)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			StandardResponse<CRYTKL> response = new StandardResponse<CRYTKL>();
			response.Status = ResponseStatusEnum.OK;

			var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(yetkiliDictionary["data"].ToString());
			var json = JsonConvert.SerializeObject(data);
			var dataMap = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			try
			{
				if (dataMap["Id"] == null || dataMap["Id"].ToString() == "0")
				{
					dataMap["Id"] = 0;
					dataMap["SIRKID"] = global.SirketId;
					dataMap["ETARIH"] = DateTime.Now;
					dataMap["ACTIVE"] = true;
					dataMap["SLINDI"] = false;
					dataMap["CHKCTR"] = false;
					dataMap["EKKULL"] = global.UserKod;

					json = JsonConvert.SerializeObject(dataMap);
					CRYTKL crytkl = JsonConvert.DeserializeObject<CRYTKL>(json);

					response = _crytklService.Ncch_Add_NLog(crytkl, global);

					var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(response.Nesne);
					dic.Add("SavedCariYetkili", objDic);
				}
				else
				{
					json = JsonConvert.SerializeObject(dataMap);

					CRYTKL incomingCrytkl = JsonConvert.DeserializeObject<CRYTKL>(json);
					CRYTKL crytkl = _crytklService.Ncch_GetById_NLog(incomingCrytkl.Id, global, false).Nesne;
					if (crytkl != null)
					{
						crytkl.YETADI = incomingCrytkl.YETADI;
						crytkl.YETSOY = incomingCrytkl.YETSOY;
						crytkl.YETUNV = incomingCrytkl.YETUNV;
						crytkl.ISYTEL = incomingCrytkl.ISYTEL;

						response = _crytklService.Ncch_Update_Log(crytkl, crytkl, global);

						var objDic = Core.Utilities.Converters.Convert.ObjectToDictionary(response.Nesne);
						dic.Add("SavedCariYetkili", objDic);
					}
					else
					{
						dic.Add("ERROR", "Servis kartı bulunamadı!");
					}
				}

			}
			catch (Exception e)
			{
				dic.Add("ERROR", e.Message + "\r\n" + e.StackTrace);
			}

			return JsonConvert.SerializeObject(dic);
		}

		class TabletStokHareket
		{
			public string STKODU;
			public string STKNAM;
			public string OLCUKD;
			public int MIKTAR;
			public string DPKODU;
			public decimal GFIYAT;
			public string DVCNKD;
		}
	}
}
