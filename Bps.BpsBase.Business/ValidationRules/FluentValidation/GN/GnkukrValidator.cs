using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnkukrValidator : AbstractValidator<GNKUKR>
    {
        #region ClientService

        #endregion ClientService

        public GnkukrValidator()
        {
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.KARTKD).Length(1,20).NotNull();
            RuleFor(p => p.GNPOSI).NotNull();
            RuleFor(p => p.SIRASI).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
