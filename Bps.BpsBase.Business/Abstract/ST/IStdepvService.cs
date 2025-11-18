using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStdepvService
    {
        ListResponse<STDEPV> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPV> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPV> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPV> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPV> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STDEPV> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STDEPV> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STDEPV> Ncch_Add_NLog(STDEPV stdepv, Global global);
        StandardResponse<STDEPV> Ncch_Update_Log(STDEPV stdepv,STDEPV oldStdepv, Global global);
        StandardResponse<STDEPV> Ncch_UpdateAktifPasif_Log(STDEPV stdepv, Global global);
        StandardResponse<STDEPV> Ncch_Delete_Log(STDEPV stdepv, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
