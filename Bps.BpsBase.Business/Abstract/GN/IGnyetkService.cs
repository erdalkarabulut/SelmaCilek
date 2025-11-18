using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using Bps.Core.Web.Model;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Enums;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnyetkService
    {
        ListResponse<GNYETK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNYETK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNYETK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNYETK> Ncch_Add_NLog(GNYETK gnyetk, Global global);
        StandardResponse<GNYETK> Ncch_Update_Log(GNYETK gnyetk,GNYETK oldGnyetk, Global global);
        StandardResponse<GNYETK> Ncch_UpdateAktifPasif_Log(GNYETK gnyetk, Global global);
        StandardResponse<GNYETK> Ncch_Delete_Log(GNYETK gnyetk, Global global);

        #region ClientFunc

        ListResponse<ProjeMenuListed> Cch_GetProjeMenuYetkiList_NLog(Global global, string projeKod, string kulKod);
        StandardResponse<ProjeMenuListed> Cch_GetProjeMenuYetki_NLog(Global global, string kulkod);
        StandardResponse<ProjeMenuListed> Ncch_GetProjeMenuYetki_NLog(Global global, string kulkod);
        ListResponse<GNYETK> Ncch_GetListByFilter_NLog(Global global, string kulkod, string prokod, bool yetkiKontrol = true);
        StandardResponse Cch_ProjeYetkiKontrol_NLog(Global global, string projeKod, string kulkod);
        StandardResponse<GNYETK> Ncch_AddMulti_NLog(List<GNYETK> gnyetks, Global global, bool yetkiKontrol = true);
        ListResponse<ProjelerYetkiModel> Ncch_GetProjelerYetkiList_NLog(Global global);

        ListResponse<KullaniciYetkiModel> Ncch_GetKullaniciYetkiList_NLog(Global global, string kulkod, MenuPlatform menuPlatform);
        StandardResponse Ncch_MultiDelete_Log(List<GNYETK> gnyetk, Global global);
        StandardResponse Ncch_MultiAdd_Log(List<GNYETK> gnyetk, Global global);

        #endregion ClientFunc
    }
}
