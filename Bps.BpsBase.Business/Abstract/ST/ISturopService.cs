using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface ISturopService
    {
        ListResponse<STUROP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STUROP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STUROP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STUROP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STUROP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STUROP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STUROP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STUROP> Ncch_Add_NLog(STUROP sturop, Global global);
        StandardResponse<STUROP> Ncch_Update_Log(STUROP sturop,STUROP oldSturop, Global global);
        StandardResponse<STUROP> Ncch_UpdateAktifPasif_Log(STUROP sturop, Global global);
        StandardResponse<STUROP> Ncch_Delete_Log(STUROP sturop, Global global);

        #region ClientFunc

        ListResponse<STUROP> Ncch_GetByStokKodu_NLog(Global global, string stkodu, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
