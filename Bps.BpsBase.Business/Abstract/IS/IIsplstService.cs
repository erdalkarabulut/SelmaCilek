using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsplstService
    {
        ListResponse<ISPLST> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLST> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLST> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLST> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLST> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISPLST> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISPLST> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISPLST> Ncch_Add_NLog(ISPLST isplst, Global global);
        StandardResponse<ISPLST> Ncch_Update_Log(ISPLST isplst,ISPLST oldIsplst, Global global);
        StandardResponse<ISPLST> Ncch_UpdateAktifPasif_Log(ISPLST isplst, Global global);
        StandardResponse<ISPLST> Ncch_Delete_Log(ISPLST isplst, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
