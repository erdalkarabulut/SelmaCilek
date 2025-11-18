using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnorgaService
    {
        ListResponse<GNORGA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORGA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORGA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORGA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORGA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNORGA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNORGA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNORGA> Ncch_Add_NLog(GNORGA gnorga, Global global);
        StandardResponse<GNORGA> Ncch_Update_Log(GNORGA gnorga,GNORGA oldGnorga, Global global);
        StandardResponse<GNORGA> Ncch_UpdateAktifPasif_Log(GNORGA gnorga, Global global);
        StandardResponse<GNORGA> Ncch_Delete_Log(GNORGA gnorga, Global global);

        #region ClientFunc
        ListResponse<OnayOrganizasyonTreeList> Ncch_GetOnayOrganizasyon_NLog(string orgtkd, Global global);
        StandardResponse Ncch_DeleteOrganizasyon_NLog(string orgtkd, Global global);
        ListResponse<GNORGA> Ncch_KullaniciOnayList_NLog(string orgKod, Global global);
        List<GNORGA> FindAllParents(GNORGA child, List<GNORGA> tumorg, int seviye, int itt);
        #endregion ClientFunc
    }
}
