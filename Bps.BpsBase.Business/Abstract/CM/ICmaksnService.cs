using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CM
{
    public interface ICmaksnService
    {
        ListResponse<CMAKSN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMAKSN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMAKSN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMAKSN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CMAKSN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CMAKSN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CMAKSN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CMAKSN> Ncch_Add_NLog(CMAKSN cmaksn, Global global);
        StandardResponse<CMAKSN> Ncch_Update_Log(CMAKSN cmaksn,CMAKSN oldCmaksn, Global global);
        StandardResponse<CMAKSN> Ncch_UpdateAktifPasif_Log(CMAKSN cmaksn, Global global);
        StandardResponse<CMAKSN> Ncch_Delete_Log(CMAKSN cmaksn, Global global);

        #region ClientFunc

        ListResponse<CMAKSN> Ncch_GetListByBelge_NLog(string belgeNo, Global global);

        #endregion ClientFunc
    }
}
