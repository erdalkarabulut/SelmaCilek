using System;
using System.Data.Entity;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.CM;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CM;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.CR;
using Bps.BpsBase.Entities.Concrete.FY;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.FY;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.GN;
using Bps.BpsBase.Entities.Concrete.IK;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IK;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.IS;
using Bps.BpsBase.Entities.Concrete.KS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.KS;
using Bps.BpsBase.Entities.Concrete.MH;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.MH;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SA;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SH;
using Bps.BpsBase.Entities.Concrete.SN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.ST;
using Bps.BpsBase.Entities.Concrete.TS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.TS;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.UR;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.Mappings.WM;

namespace Bps.BpsBase.DataAccess.Concrete.Context
{
    public class BpsContext : DbContext
    {
        public BpsContext()
        {
            Database.SetInitializer<BpsContext>(null);
        }
        public DbSet<CMAKSN> Cmaksn { get; set; }
        public DbSet<CMKART> Cmkart { get; set; }
        public DbSet<CRADRS> Cradrs { get; set; }
        public DbSet<CRBANK> Crbank { get; set; }
        public DbSet<CRCAFY> Crcafy { get; set; }
        public DbSet<CRCARI> Crcari { get; set; }
        public DbSet<CRYTKL> Crytkl { get; set; }
        public DbSet<DOVKUR> Dovkur { get; set; }
        public DbSet<FYShopifyImage> Fyshopifyimage { get; set; }
        public DbSet<FYShopifyOption> Fyshopifyoption { get; set; }
        public DbSet<FYShopifyOrder> Fyshopifyorder { get; set; }
        public DbSet<FYShopifyProduct> Fyshopifyproduct { get; set; }
        public DbSet<FYShopifyVariant> Fyshopifyvariant { get; set; }
        public DbSet<GNBNHR> Gnbnhr { get; set; }
        public DbSet<GNDPNO> Gndpno { get; set; }
        public DbSet<GNDPTN> Gndptn { get; set; }
        public DbSet<GNDPTP> Gndptp { get; set; }
        public DbSet<GNDPZM> Gndpzm { get; set; }
        public DbSet<GNEVRK> Gnevrk { get; set; }
        public DbSet<GNFILE> Gnfile { get; set; }
        public DbSet<GNKLOP> Gnklop { get; set; }
        public DbSet<GNKOSL> Gnkosl { get; set; }
        public DbSet<GNKUKR> Gnkukr { get; set; }
        public DbSet<GNKULL> Gnkull { get; set; }
        public DbSet<GNKXML> Gnkxml { get; set; }
        public DbSet<GNLKHR> Gnlkhr { get; set; }
        public DbSet<GNMENU> Gnmenu { get; set; }
        public DbSet<GNMESJ> Gnmesj { get; set; }
        public DbSet<GNOPHR> Gnophr { get; set; }
        public DbSet<GNOPTP> Gnoptp { get; set; }
        public DbSet<GNORGA> Gnorga { get; set; }
        public DbSet<GNORHR> Gnorhr { get; set; }
        public DbSet<GNTHRK> Gnthrk { get; set; }
        public DbSet<GNTIPI> Gntipi { get; set; }
        public DbSet<GNYETB> Gnyetb { get; set; }
        public DbSet<GNYETK> Gnyetk { get; set; }
        public DbSet<IKPERS> Ikpers { get; set; }
        public DbSet<ISPLAN> Isplan { get; set; }
        public DbSet<ISPLST> Isplst { get; set; }
        public DbSet<ISREVZ> Isrevz { get; set; }
        public DbSet<ISRVHR> Isrvhr { get; set; }
        public DbSet<ISURBG> Isurbg { get; set; }
        public DbSet<ISYROP> Isyrop { get; set; }
        public DbSet<ISYRTN> Isyrtn { get; set; }
        public DbSet<KSKASA> Kskasa { get; set; }
        public DbSet<LOCKED> Locked { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<MHHSPL> Mhhspl { get; set; }
        public DbSet<SADEGA> Sadega { get; set; }
        public DbSet<SHSRVS> Shsrvs { get; set; }
        public DbSet<SIRKET> Sirket { get; set; }
        public DbSet<SNIFBA> Snifba { get; set; }
        public DbSet<SNKRTR> Snkrtr { get; set; }
        public DbSet<SNKRTY> Snkrty { get; set; }
        public DbSet<SNSNKR> Snsnkr { get; set; }
        public DbSet<SNTYNN> Sntynn { get; set; }
        public DbSet<SPDKDR> Spdkdr { get; set; }
        public DbSet<SPFBAS> Spfbas { get; set; }
        public DbSet<SPFHAR> Spfhar { get; set; }
        public DbSet<SPFTIP> Spftip { get; set; }
        public DbSet<SPFTOP> Spftop { get; set; }
        public DbSet<SPKOSL> Spkosl { get; set; }
        public DbSet<SPODTB> Spodtb { get; set; }
        public DbSet<SPREZV> Sprezv { get; set; }
        public DbSet<SPUROP> Spurop { get; set; }
        public DbSet<STBDRN> Stbdrn { get; set; }
        public DbSet<STCRKD> Stcrkd { get; set; }
        public DbSet<STDEPO> Stdepo { get; set; }
        public DbSet<STDEPV> Stdepv { get; set; }
        public DbSet<STDPYN> Stdpyn { get; set; }
        public DbSet<STFTIP> Stftip { get; set; }
        public DbSet<STHBAS> Sthbas { get; set; }
        public DbSet<STHRKT> Sthrkt { get; set; }
        public DbSet<STKART> Stkart { get; set; }
        public DbSet<STKFIY> Stkfiy { get; set; }
        public DbSet<STKFYT> Stkfyt { get; set; }
        public DbSet<STKMIH> Stkmih { get; set; }
        public DbSet<STKMIZ> Stkmiz { get; set; }
        public DbSet<STMALT> Stmalt { get; set; }
        public DbSet<STMHSB> Stmhsb { get; set; }
        public DbSet<STNAME> Stname { get; set; }
        public DbSet<STOLCU> Stolcu { get; set; }
        public DbSet<STOPTM> Stoptm { get; set; }
        public DbSet<STSALE> Stsale { get; set; }
        public DbSet<STSERI> Stseri { get; set; }
        public DbSet<STTDTR> Sttdtr { get; set; }
        public DbSet<STUROP> Sturop { get; set; }
        public DbSet<STURYR> Sturyr { get; set; }
        public DbSet<STVMIH> Stvmih { get; set; }
        public DbSet<STVMIZ> Stvmiz { get; set; }
        public DbSet<STVURY> Stvury { get; set; }
        public DbSet<TSFBAS> Tsfbas { get; set; }
        public DbSet<TSFHAR> Tsfhar { get; set; }
        public DbSet<TSFTIP> Tsftip { get; set; }
        public DbSet<UAKLTN> Uakltn { get; set; }
        public DbSet<UAKLTP> Uakltp { get; set; }
        public DbSet<UAMLTY> Uamlty { get; set; }
        public DbSet<UASTBG> Uastbg { get; set; }
        public DbSet<UASTRT> Uastrt { get; set; }
        public DbSet<URAGAC> Uragac { get; set; }
        public DbSet<URAGVR> Uragvr { get; set; }
        public DbSet<URSURE> Ursure { get; set; }
        public DbSet<WMADRS> Wmadrs { get; set; }
        public DbSet<WMADRT> Wmadrt { get; set; }
        public DbSet<WMHRAT> Wmhrat { get; set; }
        public DbSet<WMHRKT> Wmhrkt { get; set; }
        public DbSet<WMNKSB> Wmnksb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CmaksnMap());
            modelBuilder.Configurations.Add(new CmkartMap());
            modelBuilder.Configurations.Add(new CradrsMap());
            modelBuilder.Configurations.Add(new CrbankMap());
            modelBuilder.Configurations.Add(new CrcafyMap());
            modelBuilder.Configurations.Add(new CrcariMap());
            modelBuilder.Configurations.Add(new CrytklMap());
            modelBuilder.Configurations.Add(new DovkurMap());
            modelBuilder.Configurations.Add(new FyshopifyimageMap());
            modelBuilder.Configurations.Add(new FyshopifyoptionMap());
            modelBuilder.Configurations.Add(new FyshopifyorderMap());
            modelBuilder.Configurations.Add(new FyshopifyproductMap());
            modelBuilder.Configurations.Add(new FyshopifyvariantMap());
            modelBuilder.Configurations.Add(new GnbnhrMap());
            modelBuilder.Configurations.Add(new GndpnoMap());
            modelBuilder.Configurations.Add(new GndptnMap());
            modelBuilder.Configurations.Add(new GndptpMap());
            modelBuilder.Configurations.Add(new GndpzmMap());
            modelBuilder.Configurations.Add(new GnevrkMap());
            modelBuilder.Configurations.Add(new GnfileMap());
            modelBuilder.Configurations.Add(new GnklopMap());
            modelBuilder.Configurations.Add(new GnkoslMap());
            modelBuilder.Configurations.Add(new GnkukrMap());
            modelBuilder.Configurations.Add(new GnkullMap());
            modelBuilder.Configurations.Add(new GnkxmlMap());
            modelBuilder.Configurations.Add(new GnlkhrMap());
            modelBuilder.Configurations.Add(new GnmenuMap());
            modelBuilder.Configurations.Add(new GnmesjMap());
            modelBuilder.Configurations.Add(new GnophrMap());
            modelBuilder.Configurations.Add(new GnoptpMap());
            modelBuilder.Configurations.Add(new GnorgaMap());
            modelBuilder.Configurations.Add(new GnorhrMap());
            modelBuilder.Configurations.Add(new GnthrkMap());
            modelBuilder.Configurations.Add(new GntipiMap());
            modelBuilder.Configurations.Add(new GnyetbMap());
            modelBuilder.Configurations.Add(new GnyetkMap());
            modelBuilder.Configurations.Add(new IkpersMap());
            modelBuilder.Configurations.Add(new IsplanMap());
            modelBuilder.Configurations.Add(new IsplstMap());
            modelBuilder.Configurations.Add(new IsrevzMap());
            modelBuilder.Configurations.Add(new IsrvhrMap());
            modelBuilder.Configurations.Add(new IsurbgMap());
            modelBuilder.Configurations.Add(new IsyropMap());
            modelBuilder.Configurations.Add(new IsyrtnMap());
            modelBuilder.Configurations.Add(new KskasaMap());
            modelBuilder.Configurations.Add(new LockedMap());
            modelBuilder.Configurations.Add(new LogsMap());
            modelBuilder.Configurations.Add(new MhhsplMap());
            modelBuilder.Configurations.Add(new SadegaMap());
            modelBuilder.Configurations.Add(new ShsrvsMap());
            modelBuilder.Configurations.Add(new SirketMap());
            modelBuilder.Configurations.Add(new SnifbaMap());
            modelBuilder.Configurations.Add(new SnkrtrMap());
            modelBuilder.Configurations.Add(new SnkrtyMap());
            modelBuilder.Configurations.Add(new SnsnkrMap());
            modelBuilder.Configurations.Add(new SntynnMap());
            modelBuilder.Configurations.Add(new SpdkdrMap());
            modelBuilder.Configurations.Add(new SpfbasMap());
            modelBuilder.Configurations.Add(new SpfharMap());
            modelBuilder.Configurations.Add(new SpftipMap());
            modelBuilder.Configurations.Add(new SpftopMap());
            modelBuilder.Configurations.Add(new SpkoslMap());
            modelBuilder.Configurations.Add(new SpodtbMap());
            modelBuilder.Configurations.Add(new SprezvMap());
            modelBuilder.Configurations.Add(new SpuropMap());
            modelBuilder.Configurations.Add(new StbdrnMap());
            modelBuilder.Configurations.Add(new StcrkdMap());
            modelBuilder.Configurations.Add(new StdepoMap());
            modelBuilder.Configurations.Add(new StdepvMap());
            modelBuilder.Configurations.Add(new StdpynMap());
            modelBuilder.Configurations.Add(new StftipMap());
            modelBuilder.Configurations.Add(new SthbasMap());
            modelBuilder.Configurations.Add(new SthrktMap());
            modelBuilder.Configurations.Add(new StkartMap());
            modelBuilder.Configurations.Add(new StkfiyMap());
            modelBuilder.Configurations.Add(new StkfytMap());
            modelBuilder.Configurations.Add(new StkmihMap());
            modelBuilder.Configurations.Add(new StkmizMap());
            modelBuilder.Configurations.Add(new StmaltMap());
            modelBuilder.Configurations.Add(new StmhsbMap());
            modelBuilder.Configurations.Add(new StnameMap());
            modelBuilder.Configurations.Add(new StolcuMap());
            modelBuilder.Configurations.Add(new StoptmMap());
            modelBuilder.Configurations.Add(new StsaleMap());
            modelBuilder.Configurations.Add(new StseriMap());
            modelBuilder.Configurations.Add(new SttdtrMap());
            modelBuilder.Configurations.Add(new SturopMap());
            modelBuilder.Configurations.Add(new SturyrMap());
            modelBuilder.Configurations.Add(new StvmihMap());
            modelBuilder.Configurations.Add(new StvmizMap());
            modelBuilder.Configurations.Add(new StvuryMap());
            modelBuilder.Configurations.Add(new TsfbasMap());
            modelBuilder.Configurations.Add(new TsfharMap());
            modelBuilder.Configurations.Add(new TsftipMap());
            modelBuilder.Configurations.Add(new UakltnMap());
            modelBuilder.Configurations.Add(new UakltpMap());
            modelBuilder.Configurations.Add(new UamltyMap());
            modelBuilder.Configurations.Add(new UastbgMap());
            modelBuilder.Configurations.Add(new UastrtMap());
            modelBuilder.Configurations.Add(new UragacMap());
            modelBuilder.Configurations.Add(new UragvrMap());
            modelBuilder.Configurations.Add(new UrsureMap());
            modelBuilder.Configurations.Add(new WmadrsMap());
            modelBuilder.Configurations.Add(new WmadrtMap());
            modelBuilder.Configurations.Add(new WmhratMap());
            modelBuilder.Configurations.Add(new WmhrktMap());
            modelBuilder.Configurations.Add(new WmnksbMap());
        }
    }
}
