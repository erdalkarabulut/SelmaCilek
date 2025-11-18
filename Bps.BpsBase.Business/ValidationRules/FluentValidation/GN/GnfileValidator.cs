using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnfileValidator : AbstractValidator<GNFILE>
    {
        #region ClientService

        #endregion ClientService

        public GnfileValidator()
        {
            RuleFor(p => p.TABLNM).Length(1,6).NotNull();
            RuleFor(p => p.TABLID).NotNull();
            RuleFor(p => p.FLNAME).Length(1,50).NotNull();
            RuleFor(p => p.GNPATH).MaximumLength(500);
            RuleFor(p => p.FLTYPE).NotNull();
            RuleFor(p => p.DEFAUL).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
