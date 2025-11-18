using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Web.Session;
using FluentValidation;

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnevrkNoValidator : AbstractValidator<GNEVRK>
    {
        IGnmesjService _gnmesjService = InstanceFactory.GetInstance<IGnmesjService>();
        public GnevrkNoValidator()
        {
            RuleFor(p => p.KALDEG).Must((o, userProfile) =>
            {
                if (!(o.KALDEG >= o.BASDEG && o.KALDEG < o.BITDEG))
                {
                    return false;
                }
                return true;
            }).WithMessage(_gnmesjService.GetMesajDirect(SessionHelper.ConvertSessiontoGlobal(), "0005", mesajKod: "GN").Nesne.MSTEXT);

            #region ClientValidator

            RuleFor(p => p.KALDEG).Must((o, userProfile) => o.KALDEG + 1 >= o.BASDEG && o.KALDEG <= o.BITDEG)
                .WithMessage(_gnmesjService.GetMesajDirect(SessionHelper.ConvertSessiontoGlobal(), "0005", mesajKod: "GN").Nesne.MSTEXT);


            #endregion
        }
    }
}
