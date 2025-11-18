using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStdurmService
    {
        ListResponse<STDURM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDURM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDURM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDURM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDURM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STDURM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STDURM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STDURM> Ncch_Add_NLog(STDURM stdurm, Global global);
        StandardResponse<STDURM> Ncch_Update_Log(STDURM stdurm,STDURM oldStdurm, Global global);
        StandardResponse<STDURM> Ncch_UpdateAktifPasif_Log(STDURM stdurm, Global global);
        StandardResponse<STDURM> Ncch_Delete_Log(STDURM stdurm, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
