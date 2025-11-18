using System;
using System.Data.Entity;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.Business.Concrete.Managers;
using Bps.Core.DataAccess;
using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.Concrete.Managers.XX;
using Bps.BpsBase.Business.Abstract.CM;
using Bps.BpsBase.Business.Concrete.Managers.CM;
using Bps.BpsBase.DataAccess.Abstract.CM;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.CM;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Concrete.Managers.CR;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.CR;
using Bps.BpsBase.Business.Abstract.FY;
using Bps.BpsBase.Business.Concrete.Managers.FY;
using Bps.BpsBase.DataAccess.Abstract.FY;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.FY;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Concrete.Managers.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Concrete.Managers.IK;
using Bps.BpsBase.DataAccess.Abstract.IK;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.IK;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Concrete.Managers.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.IS;
using Bps.BpsBase.Business.Abstract.KS;
using Bps.BpsBase.Business.Concrete.Managers.KS;
using Bps.BpsBase.DataAccess.Abstract.KS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.KS;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.Business.Concrete.Managers.MH;
using Bps.BpsBase.DataAccess.Abstract.MH;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.MH;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.Business.Concrete.Managers.SA;
using Bps.BpsBase.DataAccess.Abstract.SA;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.SA;
using Bps.BpsBase.Business.Abstract.SH;
using Bps.BpsBase.Business.Concrete.Managers.SH;
using Bps.BpsBase.DataAccess.Abstract.SH;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.SH;
using Bps.BpsBase.Business.Abstract.SN;
using Bps.BpsBase.Business.Concrete.Managers.SN;
using Bps.BpsBase.DataAccess.Abstract.SN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.SN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Concrete.Managers.SP;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Concrete.Managers.ST;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.ST;
using Bps.BpsBase.Business.Abstract.TS;
using Bps.BpsBase.Business.Concrete.Managers.TS;
using Bps.BpsBase.DataAccess.Abstract.TS;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.TS;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Concrete.Managers.UA;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Concrete.Managers.UR;
using Bps.BpsBase.DataAccess.Abstract.UR;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.UR;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Concrete.Managers.WM;
using Bps.BpsBase.DataAccess.Abstract.WM;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.WM;


