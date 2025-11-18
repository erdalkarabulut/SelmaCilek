using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CR
{
    public interface ICrcafyService
    {
        ListResponse<CRCAFY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCAFY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCAFY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCAFY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCAFY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CRCAFY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CRCAFY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CRCAFY> Ncch_Add_NLog(CRCAFY crcafy, Global global);
        StandardResponse<CRCAFY> Ncch_Update_Log(CRCAFY crcafy,CRCAFY oldCrcafy, Global global);
        StandardResponse<CRCAFY> Ncch_UpdateAktifPasif_Log(CRCAFY crcafy, Global global);
        StandardResponse<CRCAFY> Ncch_Delete_Log(CRCAFY crcafy, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
