using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StseriValidator : AbstractValidator<STSERI>
    {
        #region ClientService

        #endregion ClientService

        public StseriValidator()
        {
            RuleFor(p => p.SERINO).Length(1,25).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.MALGRS).NotNull();
            RuleFor(p => p.MALCKS).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
