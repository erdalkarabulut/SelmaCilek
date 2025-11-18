using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnorhrValidator : AbstractValidator<GNORHR>
    {
        #region ClientService

        #endregion ClientService

        public GnorhrValidator()
        {
            RuleFor(p => p.ORGKOD).Length(1,20).NotNull();
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.TABLNM).Length(1,6).NotNull();
            RuleFor(p => p.TABLID).NotNull();
            RuleFor(p => p.SIRASI).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
