using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.GlobalStaticsVariables;

namespace BPS.Windows.Forms
{
    public partial class FrmMalzemeIhtiyac : Form
    {
        private Global _global;
        private List<StkartMiktar> _stkartList;

        private int maxAltId = 0;
        private List<StdepoStokMiktarModel> stokMiktarList = new List<StdepoStokMiktarModel>();
        private List<SthrktMiktarByPartiModel> stokMiktarByPartiList = new List<SthrktMiktarByPartiModel>();
        private List<SaAcikSiparisMiktar> saSiparisMiktarList = new List<SaAcikSiparisMiktar>();
        private List<SaAcikSiparisMiktar> saTalepMiktarList = new List<SaAcikSiparisMiktar>();

        private readonly IUastbgService _uastbgService;
        private readonly IUragacService _uragacService;
        private readonly ISthrktService _sthrktService;
        private readonly IStdepoService _stdepoService;
        private readonly ISpfharService _spfharService;

        public FrmMalzemeIhtiyac(List<StkartMiktar> stkartList, Global global)
        {
            _stkartList = stkartList;
            _global = global;

            _uastbgService = InstanceFactory.GetInstance<IUastbgService>();
            _uragacService = InstanceFactory.GetInstance<IUragacService>();
            _sthrktService = InstanceFactory.GetInstance<ISthrktService>();
            _stdepoService = InstanceFactory.GetInstance<IStdepoService>();
            _spfharService = InstanceFactory.GetInstance<ISpfharService>();

            InitializeComponent();
        }

        private void FrmMalzemeIhtiyac_Load(object sender, EventArgs e)
        {
            GetStokMiktar();
            GetSaSiparisTalepMiktar();
            GetMalzemeIhtiyac();
        }

        private void GetStokMiktar()
        {
            stokMiktarList = _stdepoService.GetStokMiktarRaporWithMipgos(_global, false).Items;
            stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(_global, yetkiKontrol: false).Items;
        }

        private void GetSaSiparisTalepMiktar()
        {
            saSiparisMiktarList = _spfharService.Ncch_GetAcikSaSiparisAndTalepMiktar_NLog(_global, false).Items;
            if (saSiparisMiktarList != null && saSiparisMiktarList.Count > 0)
            {
                saTalepMiktarList = saSiparisMiktarList.Where(s => s.SPHRTP == 3).ToList(); //Satınalma Talepleri
                if (saTalepMiktarList != null && saTalepMiktarList.Count > 0)
                {
                    saSiparisMiktarList.RemoveAll(s => s.SPHRTP == 3);
                }
            }
        }

