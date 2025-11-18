using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Listed;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStbdrnService
    {
        ListResponse<STBDRN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STBDRN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STBDRN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STBDRN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STBDRN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STBDRN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STBDRN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STBDRN> Ncch_Add_NLog(STBDRN stbdrn, Global global);
        StandardResponse<STBDRN> Ncch_Update_Log(STBDRN stbdrn,STBDRN oldStbdrn, Global global);
        StandardResponse<STBDRN> Ncch_UpdateAktifPasif_Log(STBDRN stbdrn, Global global);
        StandardResponse<STBDRN> Ncch_Delete_Log(STBDRN stbdrn, Global global);

        #region ClientFunc

        ListResponse<STBDRN> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true);
        ListResponse<StbdrnListModel> Cch_GetListModelByStok_NLog(string stokKodu, Global global, bool yetkiKontrol = true, string vrykodu=null);
        StandardResponse<STBDRN> Ncch_GetByStkoduByVaryant_NLog(string stokKodu, string vrykodu, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
