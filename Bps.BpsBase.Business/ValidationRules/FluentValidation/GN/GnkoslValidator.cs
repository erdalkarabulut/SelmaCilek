using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnkoslValidator : AbstractValidator<GNKOSL>
    {
        #region ClientService

        #endregion ClientService

        public GnkoslValidator()
        {
            RuleFor(p => p.PROKOD).Length(1,20).NotNull();
            RuleFor(p => p.KOSULL).MaximumLength(250);
            RuleFor(p => p.LANGKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