        private void GetMalzemeIhtiyac()
        {
            DataTable stokTable = new DataTable();
            stokTable.Columns.Add("StokKodu", typeof(string));
            stokTable.Columns.Add("StokAdi", typeof(string));
            stokTable.Columns.Add("Miktar", typeof(decimal));
            stokTable.Columns.Add("OlcuBirimi", typeof(string));
            
            List<UrunAgaciTreeList> fullList = new List<UrunAgaciTreeList>();

            foreach (StkartMiktar stkartMiktar in _stkartList)
            {
                STKART stkart = stkartMiktar.stkart;

                DataRow row = stokTable.NewRow();
                row["StokKodu"] = stkart.STKODU;
                row["StokAdi"] = stkart.STKNAM;
                row["Miktar"] = stkartMiktar.miktar;
                row["OlcuBirimi"] = stkart.OLCUKD;
                stokTable.Rows.Add(row);

                maxAltId = 0;
                string uaKodu = _uragacService.GetMaxUrunAgaciKodu(stkart.STKODU, "1", _global).Nesne;

                if (string.IsNullOrEmpty(uaKodu))
                {
                    MessageBox.Show(stkart.STKODU + " - " + stkart.STKNAM + " için ürün ağacı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }

                List<UrunAgaciTreeList> uaList = _uragacService.Ncch_GetUrunAgaci_NLog(uaKodu, _global).Items;

                maxAltId = uaList.Max(u => u.AltId);

                List<UrunAgaciTreeList> uaSubLevels = new List<UrunAgaciTreeList>();
                foreach (UrunAgaciTreeList ua in uaList)
                {
                    List<UrunAgaciTreeList> subLevels = new List<UrunAgaciTreeList>();

                    if (!ua.FantomKalemi)
                    {
                        ua.Miktar *= stkartMiktar.miktar;
                        GetUrunAgaciSubLevel(subLevels, ua.StokKodu, ua.RevizyonNo, ua.AltId, ua.Seviye + 1, stkartMiktar.miktar);
                        uaSubLevels.AddRange(subLevels);
                    }
                    if (uaSubLevels.Count > 0) maxAltId = uaSubLevels.Max(u => u.AltId);
                }

                uaList.AddRange(uaSubLevels);
                fullList.AddRange(uaList);
            }

            gridControl2.DataSource = stokTable;

            fullList = fullList.OrderBy(u => u.StokKodu).ToList();
            foreach (UrunAgaciTreeList stok in fullList)
            {
                var found = stokMiktarList.FirstOrDefault(s => s.STKODU == stok.StokKodu);
                if (found != null) stok.StokAdi = found.STKNAM;
            }
            DataTable urunAgaciTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(fullList);

            urunAgaciTable.Columns.Remove("Seviye");
            urunAgaciTable.Columns.Remove("ParentId");
            urunAgaciTable.Columns.Remove("AltId");
            urunAgaciTable.Columns.Remove("RevizyonNo");
            urunAgaciTable.Columns.Remove("UrunAgaciKodu");
            urunAgaciTable.Columns.Remove("Silme");
            urunAgaciTable.Columns.Remove("UretimYeriKodu");
            urunAgaciTable.Columns.Remove("KalemTipi");
            urunAgaciTable.Columns.Remove("FantomKalemi");
            urunAgaciTable.Columns.Remove("Siralama");
            urunAgaciTable.Columns.Remove("SabitMiktar");
            urunAgaciTable.Columns.Remove("StokResim");
            urunAgaciTable.Columns.Remove("MasterStokKodu");
            urunAgaciTable.Columns.Remove("ParentStokKodu");
            urunAgaciTable.Columns.Remove("AltUrunAgaciKodu");
            urunAgaciTable.Columns.Remove("MalzemeTuru");

            urunAgaciTable.Columns.Add("Depo", typeof(decimal));
            urunAgaciTable.Columns.Add("AcikSiparis", typeof(decimal));
            urunAgaciTable.Columns.Add("AcikTalep", typeof(decimal));
            urunAgaciTable.Columns.Add("Ihtiyac", typeof(decimal));

            if (urunAgaciTable.Rows.Count > 0)
            {
                DataTable uaCloneTable = urunAgaciTable.Clone();
                DataTable sumTable = urunAgaciTable.AsEnumerable()
                    .GroupBy(row => new
                    {
                        StokKodu = row["StokKodu"],
                        StokAdi = row["StokAdi"],
                        OlcuBirimiKodu = row["OlcuBirimiKodu"],
                    })
                    .Select(g =>
                    {
                        var row = uaCloneTable.NewRow();

                        row["StokKodu"] = g.Key.StokKodu;
                        row["StokAdi"] = g.Key.StokAdi;
                        row["OlcuBirimiKodu"] = g.Key.OlcuBirimiKodu;
                        row["Miktar"] = g.Sum(x => x.Field<decimal>("Miktar"));

                        return row;

                    }).CopyToDataTable();

                foreach (DataRow row in sumTable.Rows)
                {
                    string stokKodu = row["StokKodu"].ToString();
                    decimal miktar = Convert.ToDecimal(row["Miktar"]);
                    decimal depoMiktar = 0;
                    decimal acikSiparisMiktar = 0;
                    decimal acikTalepMiktar = 0;
                    decimal ihtiyac = 0;

                    var depo = stokMiktarList.FirstOrDefault(s => s.STKODU == stokKodu);
                    if (depo != null) row["Depo"] = depoMiktar = depo.USESTK;

                    var acikSiparis = saSiparisMiktarList.FirstOrDefault(s => s.STKODU == stokKodu);
                    if (acikSiparis != null) row["AcikSiparis"] = acikSiparisMiktar = acikSiparis.GNMKTR ?? 0;

                    var acikTalep = saTalepMiktarList.FirstOrDefault(s => s.STKODU == stokKodu);
                    if (acikTalep != null) row["AcikTalep"] = acikTalepMiktar = acikTalep.GNMKTR ?? 0;

                    ihtiyac = miktar - (depoMiktar + acikSiparisMiktar + acikTalepMiktar);
                    if (ihtiyac > 0) row["Ihtiyac"] = ihtiyac;
                }

                gridControl1.DataSource = sumTable;
                gridView1.BestFitColumns();
            }
        }

        private void GetUrunAgaciSubLevel(List<UrunAgaciTreeList> dtSubLevels, string stokKodu, string revizyonNo, int parentId, int seviye, int miktarCarpan)
        {
            string uaKodu = _uastbgService.Ncch_GetUrunAgaciKodu_NLog(stokKodu, revizyonNo, "1", _global).Nesne;
            if (uaKodu == null) return;

            List<UrunAgaciTreeList> uaList = _uragacService.Ncch_GetUrunAgaci_NLog(uaKodu, _global).Items;

            foreach (UrunAgaciTreeList ua in uaList)
            {
                maxAltId++;
                ua.ParentId = parentId;
                ua.AltId = maxAltId;
                ua.Seviye = seviye;
                ua.MalzemeTuru = "";
                ua.Miktar *= miktarCarpan;
                dtSubLevels.Add(ua);
                GetUrunAgaciSubLevel(dtSubLevels, ua.StokKodu, ua.RevizyonNo, maxAltId, seviye + 1, miktarCarpan);
            }
        }
    }

    public class StkartMiktar
    {
        public STKART stkart;
        public int miktar = 1;
    }
}
