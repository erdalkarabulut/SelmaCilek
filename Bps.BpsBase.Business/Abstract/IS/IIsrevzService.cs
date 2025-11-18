using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.UA;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsrevzService
    {
        ListResponse<ISREVZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISREVZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISREVZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISREVZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISREVZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISREVZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISREVZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISREVZ> Ncch_Add_NLog(ISREVZ isrevz, Global global);
        StandardResponse<ISREVZ> Ncch_Update_Log(ISREVZ isrevz,ISREVZ oldIsrevz, Global global);
        StandardResponse<ISREVZ> Ncch_UpdateAktifPasif_Log(ISREVZ isrevz, Global global);
        StandardResponse<ISREVZ> Ncch_Delete_Log(ISREVZ isrevz, Global global);

        #region ClientFunc

        ListResponse<UrunAgaciRevizyonList> Cch_GetListByUAModel_NLog(Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
