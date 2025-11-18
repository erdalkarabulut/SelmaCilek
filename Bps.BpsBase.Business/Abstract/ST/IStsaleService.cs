using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStsaleService
    {
        ListResponse<STSALE> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSALE> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSALE> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSALE> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSALE> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STSALE> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STSALE> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STSALE> Ncch_Add_NLog(STSALE stsale, Global global);
        StandardResponse<STSALE> Ncch_Update_Log(STSALE stsale,STSALE oldStsale, Global global);
        StandardResponse<STSALE> Ncch_UpdateAktifPasif_Log(STSALE stsale, Global global);
        StandardResponse<STSALE> Ncch_Delete_Log(STSALE stsale, Global global);

        #region ClientFunc

        ListResponse<STSALE> Cch_GetListByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
