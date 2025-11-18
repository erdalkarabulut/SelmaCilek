using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStftipService
    {
        ListResponse<STFTIP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STFTIP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STFTIP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STFTIP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STFTIP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STFTIP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STFTIP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STFTIP> Ncch_Add_NLog(STFTIP stftip, Global global);
        StandardResponse<STFTIP> Ncch_Update_Log(STFTIP stftip,STFTIP oldStftip, Global global);
        StandardResponse<STFTIP> Ncch_UpdateAktifPasif_Log(STFTIP stftip, Global global);
        StandardResponse<STFTIP> Ncch_Delete_Log(STFTIP stftip, Global global);

        #region ClientFunc
        ListResponse<STFTIP> Ncch_GetListByHrkTipKod_NLog(int? hrkTipKod, Global global, bool yetkiKontrol = true);
        StandardResponse<STFTIP> Cch_GetByFisTipNo_NLog(int? fisTipNo, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
