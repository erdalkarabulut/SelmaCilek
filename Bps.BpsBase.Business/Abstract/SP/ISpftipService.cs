using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpftipService
    {
        ListResponse<SPFTIP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTIP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTIP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTIP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTIP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPFTIP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPFTIP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPFTIP> Ncch_Add_NLog(SPFTIP spftip, Global global);
        StandardResponse<SPFTIP> Ncch_Update_Log(SPFTIP spftip,SPFTIP oldSpftip, Global global);
        StandardResponse<SPFTIP> Ncch_UpdateAktifPasif_Log(SPFTIP spftip, Global global);
        StandardResponse<SPFTIP> Ncch_Delete_Log(SPFTIP spftip, Global global);

        #region ClientFunc

        //ListResponse<SPFTIP> Ncch_GetListBySira_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFTIP> Ncch_GetListBySphrtp_NLog(Global global, int? sphrtp = null, bool yetkiKontrol = true);
        StandardResponse<SPFTIP> Cch_GetBySPFTNO_NLog(int ftno, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
