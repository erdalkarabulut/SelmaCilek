using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISphrplService
    {
        ListResponse<SPHRPL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPHRPL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPHRPL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPHRPL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPHRPL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPHRPL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPHRPL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPHRPL> Ncch_Add_NLog(SPHRPL sphrpl, Global global);
        StandardResponse<SPHRPL> Ncch_Update_Log(SPHRPL sphrpl,SPHRPL oldSphrpl, Global global);
        StandardResponse<SPHRPL> Ncch_UpdateAktifPasif_Log(SPHRPL sphrpl, Global global);
        StandardResponse<SPHRPL> Ncch_Delete_Log(SPHRPL sphrpl, Global global);

        #region ClientFunc

        ListResponse<SPHRPL> Ncch_GetListBySiparisPaketBilgi_NLog(string belgen, int satirn, string pkkodu,
            Global global, bool yetkiKontrol = true);
        StandardResponse<SPHRPL> Ncch_AddWithoutYetki_NLog(SPHRPL sphrpl, Global global);
        StandardResponse<SPHRPL> Ncch_UpdateWithoutYetki_Log(SPHRPL sphrpl, SPHRPL oldSphrpl, Global global);
        StandardResponse<SPHRPL> Ncch_DeleteWithoutYetki_Log(SPHRPL sphrpl, Global global);

        #endregion ClientFunc
    }
}
