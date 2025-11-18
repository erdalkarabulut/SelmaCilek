using FluentValidation;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.SP
{
    public class SpodtbValidator : AbstractValidator<SPODTB>
    {
        #region ClientService

        #endregion ClientService

        public SpodtbValidator()
        {
            RuleFor(p => p.BELGEN).Length(1,20).NotNull();
            RuleFor(p => p.ODMSKL).Length(1,100).NotNull();
            RuleFor(p => p.ODMTRH).NotNull();
            RuleFor(p => p.ODMACK).MaximumLength(200);
            RuleFor(p => p.ODMTTR).NotNull();
            RuleFor(p => p.DVCNKD).Length(1,10).NotNull();
            RuleFor(p => p.ODMORN).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
