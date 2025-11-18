using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStmhsbService
    {
        ListResponse<STMHSB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMHSB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMHSB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMHSB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STMHSB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STMHSB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STMHSB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STMHSB> Ncch_Add_NLog(STMHSB stmhsb, Global global);
        StandardResponse<STMHSB> Ncch_Update_Log(STMHSB stmhsb,STMHSB oldStmhsb, Global global);
        StandardResponse<STMHSB> Ncch_UpdateAktifPasif_Log(STMHSB stmhsb, Global global);
        StandardResponse<STMHSB> Ncch_Delete_Log(STMHSB stmhsb, Global global);

        #region ClientFunc

        ListResponse<STMHSB> Cch_GetByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
