using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StmhsbValidator : AbstractValidator<STMHSB>
    {
        #region ClientService

        #endregion ClientService

        public StmhsbValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.HSPKOD).Length(1,25).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
