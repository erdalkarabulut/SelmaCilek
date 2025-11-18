using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class SturopValidator : AbstractValidator<STUROP>
    {
        #region ClientService

        #endregion ClientService

        public SturopValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.STKNAM).Length(1,100).NotNull();
            RuleFor(p => p.TIPKOD).Length(1,20).NotNull();
            RuleFor(p => p.HARKOD).Length(1,20).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
