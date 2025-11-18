using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStkmizService
    {
        ListResponse<STKMIZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKMIZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STKMIZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STKMIZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STKMIZ> Ncch_Add_NLog(STKMIZ stkmiz, Global global);
        StandardResponse<STKMIZ> Ncch_Update_Log(STKMIZ stkmiz,STKMIZ oldStkmiz, Global global);
        StandardResponse<STKMIZ> Ncch_UpdateAktifPasif_Log(STKMIZ stkmiz, Global global);
        StandardResponse<STKMIZ> Ncch_Delete_Log(STKMIZ stkmiz, Global global);

        #region ClientFunc

        StandardResponse<STKMIZ> Ncch_GetByStokKod_NLog(string stokKod, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
