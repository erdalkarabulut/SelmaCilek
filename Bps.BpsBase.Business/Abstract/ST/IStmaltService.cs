using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStmaltService
    {
        ListResponse<STMALT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMALT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMALT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMALT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMALT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STMALT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STMALT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STMALT> Ncch_Add_NLog(STMALT stmalt, Global global);
        StandardResponse<STMALT> Ncch_Update_Log(STMALT stmalt,STMALT oldStmalt, Global global);
        StandardResponse<STMALT> Ncch_UpdateAktifPasif_Log(STMALT stmalt, Global global);
        StandardResponse<STMALT> Ncch_Delete_Log(STMALT stmalt, Global global);

        #region ClientFunc

        StandardResponse<STMALT> Cch_GetByMalTur_NLog(string malTur, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
