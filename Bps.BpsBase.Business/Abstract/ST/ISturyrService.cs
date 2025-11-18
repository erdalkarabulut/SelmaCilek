using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface ISturyrService
    {
        ListResponse<STURYR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STURYR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STURYR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STURYR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STURYR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STURYR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STURYR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STURYR> Ncch_Add_NLog(STURYR sturyr, Global global);
        StandardResponse<STURYR> Ncch_Update_Log(STURYR sturyr,STURYR oldSturyr, Global global);
        StandardResponse<STURYR> Ncch_UpdateAktifPasif_Log(STURYR sturyr, Global global);
        StandardResponse<STURYR> Ncch_Delete_Log(STURYR sturyr, Global global);

        #region ClientFunc

        ListResponse<STURYR> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
