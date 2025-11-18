using FluentValidation;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.ST
{
    public class StdepvValidator : AbstractValidator<STDEPV>
    {
        #region ClientService

        #endregion ClientService

        public StdepvValidator()
        {
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.VRKODU).MaximumLength(25);
            RuleFor(p => p.URYRKD).Length(1,20).NotNull();
            RuleFor(p => p.DPKODU).Length(1,4).NotNull();
            RuleFor(p => p.ENBLKJ).NotNull();
            RuleFor(p => p.USESTK).NotNull();
            RuleFor(p => p.BLKSTK).NotNull();
            RuleFor(p => p.MIPGOS).NotNull();
            RuleFor(p => p.TEDKOD).MaximumLength(4);
            RuleFor(p => p.DPADRS).MaximumLength(40);
            RuleFor(p => p.ULKEKD).MaximumLength(20);


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
