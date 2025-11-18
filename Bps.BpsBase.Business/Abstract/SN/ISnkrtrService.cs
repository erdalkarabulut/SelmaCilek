using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SN
{
    public interface ISnkrtrService
    {
        ListResponse<SNKRTR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SNKRTR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SNKRTR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SNKRTR> Ncch_Add_NLog(SNKRTR snkrtr, Global global);
        StandardResponse<SNKRTR> Ncch_Update_Log(SNKRTR snkrtr,SNKRTR oldSnkrtr, Global global);
        StandardResponse<SNKRTR> Ncch_UpdateAktifPasif_Log(SNKRTR snkrtr, Global global);
        StandardResponse<SNKRTR> Ncch_Delete_Log(SNKRTR snkrtr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