#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            #region ClientNinject

            Bind<IGnService>().To<GnManager>().InSingletonScope();
            Bind<IXXService>().To<XXManager>().InSingletonScope();
            Bind<IApiService>().To<ApiManager>().InSingletonScope();
            Bind<IShopifyService>().To<ShopifyManager>().InSingletonScope();

            #endregion ClientNinject


            Bind<ICmaksnService>().To<CmaksnManager>().InSingletonScope();
            Bind<ICmaksnDal>().To<EfCmaksnDal>().InSingletonScope();

            Bind<ICmkartService>().To<CmkartManager>().InSingletonScope();
            Bind<ICmkartDal>().To<EfCmkartDal>().InSingletonScope();

            Bind<ICradrsService>().To<CradrsManager>().InSingletonScope();
            Bind<ICradrsDal>().To<EfCradrsDal>().InSingletonScope();

            Bind<ICrbankService>().To<CrbankManager>().InSingletonScope();
            Bind<ICrbankDal>().To<EfCrbankDal>().InSingletonScope();

            Bind<ICrcafyService>().To<CrcafyManager>().InSingletonScope();
            Bind<ICrcafyDal>().To<EfCrcafyDal>().InSingletonScope();

            Bind<ICrcariService>().To<CrcariManager>().InSingletonScope();
            Bind<ICrcariDal>().To<EfCrcariDal>().InSingletonScope();

            Bind<ICrytklService>().To<CrytklManager>().InSingletonScope();
            Bind<ICrytklDal>().To<EfCrytklDal>().InSingletonScope();

            Bind<IDovkurService>().To<DovkurManager>().InSingletonScope();
            Bind<IDovkurDal>().To<EfDovkurDal>().InSingletonScope();

            Bind<IFyshopifyimageService>().To<FyshopifyimageManager>().InSingletonScope();
            Bind<IFyshopifyimageDal>().To<EfFyshopifyimageDal>().InSingletonScope();

            Bind<IFyshopifyoptionService>().To<FyshopifyoptionManager>().InSingletonScope();
            Bind<IFyshopifyoptionDal>().To<EfFyshopifyoptionDal>().InSingletonScope();

            Bind<IFyshopifyorderService>().To<FyshopifyorderManager>().InSingletonScope();
            Bind<IFyshopifyorderDal>().To<EfFyshopifyorderDal>().InSingletonScope();

            Bind<IFyshopifyproductService>().To<FyshopifyproductManager>().InSingletonScope();
            Bind<IFyshopifyproductDal>().To<EfFyshopifyproductDal>().InSingletonScope();

            Bind<IFyshopifyvariantService>().To<FyshopifyvariantManager>().InSingletonScope();
            Bind<IFyshopifyvariantDal>().To<EfFyshopifyvariantDal>().InSingletonScope();

            Bind<IGnbnhrService>().To<GnbnhrManager>().InSingletonScope();
            Bind<IGnbnhrDal>().To<EfGnbnhrDal>().InSingletonScope();

            Bind<IGndpnoService>().To<GndpnoManager>().InSingletonScope();
            Bind<IGndpnoDal>().To<EfGndpnoDal>().InSingletonScope();

            Bind<IGndptnService>().To<GndptnManager>().InSingletonScope();
            Bind<IGndptnDal>().To<EfGndptnDal>().InSingletonScope();

            Bind<IGndptpService>().To<GndptpManager>().InSingletonScope();
            Bind<IGndptpDal>().To<EfGndptpDal>().InSingletonScope();

            Bind<IGndpzmService>().To<GndpzmManager>().InSingletonScope();
            Bind<IGndpzmDal>().To<EfGndpzmDal>().InSingletonScope();

            Bind<IGnevrkService>().To<GnevrkManager>().InSingletonScope();
            Bind<IGnevrkDal>().To<EfGnevrkDal>().InSingletonScope();

            Bind<IGnfileService>().To<GnfileManager>().InSingletonScope();
            Bind<IGnfileDal>().To<EfGnfileDal>().InSingletonScope();

            Bind<IGnklopService>().To<GnklopManager>().InSingletonScope();
            Bind<IGnklopDal>().To<EfGnklopDal>().InSingletonScope();

            Bind<IGnkoslService>().To<GnkoslManager>().InSingletonScope();
            Bind<IGnkoslDal>().To<EfGnkoslDal>().InSingletonScope();

            Bind<IGnkukrService>().To<GnkukrManager>().InSingletonScope();
            Bind<IGnkukrDal>().To<EfGnkukrDal>().InSingletonScope();

            Bind<IGnkullService>().To<GnkullManager>().InSingletonScope();
            Bind<IGnkullDal>().To<EfGnkullDal>().InSingletonScope();

            Bind<IGnkxmlService>().To<GnkxmlManager>().InSingletonScope();
            Bind<IGnkxmlDal>().To<EfGnkxmlDal>().InSingletonScope();

            Bind<IGnlkhrService>().To<GnlkhrManager>().InSingletonScope();
            Bind<IGnlkhrDal>().To<EfGnlkhrDal>().InSingletonScope();

            Bind<IGnmenuService>().To<GnmenuManager>().InSingletonScope();
            Bind<IGnmenuDal>().To<EfGnmenuDal>().InSingletonScope();

            Bind<IGnmesjService>().To<GnmesjManager>().InSingletonScope();
            Bind<IGnmesjDal>().To<EfGnmesjDal>().InSingletonScope();

            Bind<IGnophrService>().To<GnophrManager>().InSingletonScope();
            Bind<IGnophrDal>().To<EfGnophrDal>().InSingletonScope();

            Bind<IGnoptpService>().To<GnoptpManager>().InSingletonScope();
            Bind<IGnoptpDal>().To<EfGnoptpDal>().InSingletonScope();

            Bind<IGnorgaService>().To<GnorgaManager>().InSingletonScope();
            Bind<IGnorgaDal>().To<EfGnorgaDal>().InSingletonScope();

            Bind<IGnorhrService>().To<GnorhrManager>().InSingletonScope();
            Bind<IGnorhrDal>().To<EfGnorhrDal>().InSingletonScope();

            Bind<IGnthrkService>().To<GnthrkManager>().InSingletonScope();
            Bind<IGnthrkDal>().To<EfGnthrkDal>().InSingletonScope();

            Bind<IGntipiService>().To<GntipiManager>().InSingletonScope();
            Bind<IGntipiDal>().To<EfGntipiDal>().InSingletonScope();

            Bind<IGnyetbService>().To<GnyetbManager>().InSingletonScope();
            Bind<IGnyetbDal>().To<EfGnyetbDal>().InSingletonScope();

            Bind<IGnyetkService>().To<GnyetkManager>().InSingletonScope();
            Bind<IGnyetkDal>().To<EfGnyetkDal>().InSingletonScope();

            Bind<IIkpersService>().To<IkpersManager>().InSingletonScope();
            Bind<IIkpersDal>().To<EfIkpersDal>().InSingletonScope();

            Bind<IIsplanService>().To<IsplanManager>().InSingletonScope();
            Bind<IIsplanDal>().To<EfIsplanDal>().InSingletonScope();

            Bind<IIsplstService>().To<IsplstManager>().InSingletonScope();
            Bind<IIsplstDal>().To<EfIsplstDal>().InSingletonScope();

            Bind<IIsrevzService>().To<IsrevzManager>().InSingletonScope();
            Bind<IIsrevzDal>().To<EfIsrevzDal>().InSingletonScope();

            Bind<IIsrvhrService>().To<IsrvhrManager>().InSingletonScope();
            Bind<IIsrvhrDal>().To<EfIsrvhrDal>().InSingletonScope();

            Bind<IIsurbgService>().To<IsurbgManager>().InSingletonScope();
            Bind<IIsurbgDal>().To<EfIsurbgDal>().InSingletonScope();

            Bind<IIsyropService>().To<IsyropManager>().InSingletonScope();
            Bind<IIsyropDal>().To<EfIsyropDal>().InSingletonScope();

            Bind<IIsyrtnService>().To<IsyrtnManager>().InSingletonScope();
            Bind<IIsyrtnDal>().To<EfIsyrtnDal>().InSingletonScope();

            Bind<IKskasaService>().To<KskasaManager>().InSingletonScope();
            Bind<IKskasaDal>().To<EfKskasaDal>().InSingletonScope();

            Bind<ILockedService>().To<LockedManager>().InSingletonScope();
            Bind<ILockedDal>().To<EfLockedDal>().InSingletonScope();

            Bind<ILogsService>().To<LogsManager>().InSingletonScope();
            Bind<ILogsDal>().To<EfLogsDal>().InSingletonScope();

            Bind<IMhhsplService>().To<MhhsplManager>().InSingletonScope();
            Bind<IMhhsplDal>().To<EfMhhsplDal>().InSingletonScope();

            Bind<ISadegaService>().To<SadegaManager>().InSingletonScope();
            Bind<ISadegaDal>().To<EfSadegaDal>().InSingletonScope();

            Bind<IShsrvsService>().To<ShsrvsManager>().InSingletonScope();
            Bind<IShsrvsDal>().To<EfShsrvsDal>().InSingletonScope();

            Bind<ISirketService>().To<SirketManager>().InSingletonScope();
            Bind<ISirketDal>().To<EfSirketDal>().InSingletonScope();

            Bind<ISnifbaService>().To<SnifbaManager>().InSingletonScope();
            Bind<ISnifbaDal>().To<EfSnifbaDal>().InSingletonScope();

            Bind<ISnkrtrService>().To<SnkrtrManager>().InSingletonScope();
            Bind<ISnkrtrDal>().To<EfSnkrtrDal>().InSingletonScope();

            Bind<ISnkrtyService>().To<SnkrtyManager>().InSingletonScope();
            Bind<ISnkrtyDal>().To<EfSnkrtyDal>().InSingletonScope();

            Bind<ISnsnkrService>().To<SnsnkrManager>().InSingletonScope();
            Bind<ISnsnkrDal>().To<EfSnsnkrDal>().InSingletonScope();

            Bind<ISntynnService>().To<SntynnManager>().InSingletonScope();
            Bind<ISntynnDal>().To<EfSntynnDal>().InSingletonScope();

            Bind<ISpdkdrService>().To<SpdkdrManager>().InSingletonScope();
            Bind<ISpdkdrDal>().To<EfSpdkdrDal>().InSingletonScope();

            Bind<ISpfbasService>().To<SpfbasManager>().InSingletonScope();
            Bind<ISpfbasDal>().To<EfSpfbasDal>().InSingletonScope();

            Bind<ISpfharService>().To<SpfharManager>().InSingletonScope();
            Bind<ISpfharDal>().To<EfSpfharDal>().InSingletonScope();

            Bind<ISpftipService>().To<SpftipManager>().InSingletonScope();
            Bind<ISpftipDal>().To<EfSpftipDal>().InSingletonScope();

            Bind<ISpftopService>().To<SpftopManager>().InSingletonScope();
            Bind<ISpftopDal>().To<EfSpftopDal>().InSingletonScope();

            Bind<ISpkoslService>().To<SpkoslManager>().InSingletonScope();
            Bind<ISpkoslDal>().To<EfSpkoslDal>().InSingletonScope();

            Bind<ISpodtbService>().To<SpodtbManager>().InSingletonScope();
            Bind<ISpodtbDal>().To<EfSpodtbDal>().InSingletonScope();

            Bind<ISprezvService>().To<SprezvManager>().InSingletonScope();
            Bind<ISprezvDal>().To<EfSprezvDal>().InSingletonScope();

            Bind<ISpuropService>().To<SpuropManager>().InSingletonScope();
            Bind<ISpuropDal>().To<EfSpuropDal>().InSingletonScope();

            Bind<IStbdrnService>().To<StbdrnManager>().InSingletonScope();
            Bind<IStbdrnDal>().To<EfStbdrnDal>().InSingletonScope();

            Bind<IStcrkdService>().To<StcrkdManager>().InSingletonScope();
            Bind<IStcrkdDal>().To<EfStcrkdDal>().InSingletonScope();

            Bind<IStdepoService>().To<StdepoManager>().InSingletonScope();
            Bind<IStdepoDal>().To<EfStdepoDal>().InSingletonScope();

            Bind<IStdepvService>().To<StdepvManager>().InSingletonScope();
            Bind<IStdepvDal>().To<EfStdepvDal>().InSingletonScope();

            Bind<IStdpynService>().To<StdpynManager>().InSingletonScope();
            Bind<IStdpynDal>().To<EfStdpynDal>().InSingletonScope();

            Bind<IStftipService>().To<StftipManager>().InSingletonScope();
            Bind<IStftipDal>().To<EfStftipDal>().InSingletonScope();

            Bind<ISthbasService>().To<SthbasManager>().InSingletonScope();
            Bind<ISthbasDal>().To<EfSthbasDal>().InSingletonScope();

            Bind<ISthrktService>().To<SthrktManager>().InSingletonScope();
            Bind<ISthrktDal>().To<EfSthrktDal>().InSingletonScope();

            Bind<IStkartService>().To<StkartManager>().InSingletonScope();
            Bind<IStkartDal>().To<EfStkartDal>().InSingletonScope();

            Bind<IStkfiyService>().To<StkfiyManager>().InSingletonScope();
            Bind<IStkfiyDal>().To<EfStkfiyDal>().InSingletonScope();

            Bind<IStkfytService>().To<StkfytManager>().InSingletonScope();
            Bind<IStkfytDal>().To<EfStkfytDal>().InSingletonScope();

            Bind<IStkmihService>().To<StkmihManager>().InSingletonScope();
            Bind<IStkmihDal>().To<EfStkmihDal>().InSingletonScope();

            Bind<IStkmizService>().To<StkmizManager>().InSingletonScope();
            Bind<IStkmizDal>().To<EfStkmizDal>().InSingletonScope();

            Bind<IStmaltService>().To<StmaltManager>().InSingletonScope();
            Bind<IStmaltDal>().To<EfStmaltDal>().InSingletonScope();

            Bind<IStmhsbService>().To<StmhsbManager>().InSingletonScope();
            Bind<IStmhsbDal>().To<EfStmhsbDal>().InSingletonScope();

            Bind<IStnameService>().To<StnameManager>().InSingletonScope();
            Bind<IStnameDal>().To<EfStnameDal>().InSingletonScope();

            Bind<IStolcuService>().To<StolcuManager>().InSingletonScope();
            Bind<IStolcuDal>().To<EfStolcuDal>().InSingletonScope();

            Bind<IStoptmService>().To<StoptmManager>().InSingletonScope();
            Bind<IStoptmDal>().To<EfStoptmDal>().InSingletonScope();

            Bind<IStsaleService>().To<StsaleManager>().InSingletonScope();
            Bind<IStsaleDal>().To<EfStsaleDal>().InSingletonScope();

            Bind<IStseriService>().To<StseriManager>().InSingletonScope();
            Bind<IStseriDal>().To<EfStseriDal>().InSingletonScope();

            Bind<ISttdtrService>().To<SttdtrManager>().InSingletonScope();
            Bind<ISttdtrDal>().To<EfSttdtrDal>().InSingletonScope();

            Bind<ISturopService>().To<SturopManager>().InSingletonScope();
            Bind<ISturopDal>().To<EfSturopDal>().InSingletonScope();

            Bind<ISturyrService>().To<SturyrManager>().InSingletonScope();
            Bind<ISturyrDal>().To<EfSturyrDal>().InSingletonScope();

            Bind<IStvmihService>().To<StvmihManager>().InSingletonScope();
            Bind<IStvmihDal>().To<EfStvmihDal>().InSingletonScope();

            Bind<IStvmizService>().To<StvmizManager>().InSingletonScope();
            Bind<IStvmizDal>().To<EfStvmizDal>().InSingletonScope();

            Bind<IStvuryService>().To<StvuryManager>().InSingletonScope();
            Bind<IStvuryDal>().To<EfStvuryDal>().InSingletonScope();

            Bind<ITsfbasService>().To<TsfbasManager>().InSingletonScope();
            Bind<ITsfbasDal>().To<EfTsfbasDal>().InSingletonScope();

            Bind<ITsfharService>().To<TsfharManager>().InSingletonScope();
            Bind<ITsfharDal>().To<EfTsfharDal>().InSingletonScope();

            Bind<ITsftipService>().To<TsftipManager>().InSingletonScope();
            Bind<ITsftipDal>().To<EfTsftipDal>().InSingletonScope();

            Bind<IUakltnService>().To<UakltnManager>().InSingletonScope();
            Bind<IUakltnDal>().To<EfUakltnDal>().InSingletonScope();

            Bind<IUakltpService>().To<UakltpManager>().InSingletonScope();
            Bind<IUakltpDal>().To<EfUakltpDal>().InSingletonScope();

            Bind<IUamltyService>().To<UamltyManager>().InSingletonScope();
            Bind<IUamltyDal>().To<EfUamltyDal>().InSingletonScope();

            Bind<IUastbgService>().To<UastbgManager>().InSingletonScope();
            Bind<IUastbgDal>().To<EfUastbgDal>().InSingletonScope();

            Bind<IUastrtService>().To<UastrtManager>().InSingletonScope();
            Bind<IUastrtDal>().To<EfUastrtDal>().InSingletonScope();

            Bind<IUragacService>().To<UragacManager>().InSingletonScope();
            Bind<IUragacDal>().To<EfUragacDal>().InSingletonScope();

            Bind<IUragvrService>().To<UragvrManager>().InSingletonScope();
            Bind<IUragvrDal>().To<EfUragvrDal>().InSingletonScope();

            Bind<IUrsureService>().To<UrsureManager>().InSingletonScope();
            Bind<IUrsureDal>().To<EfUrsureDal>().InSingletonScope();

            Bind<IWmadrsService>().To<WmadrsManager>().InSingletonScope();
            Bind<IWmadrsDal>().To<EfWmadrsDal>().InSingletonScope();

            Bind<IWmadrtService>().To<WmadrtManager>().InSingletonScope();
            Bind<IWmadrtDal>().To<EfWmadrtDal>().InSingletonScope();

            Bind<IWmhratService>().To<WmhratManager>().InSingletonScope();
            Bind<IWmhratDal>().To<EfWmhratDal>().InSingletonScope();

            Bind<IWmhrktService>().To<WmhrktManager>().InSingletonScope();
            Bind<IWmhrktDal>().To<EfWmhrktDal>().InSingletonScope();

            Bind<IWmnksbService>().To<WmnksbManager>().InSingletonScope();
            Bind<IWmnksbDal>().To<EfWmnksbDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<BpsContext>();
        }
    }
}
